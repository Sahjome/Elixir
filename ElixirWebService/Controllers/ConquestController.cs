using ElixirWebService.Models;
using JSend.WebApi;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ElixirWebService.Controllers
{
    public class ConquextController : JSendApiController
    {
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Elixir"].ConnectionString);
        Jes response = new Jes();
        ToDict to = new ToDict();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        MySqlDataReader read;
        DataTable dt = new DataTable();

        //Endpoint to add to LifeGroup
        [Route("api/comms")]
        [HttpPost]
        public async Task<IHttpActionResult> Committees(Dictionary<string, object> data)
        {
            try
            {
                string query = "insert into profiles (Committee) value (@life) where Username = @uname";
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("life", data["Group"]);
                cmd.Parameters.AddWithValue("uname", data["Username"]);
                var cron = cmd.ExecuteNonQuery();
                if (cron > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    //response.pair = key;
                    con.Close();
                    return JSendOk(response);
                    //return JSendOk(response);
                }
                else
                {
                    response.description = "failed";
                    response.status = HttpStatusCode.BadRequest;
                    // response.pair = key;
                    con.Close();
                    //return Request.CreateResponse(response);
                    return JSendFail(HttpStatusCode.BadRequest, response);
                }
            }
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                //return Request.CreateResponse(response);
                return JSendFail(HttpStatusCode.BadRequest, response);
            }
        }

        [Route("api/cems")]
        [HttpPost]
        public async Task<IHttpActionResult> Commis(Dictionary<string, object> data)
        {
            string two = data["name"].ToString();
            string onr = data["uname"].ToString();
            return JSendOk(onr + " " + two);
        }

       
    }
}
