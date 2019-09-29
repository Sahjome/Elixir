using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ElixirWebService.Models;
using MySql.Data.MySqlClient;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace ElixirWebService.Controllers
{
    public class ElixController : ApiController
    {
        // GET: Elix
        //Username, Firstname, Othername, Password, DOB, Sex, Status, Committee, Dept
        //Surname, Address, Email, Grad, Phone, 
        //id	Username	Firstname	Surname	Othername	Sex	Email	Grad	Regd	
        //Password	Committee	Status	Phone	Address	DOB	Dept


        //readonly string cs = ;
        MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Elixir"].ConnectionString);
        Jes response = new Jes();
        ToDict to = new ToDict();
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        MySqlDataReader read;
        DataTable dt = new DataTable();

        //Endpoint to get all fromm db 
        [Route("api/getting")]
        [HttpGet]
        public HttpResponseMessage Announcement()
        {
            try
            {
                string query = "select * from announcements";
                cmd = new MySqlCommand(query, con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    read.Close();
                    adapter = new MySqlDataAdapter(cmd);
                    var cot = adapter.Fill(dt);
                    if (cot > 0)
                    {
                        var data = ToDict.Table(dt);
                        //List<Dictionary<string,string>> data =new  List<Dictionary<to.Table(dt)>();
                        response.description = "all of them";
                        response.status = HttpStatusCode.OK;
                        response.pairs = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadGateway;
                        //response.pair = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                }
                else
                {
                    response.description = "No records";
                    response.status = HttpStatusCode.OK;
                    //response.pair = data;
                    con.Close();
                    var mess = Request.CreateResponse(response);
                    return mess;
                }
            }
            catch(Exception ex)
            {
                response.description = "Failed "+ex.Message;
                response.status = HttpStatusCode.BadRequest;
                //response.pair = data;
                //con.Close();
                var mess = Request.CreateResponse(response);
                return mess;
            }
        }

        //Endpoint to add profile to the db
        [Route("api/profile")]
        [HttpPost]
        public HttpResponseMessage Profile(Dictionary<string,object> dt)
        {
            try
            {
                string query = "insert into profiles (Username, Firstname, Othername, Password," +
                    " DOB, Sex, Status, Committee, Dept, Surname, Address, Email, Grad, Phone) values (@Username, @Firstname, @Othername, @Password," +
                    " @DOB, @Sex, @Status, @Committee, @Dept, @Surname, @Address, @Email, @Grad, @Phone)";
            
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Username", dt["uname"]);
                cmd.Parameters.AddWithValue("Firstname", dt["fname"]);
                cmd.Parameters.AddWithValue("Othername", dt["oname"]);
                cmd.Parameters.AddWithValue("Surname", dt["sname"]);
                cmd.Parameters.AddWithValue("Password", dt["pass"]);
                cmd.Parameters.AddWithValue("DOB", dt["dob"]);
                cmd.Parameters.AddWithValue("Address", dt["addy"]);
                cmd.Parameters.AddWithValue("Email", dt["email"]);
                cmd.Parameters.AddWithValue("Dept", dt["dept"]);
                cmd.Parameters.AddWithValue("Phone", dt["phone"]);
                cmd.Parameters.AddWithValue("Sex", dt["sex"]);
                cmd.Parameters.AddWithValue("Grad", dt["grad"]);
                cmd.Parameters.AddWithValue("Committee", dt["comm"]);
                cmd.Parameters.AddWithValue("Status", dt["status"]);
                con.Open();
                var cron = cmd.ExecuteNonQuery();
                if(cron > 0)
                {
                    string sex,status;
                    if (dt["sex"].ToString() == "1")
                    {
                        sex = "male";
                    }
                    else
                    {
                        sex = "female";
                    }
                    if(dt["status"].ToString() == "1")
                    {
                        status = "student";
                    }
                    else
                    {
                        status = "alumnus";
                    }
                    Dictionary<string, object> key = new Dictionary<string, object>
                    {
                    
                        { "username", dt["uname"] },
                        {"firstname", dt["fname"] },
                        {"sex", sex},
                        {"status", status}
                    };
                    response.description = "Profile registered successfully";
                    response.status = HttpStatusCode.OK;
                    response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
                else
                {
                    response.description = "Profile registration wasn't successful";
                    response.status = HttpStatusCode.BadRequest;
                   // response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
            catch(Exception ex)
            {
                response.description = "Failed "+ex.Message;
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpoint to get media
        [Route("api/media")]
        [HttpGet]
        public HttpResponseMessage Media()
        {
            try
            {
                string query = "select * from media";
                cmd = new MySqlCommand(query, con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    read.Close();
                    adapter = new MySqlDataAdapter(cmd);
                    var cot = adapter.Fill(dt);
                    if (cot > 0)
                    {
                        var data = ToDict.Table(dt);
                        //List<Dictionary<string,string>> data =new  List<Dictionary<to.Table(dt)>();
                        response.description = "all of them";
                        response.status = HttpStatusCode.OK;
                        response.pairs = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadGateway;
                        //response.pair = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                }
                else
                {
                    response.description = "No records";
                    response.status = HttpStatusCode.OK;
                    //response.pair = data;
                    con.Close();
                    var mess = Request.CreateResponse(response);
                    return mess;
                }
            }
            catch(Exception ex)
            {
                response.description = "Failed "+ex.Message;
                response.status = HttpStatusCode.BadRequest;
                //response.pair = data;
                con.Close();
                var mess = Request.CreateResponse(response);
                return mess;
            }
        }

        //Endpoint to verify login
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(Dictionary<string, object> data)
        {
            try
            {
                string query = "select id from profiles where (Email=@Entry or Username=@Entry and Password=@Password)";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Entry", data["uname"]);
                cmd.Parameters.AddWithValue("Password", data["pass"]);
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //read = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    con.Close();
                    return Request.CreateResponse(response);
                }
                else
                {
                    response.description = "login failed";
                    response.status = HttpStatusCode.BadRequest;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
            catch(Exception ex)
            {
                response.description = "login failed "+ex.Message;
                response.status = HttpStatusCode.BadRequest;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpooint to get all diets
        [Route("api/diet")]
        [HttpGet]
        public HttpResponseMessage Diet()
        {
            try
            {
                string query = "select * from media where diet !=''";
                cmd = new MySqlCommand(query, con);
                con.Open();
                read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    read.Close();
                    adapter = new MySqlDataAdapter(cmd);
                    var cot = adapter.Fill(dt);
                    if (cot > 0)
                    {
                        var data = ToDict.Table(dt);
                        //List<Dictionary<string,string>> data =new  List<Dictionary<to.Table(dt)>();
                        response.description = "all of them";
                        response.status = HttpStatusCode.OK;
                        response.pairs = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadGateway;
                        //response.pair = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                }
                else
                {
                    response.description = "No records";
                    response.status = HttpStatusCode.OK;
                    //response.pair = data;
                    con.Close();
                    var mess = Request.CreateResponse(response);
                    return mess;
                }
            }
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                //response.pair = data;
                con.Close();
                var mess = Request.CreateResponse(response);
                return mess;
            }
        }
    }
}