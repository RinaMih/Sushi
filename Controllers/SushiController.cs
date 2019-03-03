using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.DB;
using System.Web.Script.Serialization;
using WebApplication1.Models;
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class SushiController : ApiController
    {
        // GET api/<controller>
        public string Get()
        {


            DbHelper db = new DbHelper();
            var sushies = db.GetSushi();
            return new JavaScriptSerializer().Serialize(sushies);

             // return new string[] { "value1", "value2" };

        }
        
       
        // GET api/<controller>/5
        public string Get(int id)
        {
            DbHelper db = new DbHelper();
            return new JavaScriptSerializer().Serialize(db.GetSushi(id));
            
        }

        // POST api/<controller>
        public void Post([FromBody]JObject value)
        {

            var newSushi = value.ToObject<Sushi>();

            DbHelper db = new DbHelper();
            db.AddSushi(newSushi);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]JObject value)
        {
            var newSushi = value.ToObject<Sushi>();

            DbHelper db = new DbHelper();
            db.UpdateSushi(id, newSushi);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
           
            DbHelper db = new DbHelper();
            db.DeleteSushi(id);
        }
    }
}