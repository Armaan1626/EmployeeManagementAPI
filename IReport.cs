namespace EmployeeManagementAPI
{
    public interface IReport
    {
        List<EmployeeSalaryReport> GetEmployeeeSalaryReport(int employeeId, int month, int year);
    }
}
