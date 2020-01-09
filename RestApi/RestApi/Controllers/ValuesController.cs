using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestApi.Controllers
{
    public class ValuesController : ApiController
    {
     
        public IEnumerable<string> Get()
        {
            return new string[] { "Valor", "Valor2" };
        }

        
        public string Get(int id)
        {
            return "Valor";
        }

        
        public void Post([FromBody]string Valor)
        {
        }

        
        public void Put(int id, [FromBody]string Valor)
        {
        }

        
        public void Delete(int id)
        {
        }
    }
}
