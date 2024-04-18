namespace OpenTicket.Infra.Data.Queries
{
	public class TicketQueries
	{
		public const string LISTAR = @" 
			SELECT 
				Id,
				Title,
				Description,
				TechnicianDescription,
				CreatedAt,
				UpdatedAt,
				EmployeeId,
				AssignedEmployeeId,
				Status
            FROM 
				ticket;"
		;

		public const string OBTER = @" 
			SELECT 
				Id,
				Title,
				Description,
				TechnicianDescription,
				CreatedAt,
				UpdatedAt,
				EmployeeId,
				AssignedEmployeeId,
				Status
            FROM 
				ticket
			WHERE
                Id = @Id;"
		;

		public const string SALVAR = @" 
    INSERT INTO ticket (
        Title,
        Description,
        TechnicianDescription,
        CreatedAt,
        UpdatedAt,
        EmployeeId,
        AssignedEmployeeId,
        Status
    )
    VALUES (
        @Title,
        @Description,
        @TechnicianDescription,
        @CreatedAt,
        @UpdatedAt,
        @EmployeeId,
        @AssignedEmployeeId,
        @Status
    );
    SELECT LAST_INSERT_ID();";

		public const string ATUALIZAR = @"
			UPDATE ticket
            SET 
				Title = @Title,
				Description = @Description,
				TechnicianDescription = @TechnicianDescription,
				CreatedAt = @CreatedAt,
				UpdatedAt = @UpdatedAt,
				EmployeeId = @EmployeeId,
				AssignedEmployeeId = @AssignedEmployeeId,
				Status = @Status
            WHERE
				Id = @Id;"
		;

		public const string DELETAR = @"
			DELETE FROM 
				ticket
            WHERE
				Id = @Id;"
		;
	}
}
