namespace OpenTicket.Infra.Data.Queries
{
	public class ManagerTicketQueries
	{
		public const string ATUALIZAR = @"
			UPDATE ticket
            SET 
				Id = @Id,
				TechnicianDescription = @TechnicianDescription,
				UpdatedAt = @UpdatedAt,
				AssignedEmployeeId = @AssignedEmployeeId,
				Status = @Status
            WHERE
				Id = @Id;"
		;
	}
}
