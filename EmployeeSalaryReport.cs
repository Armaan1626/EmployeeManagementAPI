namespace EmployeeManagementAPI
{
    public class EmployeeSalaryReport
    {
        public int EmployeeId { get; set; }
        public int DesignationID { get; set; }
        public string DesignationName { get; set; }
        public decimal Salary_Amt { get; set; }
        public decimal Tax_Amt { get; set; }
        public decimal Net_Pay { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
    }
}
