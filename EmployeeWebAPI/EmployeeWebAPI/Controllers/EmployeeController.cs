using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using EmployeeWebAPI.Models;
using System.Data.SqlClient;

namespace EmployeeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetAllEmployees")]
        public List<Employee> GetAllProduct()
        {
            List<Employee> Lst = new List<Employee>();
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("Select * from employee", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Employee obj = new Employee();
                obj.EmpId = int.Parse(dt.Rows[i]["EmpId"].ToString());
                obj.FirstName = dt.Rows[i]["FirstName"].ToString();
                obj.LastName = dt.Rows[i]["LastName"].ToString();
                obj.MobileNumber = dt.Rows[i]["MobileNumber"].ToString();
                obj.Address_ = dt.Rows[i]["Address_"].ToString();
                obj.sex = dt.Rows[i]["sex"].ToString();
                obj.Email = dt.Rows[i]["email"].ToString();
                obj.DeptID = int.Parse(dt.Rows[i]["DeptId"].ToString());
                Lst.Add(obj);
            }

            return Lst;
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "INSERT INTO Employee (FirstName,LastName,MobileNumber,Address_,sex,Email,DeptID) " +
                "VALUES (@FirstName, @LastName,@MobileNumber,@Address_,@sex,@Email,@DeptID)";
                var parameters = new SqlParameter[]
                {
                    new SqlParameter("@FirstName",employee.FirstName),
                    new SqlParameter("@LastName",employee.LastName),
                    new SqlParameter("@MobileNumber",employee.MobileNumber),
                    new SqlParameter("@Address_",employee.Address_),
                    new SqlParameter("@sex",employee.sex),
                    new SqlParameter("@Email",employee.Email),
                    new SqlParameter("@DeptID",employee.DeptID),
                };
                connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters);
                    command.ExecuteNonQuery();
                }
            }
            return Ok();

        }
            [HttpPut("{empid}")]
            public IActionResult UpdateEmployee(int empid, [FromBody] Employee employee)
            {
                if (employee == null)
                {
                    return BadRequest();
                }

                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var query = "UPDATE Employee SET FirstName = @FirstName,LastName=@LastName,MobileNumber=@MobileNumber,Address_=@Address_,sex=@sex,Email=@Email,DeptID=@DeptID WHERE empid = @empid";
                    var parameters = new SqlParameter[]
                    {
                new SqlParameter("@empid", empid),
                new SqlParameter("@FirstName", employee.FirstName),
                new SqlParameter("@LastName", employee.LastName),
                new SqlParameter("@MobileNumber", employee.MobileNumber),
                new SqlParameter("Address_",employee.Address_),
                new SqlParameter("sex",employee.sex),
                new SqlParameter("Email",employee.Email),
                new SqlParameter("DeptID",employee.DeptID)

                    };

                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddRange(parameters);
                        var rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected == 0)
                        {
                            return NotFound();
                        }
                    }
                }

                return Ok();
            }
 
[HttpDelete("{empid}")]
 public IActionResult DeleteStudnet(int empid)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var query = "DELETE FROM employee WHERE empid = @empid";
                var parameter = new SqlParameter("@empid", empid); connection.Open();
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(parameter);
                    var rowsAffected = command.ExecuteNonQuery(); if (rowsAffected == 0)
                    {
                        return NotFound();
                    }
                }
            }
            return Ok();
        }



    }
}


        
        