namespace EmployeeManagementAPI
{
    public interface IDesignation
    {
        List<Designation> GetAllDesignation();
        Designation GetDesignation(int id);
        void DeleteDesignation(int id);
        void UpdateDesignation(Designation designation);
        void InsertDesignation(CreateDesignationDto designation);
    }
}
