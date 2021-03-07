using System;

namespace StoredProcedures.Application
{
	class UserInput
	{
		private bool _quit;


		public void Initialize()
		{
			Client client = new Client();

			Console.WriteLine("Choose a stored procedure to run");
			Console.WriteLine("1. Create department");
			Console.WriteLine("2. Update department name");
			Console.WriteLine("3. Update department manager");
			Console.WriteLine("4. Delete department");
			Console.WriteLine("5. Get department");
			Console.WriteLine("6. Get all department");
			Console.WriteLine("(Press X to exit the application)");
			do
			{
				string input = Console.ReadLine();
				if (!input.ToUpper().Equals("X"))
				{
					bool isNumber = int.TryParse(input, out int numberChosen);
					if (isNumber && numberChosen >= 1 && numberChosen <= 6)
					{
						UseStoredProcedure(client, numberChosen);
					}
					else if (!isNumber)
					{
						Console.WriteLine("The value you inserted was not a number.");
					}
					else
					{
						Console.WriteLine("The value you inserted was not an option.");
					}
				}
				else
				{
					_quit = true;
				}
			} while (!_quit);
		}

		private void UseStoredProcedure(Client client, int number)
		{
			switch (number)
			{
				case 1:
				{
					Console.Write("DName: ");
					string dName = Console.ReadLine();
					Console.Write("MgrSSN: ");
					string mgrSSN = Console.ReadLine();
					client.CreateDepartment(dName, mgrSSN);
					break;
				}
				case 2:
				{
					Console.Write("DNumber: ");
					string dNumber = Console.ReadLine();
					Console.Write("DName: ");
					string dName = Console.ReadLine();
					client.UpdateDepartmentName(dNumber, dName);
					break;
				}
				case 3:
				{
					Console.Write("DName: ");
					string dName = Console.ReadLine();
					Console.Write("MgrSSN: ");
					string mgrSSN = Console.ReadLine();
					client.UpdateDepartmentManager(dName, mgrSSN);
					break;
				}
				case 4:
				{
					Console.Write("DNumber: ");
					string dNumber = Console.ReadLine();
					client.DeleteDepartment(dNumber);
					break;
				}
				case 5:
				{
					Console.Write("DNumber: ");
					string dNumber = Console.ReadLine();
					client.GetDepartment(dNumber);
					break;
				}
				case 6:
				{
					client.GetAllDepartments();
					break;
				}
			}
			Console.WriteLine($"Executed procedure {number}");
		}
	}
}
