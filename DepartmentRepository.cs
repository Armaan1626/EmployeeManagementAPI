using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeManagementAPI;


namespace EmployeeManagementAPI
{
    public class DepartmentRepository : IDepartment
    {
        private readonly DbHelper _dbHelper;

        public DepartmentRepository(DbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public List<Department> GetAllDepartment()
        {
            var dt = _dbHelper.ExecuteReader("sp_GetDepartments", null);

            var list = new List<Department>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Department
                {
                    DepartmentID = (int)row["DepartmentID"],
                    DepartmentName = row["DepartmentName"].ToString()
                });
            }
            return list;
        }

        public Department GetDepartment(int id)
        {
            var parameters = new[] { new SqlParameter("@Id", id) };
            var dt = _dbHelper.ExecuteReader("sp_GetDepartmentById", parameters);

            if (dt.Rows.Count == 0) return null;

            var row = dt.Rows[0];
            return new Department
            {
                DepartmentID = (int)row["DepartmentID"],
                DepartmentName = row["DepartmentName"].ToString()
            };
        }

        public void InsertDepartment(CreateDepartmentDto Department)
        {
            var parameters = new[] { new SqlParameter("@DepartmentName", Department.DepartmentName) };
            var result = _dbHelper.ExecuteScalar("sp_InsertDepartment", parameters);
            //return Convert.ToInt32(result); // return new ID
        }

        public void UpdateDepartment(Department Department)
        {
            var parameters = new[]
            {
                new SqlParameter("@Id", Department.DepartmentID),
                new SqlParameter("@DepartmentName", Department.DepartmentName)
            };
            _dbHelper.ExecuteNonQuery("sp_UpdateDepartment", parameters);
        }

        public void DeleteDepartment(int id)
        {
            var parameters = new[] { new SqlParameter("@Id", id) };
            _dbHelper.ExecuteNonQuery("sp_DeleteDepartment", parameters);
        }
    }
}

