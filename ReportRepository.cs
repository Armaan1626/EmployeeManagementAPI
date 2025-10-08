using Microsoft.Data.SqlClient;
using System.Data;
using EmployeeManagementAPI;

namespace EmployeeManagementAPI
{
    public class ReportRepository:IReport
    {
        private readonly DbHelper _dbHelper;

        public ReportRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public List<EmployeeSalaryReport> GetEmployeeeSalaryReport(int employeeId, int month, int year)
        {
            var parameters = new[] { new SqlParameter("@EmployeeId", employeeId),
                new SqlParameter("@Month", month),
                new SqlParameter("@Year", year) };
            var dt = _dbHelper.ExecuteReader("EmployeeReport", parameters);

            var list = new List<EmployeeSalaryReport>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new EmployeeSalaryReport
                {
                EmployeeId = (int)row["EmployeeID"],
                DesignationName = (string)row["DesignationName"],
                Salary_Amt = (decimal)row["Salary_Amt"],
                Tax_Amt = (decimal)row["Tax_Amt"],
                Net_Pay = (decimal)row["Net_Pay"],
                Month = (string)row["Month"],
                Year = (int)row["Year"]
                });
            }
            return list;
        }
        

    }
}
