using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace web_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        business.Domains.Account domain;
        public UserController(IConfiguration configuration)
        {
            this.domain = new business.Domains.Account(configuration);
        }
        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult GetUsers()
        {
            return Ok(this.domain.Get());
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            this.domain.Delete(id);
            return Ok();
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(business.ViewModels.Account account)
        {
            this.domain.Create(account);
            return Ok();
        }
        [HttpPut]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(business.ViewModels.Account account)
        {
            this.domain.Update(account);
            return Ok();
        }
    }
}