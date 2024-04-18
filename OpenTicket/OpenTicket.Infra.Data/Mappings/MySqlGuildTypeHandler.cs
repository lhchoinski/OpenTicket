using Dapper;
using System;
using System.Data;

namespace OpenTicket.Infra.Data.Mappings
{
    public class MySqlGuidTypeHandler : SqlMapper.TypeHandler<Guid>
    {
        public override void SetValue(IDbDataParameter parameter, Guid guid)
        {
            parameter.Value = guid.ToString();
        }

        public override Guid Parse(object value)
        {
            var stringFromByteArray = BitConverter.ToString(value as byte[])?.Replace("-", "");

            Guid.TryParse(stringFromByteArray, out var newGuid);

            return newGuid;
        }
    }
}
