using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace StoredProcedures.Application
{
	class Client
	{
		private readonly string _connectionString = "Server=DESKTOP-4LP1OH2;Database=Company;Trusted_Connection=True;";


		public int CreateDepartment(string dName, string mgrSSN)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("USP_CreateDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DName", SqlDbType.VarChar).Value = dName;
				command.Parameters.Add("@MgrSSN", SqlDbType.VarChar).Value = mgrSSN;
				connection.Open();

				SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
				int dNumber = 0;
				while (dataReader.Read())
				{
					dNumber = (int)dataReader["DNumber"];
				}

				dataReader.Close();
				connection.Open();
				command.ExecuteNonQuery();
				return dNumber;
			};
		}

		public void UpdateDepartmentName(string dNumber, string dName)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("USP_UpdateDepartmentName", connection))
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
			using (SqlCommand command = new SqlCommand("USP_UpdateDepartmentManager", connection))
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
			using (SqlCommand command = new SqlCommand("USP_DeleteDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;

				connection.Open();
				command.ExecuteNonQuery();
			};
		}

		public Department GetDepartment(string dNumber)
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("USP_GetDepartment", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.Add("@DNumber", SqlDbType.VarChar).Value = dNumber;
				connection.Open();

				SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
				Department department = new Department();
				while (dataReader.Read())
				{
					department.DName = (string)dataReader["DName"];
					department.DNumber = (int)dataReader["DNumber"];
					department.MgrSSN = (decimal)dataReader["MgrSSN"];
					department.MgrStartDate = (DateTime)dataReader["MgrStartDate"];
					department.EmpCount = (int)dataReader["EmpCount"];
				}

				dataReader.Close();
				connection.Open();
				command.ExecuteNonQuery();
				return department;
			};
		}

		public List<Department> GetAllDepartments()
		{
			using SqlConnection connection = new SqlConnection(_connectionString);
			using (SqlCommand command = new SqlCommand("USP_GetAllDepartments", connection))
			{
				command.CommandType = CommandType.StoredProcedure;
				connection.Open();

				SqlDataReader dataReader = command.ExecuteReader(CommandBehavior.CloseConnection);
				List<Department> departments = new List<Department>();
				while (dataReader.Read())
				{
					Department department = new Department
					{
						DName = (string)dataReader["DName"],
						DNumber = (int)dataReader["DNumber"],
						MgrSSN = (decimal)dataReader["MgrSSN"],
						MgrStartDate = (DateTime)dataReader["MgrStartDate"],
						EmpCount = (int)dataReader["EmpCount"]
					};
					departments.Add(department);
				}

				dataReader.Close();
				connection.Open();
				command.ExecuteNonQuery();
				return departments;
			};
		}
	}
}
