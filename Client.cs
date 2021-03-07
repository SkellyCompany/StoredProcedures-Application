using System.Data;
using System.Data.SqlClient;

namespace StoredProcedures.Application
{
	class Client
	{
		private readonly string _connectionString = "";


		public void CreateDepartment()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("CreateDepartment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}

		public void UpdateDepartmentName()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("UpdateDepartmentName", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}

		public void UpdateDepartmentManager()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("UpdateDepartmentManager", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}

		public void DeleteDepartment()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("DeleteDepartment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}

		public void GetDepartment()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("GetDepartment", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}

		public void GetAllDepartments()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using SqlCommand command = new SqlCommand("GetAllDepartments", connection)
			{
				CommandType = CommandType.StoredProcedure
			};
			connection.Open();
			command.ExecuteNonQuery();
		}
	}
}
