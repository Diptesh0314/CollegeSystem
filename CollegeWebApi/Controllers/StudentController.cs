using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using CollegeWebApi.Model;
using System.Text.Json.Serialization;


namespace CollegeWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        ManagerModel managerModel = new ManagerModel();
        //List<StudentModel> _students = new List<StudentModel>()
        //{
        //   new StudentModel(){StudentName="Diptesh",BranchName="It"}
        //};
        [HttpPost]
        public IActionResult Post(System.Text.Json.JsonElement value)
        {
            StudentModel model = JsonConvert.DeserializeObject<StudentModel>(value.ToString());
            if (managerModel.AddStudent(model) > 0)
            {

                return Ok(new { Result = "Saved" , state="Successful"});
            }
            else
            {
                return NotFound(new { Result = "something went wrong", state = "UnSuccessful" });

            }
        }
        [HttpPut]
        public IActionResult Put(System.Text.Json.JsonElement value)
        {
            StudentModel model = JsonConvert.DeserializeObject<StudentModel>(value.ToString());
            if (managerModel.EditStudent(model) > 0)
            {
                return Ok(new { state = "Successful" });
            }
            else
            {
                return NotFound(new { Result = "Edit operation failed" });
            }
            
        }
        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    DataTable dt = managerModel.GetData();
        //    var result = new ObjectResult(dt);
        //    return result;
        //}
        
        public IActionResult Get()
        {
            List<StudentModel> students = managerModel.GetData();
            if (students.Count > 0)
            {
                return Ok(students);
            }
            else
            {
                return NotFound( new {State="Can't find any students"});
            }
            
        }


        //This Comment is Added by Varun 
    }

}
