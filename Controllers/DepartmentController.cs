using Entites;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppWithAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public  DepartmentController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        [Route("getDepartments")]

        public IEnumerable<Department> GetDepartments()
        {
            return new Service.DepartmentServices().Get();
        }

        [HttpGet]
        [Route("GetSeule")]
        public Department Get(int id)
        {
            return new Service.DepartmentServices().Get(id);     
        }

        [HttpPost]
        [Route("nouveauDep")]
        public void Post(int id, string department)
        {
            Department d = new Department();
            d.DepartmentName = department;

           new Service.DepartmentServices().Post(d);
        }

        [HttpPut]
        [Route("modifier")]
        public void Put([FromBody] Department con)
        {

            new Service.DepartmentServices().Put(con);
        }

        [HttpGet]
        [Route("supprimer")]
        public void Delete([FromBody] Department con)
        {
            new Service.DepartmentServices().Delete(con);
        }
    }
}
