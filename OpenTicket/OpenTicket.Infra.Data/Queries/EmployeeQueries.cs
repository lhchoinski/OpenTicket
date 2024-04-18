namespace OpenTicket.Infra.Data.Queries
{
	public class EmployeeQueries
	{
		public const string LISTAR = @" 
			SELECT 
				Id,
				Name,
				Email,
				Department,
				EmployeeType
            FROM 
				employee"
		;

		public const string OBTER = @" 
			SELECT 
				Id,
				Name,
				Email,
				Department,
				EmployeeType
            FROM 
				employee"
		;

		public const string SALVAR = @" 
    		INSERT INTO employee (
        		Name,
        		Email,
        		Department,
        		EmployeeType
    				)
    			VALUES (
        		@Name,
        		@Email,
        		@Department,
        		@EmployeeType
    );
    SELECT LAST_INSERT_ID();"
;

		public const string ATUALIZAR = @"
    		UPDATE employee
    		SET
       			Name = @Name,
        		Email = @Email,
        		Department = @Department,
        		EmployeeType = @EmployeeType
    		WHERE
        		Id = @Id;"
		;

		public const string DELETAR = @"
			DELETE FROM 
				employee
            WHERE
				Id = @Id;"
		;

	}
}
