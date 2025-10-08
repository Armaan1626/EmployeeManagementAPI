namespace EmployeeManagementAPI
{
    public interface IDepartment
    {
        List<Department> GetAllDepartment();
        Department GetDepartment(int id);
        void DeleteDepartment(int id);
        void UpdateDepartment(Department department);
        void InsertDepartment(CreateDepartmentDto department);
    }
}
