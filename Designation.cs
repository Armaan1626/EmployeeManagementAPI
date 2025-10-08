using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementAPI
{
    [Table("Designation")]
    public class Designation
    {
        public int DesignationId { get; set; }
        public string DesignationName { get; set; }
    }
}
