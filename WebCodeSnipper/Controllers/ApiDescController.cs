using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebCodeSnipper.Controllers
{
    [Route("api/[controller]")]
    public class ApiDescController : Controller
    {
        private readonly IApiDescriptionGroupCollectionProvider _apiDescriptionGroupCollectionProvider;
        private readonly IApiDescriptionProvider _apiDescriptionProvider;
        private readonly IActionDescriptorCollectionProvider _actionDescriptorCollectionProvider;
        public ApiDescController(
            IApiDescriptionGroupCollectionProvider apiDescriptionGroupCollectionProvider
            ,IApiDescriptionProvider apiDescriptionProvider
            ,IActionDescriptorCollectionProvider actionDescriptorCollectionProvider
            )
        {
            _apiDescriptionGroupCollectionProvider = apiDescriptionGroupCollectionProvider;
            _apiDescriptionProvider = apiDescriptionProvider;
            _actionDescriptorCollectionProvider = actionDescriptorCollectionProvider;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var apis =  _apiDescriptionGroupCollectionProvider.ApiDescriptionGroups.Items.SelectMany(p => p.Items);
            var actions = _actionDescriptorCollectionProvider.ActionDescriptors;
            return Ok();
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
