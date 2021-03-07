using System.Data;
using System.Data.SqlClient;

namespace StoredProcedures.Application
{
	class Client
	{
		private readonly string _connectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";


		public void CreateDepartment(string dName, string mgrSSN)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("CreateDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dName;
				command.Parameters.Add("@MgrSSN", SqlDbType.VarChar).Value = mgrSSN;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public void UpdateDepartmentName(string dNumber, string dName)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("UpdateDepartmentName", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;
				command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dName;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public void UpdateDepartmentManager(string dNumber, string mgrSSN)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("UpdateDepartmentManager", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;
				command.Parameters.Add("@MgrSSN", SqlDbType.VarChar).Value = mgrSSN;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public void DeleteDepartment(string dNumber)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("DeleteDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public void GetDepartment(string dNumber)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("GetDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public void GetAllDepartments()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("GetAllDepartments", connection))
			{
				command.CommandType = CommandType.StoredProcedure;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}
	}
}
