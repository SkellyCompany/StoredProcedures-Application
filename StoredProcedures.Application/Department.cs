using System;

namespace StoredProcedures.Application
{
	class Department
	{
		public string DName { get; set; }
		public int DNumber { get; set; }
		public decimal MgrSSN { get; set; }
		public DateTime MgrStartDate { get; set; }
		public int EmpCount { get; set; }
	}
}
