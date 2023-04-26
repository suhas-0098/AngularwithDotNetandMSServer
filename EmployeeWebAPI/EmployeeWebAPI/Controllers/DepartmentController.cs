using EmployeeWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;

                    }

        [HttpGet]
        [Route("GetAllDepartments")]
        public List<Department> GetAllProduct()
        {
            List<Department> Lst = new List<Department>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from Department", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Department obj = new Department();
                obj.DeptID = int.Parse(dt.Rows[i]["DeptID"].ToString());
                obj.DeptName = dt.Rows[i]["DeptName"].ToString();
                
                Lst.Add(obj);
            }

            return Lst;
        }
    }
}
    