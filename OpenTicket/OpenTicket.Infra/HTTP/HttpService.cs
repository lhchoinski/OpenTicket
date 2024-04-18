﻿using System;
using System.IO;
using System.Xml;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Generic;
using Microsoft.AspNetCore.WebUtilities;

namespace Hotelaria.Infra.HTTP
{
    public class HttpService : HttpClient
    {
        public T Get<T>(string url, object content = null, string bearer = null, string token = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var jsonContent = JsonSerializer.Serialize(content, new JsonSerializerOptions { IgnoreNullValues = true });
                var queryParams = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(jsonContent);
                var parameters = new Dictionary<string, string>();
                if (queryParams != null)
                {
                    foreach (var item in queryParams)
                    {
                        parameters.Add(item.Key, item.Value.ToString());
                    }
                }

                var requestUri = queryParams == null ? new Uri(url) : new Uri(QueryHelpers.AddQueryString(url, parameters));
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = requestUri
                };

                Console.WriteLine($"uri http: {requestUri}");
                Console.WriteLine($"uri http content: {jsonContent}");

                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("Token", token);
                    Console.WriteLine($"Token: {token}");
                }

                if (!string.IsNullOrEmpty(bearer))
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearer);
                    Console.WriteLine($"Bearer: {bearer}");
                }

                var response = client.SendAsync(request).Result;

                Console.WriteLine($"response http: {response.StatusCode}");
                Console.WriteLine($"response content: {response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (!string.IsNullOrEmpty(json) && response.Content.Headers.ContentType.MediaType.Equals("application/json"))
                    {
                        return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    }
                    else if (!string.IsNullOrEmpty(json) && response.Content.Headers.ContentType.MediaType.Equals("text/xml"))
                    {
                        var serializer = new XmlSerializer(typeof(T));
                        var responseStream = response.Content.ReadAsStreamAsync().Result;
                        var xmlDocument = new XmlDocument();

                        xmlDocument.Load(responseStream);
                        var document = System.Xml.Linq.XDocument.Parse(xmlDocument.InnerText).Root;

                        //Pegar o nome do decorador da classe
                        var dadosCliente = document.Descendants(typeof(T).GetCustomAttributes<XmlRootAttribute>().FirstOrDefault()?.ElementName?.ToString()).FirstOrDefault().ToString();

                        var byteArray = Encoding.UTF8.GetBytes(dadosCliente);
                        var ms = new MemoryStream(byteArray);

                        var result = (T)serializer.Deserialize(ms);
                        return result;
                    }

                }

                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }

        public async Task<T> PostAsync<T>(string url, object content = null, string token = null, string header = null) where T : new()
        {
            try
            {
                using var client = new HttpClient();

                var ObjectContent = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json");

                Console.WriteLine($"uri http: {url}");
                Console.WriteLine($"uri http content: {JsonSerializer.Serialize(content)}");

                if (!string.IsNullOrEmpty(header))
                {
                    client.DefaultRequestHeaders.Add("Token", header);
                    Console.WriteLine($"Token: {header}");
                }

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    Console.WriteLine($"Authorization: {token}");
                }

                client.Timeout = TimeSpan.FromSeconds(180);
                var response = await client.PostAsync(new Uri(url), ObjectContent);

                Console.WriteLine($"response http: {response.StatusCode}");
                Console.WriteLine($"response content: {response.Content.ReadAsStringAsync().GetAwaiter().GetResult()}");

                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }

                if (response.IsSuccessStatusCode)
                {
                    return new T();
                }

                return default;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default;
            }
        }
    }
}
