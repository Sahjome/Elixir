using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ElixirWebService.Models;
using MySql.Data.MySqlClient;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using System.Security.Cryptography;
using System.Text;

namespace ElixirWebService.Controllers
{
    public class ElixController : ApiController
    {
        // GET: Elix
        //Username, Firstname, Othername, Password, DOB, Sex, Status, Committee, Dept
        //Surname, Address, Email, Grad, Phone, 
        //id	Username	Firstname	Surname	Othername	Sex	Email	Grad	Regd	
        //Password	Committee	Status	Phone	Address	DOB	Dept


        readonly MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["Elixir"].ConnectionString);
        Jes response = new Jes();
        //ToDict to = new ToDict();
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
                        response.description = "success";
                        response.status = HttpStatusCode.OK;
                        response.pairs = data;
                        con.Close();
                        var mess = Request.CreateResponse(response);
                        return mess;
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadRequest;
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
                //con.Close();
                var mess = Request.CreateResponse(response);
                return mess;
            }
        }

        //Endpoint to add profile to the db
        [Route("api/profile")]
        [HttpPost]
        public HttpResponseMessage Profile(Dictionary<string, object> dt)
        {
            try
            {
                string query = "insert into profiles (Username, Firstname, Othername, Password," +
                    " DOB, Sex, Status, Committee, Dept, Surname, Address, Email, Grad, Phone) values (@Username, @Firstname, @Othername, @Password," +
                    " @DOB, @Sex, @Status, @Committee, @Dept, @Surname, @Address, @Email, @Grad, @Phone)";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Username", dt["username"]);
                cmd.Parameters.AddWithValue("Firstname", dt["firstname"]);
                cmd.Parameters.AddWithValue("Othername", dt["othername"]);
                cmd.Parameters.AddWithValue("Surname", dt["surname"]);
                cmd.Parameters.AddWithValue("Password", dt["password"]);
                cmd.Parameters.AddWithValue("DOB", dt["dob"]);
                cmd.Parameters.AddWithValue("Address", dt["address"]);
                cmd.Parameters.AddWithValue("Email", dt["email"]);
                cmd.Parameters.AddWithValue("Dept", dt["department"]);
                cmd.Parameters.AddWithValue("Phone", dt["phone"]);
                cmd.Parameters.AddWithValue("Sex", dt["sex"]);
                cmd.Parameters.AddWithValue("Grad", dt["grad"]);
                cmd.Parameters.AddWithValue("Committee", null);
                cmd.Parameters.AddWithValue("Status", dt["status"]);
                con.Open();
                var cron = cmd.ExecuteNonQuery();
                if (cron > 0)
                {
                    string sex, status;
                    if (dt["sex"].ToString() == "1")
                    {
                        sex = "male";
                    }
                    else
                    {
                        sex = "female";
                    }
                    if (dt["status"].ToString() == "1")
                    {
                        status = "student";
                    }
                    else
                    {
                        status = "alumnus";
                    }
                    Dictionary<string, object> key = new Dictionary<string, object>
                    {

                        { "username", dt["username"] },
                        {"firstname", dt["firstname"] },
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
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpoint to edit/update profile
        [Route("api/profile/edit")]
        [HttpPost]
        public HttpResponseMessage ProfileEdit(Dictionary<string, object> dt)
        {
            try
            {
                string query = "update profiles set (Username, Firstname, Othername, Password," +
                    " DOB, Sex, Status, Committee, Dept, Surname, Life_Group, Address, Email, Grad, Phone) values (@Username, @Firstname, @Othername, @Password," +
                    " @DOB, @Sex, @Status, @Committee, @Dept, @Surname, @Group, @Address, @Email, @Grad, @Phone)" +
                    " where (Email = @Email)";

                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Username", dt["username"]);
                cmd.Parameters.AddWithValue("Firstname", dt["firstname"]);
                cmd.Parameters.AddWithValue("Othername", dt["othername"]);
                cmd.Parameters.AddWithValue("Surname", dt["surname"]);
                cmd.Parameters.AddWithValue("Password", dt["password"]);
                cmd.Parameters.AddWithValue("DOB", dt["dob"]);
                cmd.Parameters.AddWithValue("Address", dt["address"]);
                cmd.Parameters.AddWithValue("Email", dt["email"]);
                cmd.Parameters.AddWithValue("Dept", dt["department"]);
                cmd.Parameters.AddWithValue("Phone", dt["phone"]);
                cmd.Parameters.AddWithValue("Sex", dt["sex"]);
                cmd.Parameters.AddWithValue("Grad", dt["grad"]);
                cmd.Parameters.AddWithValue("Group", dt["group"]);
                cmd.Parameters.AddWithValue("Committee", dt["committee"]);
                cmd.Parameters.AddWithValue("Status", dt["status"]);
                con.Open();
                var cron = cmd.ExecuteNonQuery();
                if (cron > 0)
                {
                    string sex, status;
                    if (dt["sex"].ToString() == "1")
                    {
                        sex = "male";
                    }
                    else
                    {
                        sex = "female";
                    }
                    if (dt["status"].ToString() == "1")
                    {
                        status = "student";
                    }
                    else
                    {
                        status = "alumnus";
                    }
                    Dictionary<string, object> key = new Dictionary<string, object>
                    {

                        { "username", dt["username"] },
                        {"firstname", dt["firstname"] },
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
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
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

        //Endpoint to verify login
        [Route("api/login")]
        [HttpPost]
        public HttpResponseMessage Login(Dictionary<string, object> data)
        {
            try
            {
                string query = "select * from profiles where (Email=@Entry or Username=@Entry and Password=@Password)";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Entry", data["username"]);
                cmd.Parameters.AddWithValue("Password", data["password"]);
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //read = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    response.pairs = ToDict.Table(dt);
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
            catch (Exception ex)
            {
                response.description = "login failed " + ex.Message;
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

        //Endpoint to get profile static
        [Route("api/prolog")]
        [HttpPost]
        public HttpResponseMessage LogProf(Dictionary<string, object> data)
        {
            try
            {
                string query = "select Username, Firstname, Surname, Sex, Email, Address from profiles where (Email=@Entry or Username=@Entry and Password=@Password)";
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("Entry", data["username"]);
                cmd.Parameters.AddWithValue("Password", data["password"]);
                con.Open();
                adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
                //read = cmd.ExecuteReader();
                if (dt.Rows.Count > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    response.pairs = ToDict.Table(dt);
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
            catch (Exception ex)
            {
                response.description = "login failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpoint to add to LifeGroup
        [Route("api/group")]
        [HttpPost]
        public HttpResponseMessage LifeGroup(Dictionary<string, object> data)
        {
            try
            {
                string query = "insert into profiles (Life_Group) value (@life) where Username = @username";
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("life", data["Group"]);
                cmd.Parameters.AddWithValue("username", data["Username"]);
                var cron = cmd.ExecuteNonQuery();
                if (cron > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    //response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
                else
                {
                    response.description = "failed";
                    response.status = HttpStatusCode.BadRequest;
                    // response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpoint to add to committee
        [Route("api/comm")]
        [HttpPost]
        public HttpResponseMessage Committee(Dictionary<string, object> data)
        {
            try
            {
                string query = "insert into profiles (Committee) value (@life) where Username = @username";
                con.Open();
                cmd = new MySqlCommand(query, con);
                cmd.Parameters.AddWithValue("life", data["Group"]);
                cmd.Parameters.AddWithValue("username", data["Username"]);
                var cron = cmd.ExecuteNonQuery();
                if (cron > 0)
                {
                    response.description = "success";
                    response.status = HttpStatusCode.OK;
                    //response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
                else
                {
                    response.description = "failed";
                    response.status = HttpStatusCode.BadRequest;
                    // response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
            catch (Exception ex)
            {
                response.description = "Failed " + ex.Message;
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                return Request.CreateResponse(response);
            }
        }

        //Endpoint to send mail
        [Route("api/mailer")]
        [HttpPost]
        public HttpResponseMessage MailSender(Dictionary<string, object> data)
        {
            string username = data["username"].ToString();
            string message = data["message"].ToString();
            string email;
            if (message != "forgot password")
            {
                try
                {
                    //data["email"] = "";
                    //get the pastor's email address
                    email = MailTest();
                    string query = "insert into direct_message (`from`, `to`, pair, message) values (@from, @to, @pair, @message)";
                    con.Open();
                    cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("from", data["username"]);
                    cmd.Parameters.AddWithValue("to", "Pastor");
                    cmd.Parameters.AddWithValue("pair", "Pastor-" + data["username"]);
                    cmd.Parameters.AddWithValue("message", data["message"]);
                    //send the mail here
                    var client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("b63388c1b23cdd", "70e4fbec1b3c7a"),
                        EnableSsl = true
                    };
                    client.Send("counselling@clfoau.com", email, "Counselling", message);
                    //var cron = cmd.ExecuteNonQuery();
                    client.SendCompleted += (s, e) => cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        response.description = "success";
                        response.status = HttpStatusCode.OK;
                        con.Close();
                        return Request.CreateResponse(response);
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadRequest;
                        // response.pair = key;
                        con.Close();
                        return Request.CreateResponse(response);
                    }

                    //else
                    //{
                    //    response.description = "failed";
                    //    response.status = HttpStatusCode.BadRequest;
                    //    // response.pair = key;
                    //    con.Close();
                    //    return Request.CreateResponse(response);
                    //}
                }
                catch (Exception ex)
                {
                    response.description = "Failed " + ex.Message;
                    response.status = HttpStatusCode.BadRequest;
                    // response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
            else
            {
                try
                {
                    //send emailc
                    email = data["email"].ToString();
                    //create new random string
                    string passwordstring = RandomPassword();
                    string query = "update profiles set Password = (@password) where Username = (@username)";
                    cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("password", passwordstring);
                    cmd.Parameters.AddWithValue("username", data["username"]);
                    con.Open();
                    //send the mail here
                    var client = new SmtpClient("smtp.mailtrap.io", 2525)
                    {
                        Credentials = new NetworkCredential("b63388c1b23cdd", "70e4fbec1b3c7a"),
                        EnableSsl = true
                    };
                    client.Send("support@clfoau.com", email, "Reset Password", "You have decided to change your password." +
                        " Your new password is: " + passwordstring + "\nPlease do ensure to change your password on successful" +
                        " login.\nIf you didn't effect this change please contact support.");
                    client.SendCompleted += (s, e) => cmd.ExecuteNonQuery();

                    if (cmd.ExecuteNonQuery() > 0)
                    {
                        response.description = "success";
                        response.status = HttpStatusCode.OK;
                        con.Close();
                        return Request.CreateResponse(response);
                    }
                    else
                    {
                        response.description = "failed";
                        response.status = HttpStatusCode.BadRequest;
                        // response.pair = key;
                        con.Close();
                        return Request.CreateResponse(response);
                    }
                }
                catch (Exception)
                {
                    response.description = "Failed";
                    response.status = HttpStatusCode.BadRequest;
                    // response.pair = key;
                    con.Close();
                    return Request.CreateResponse(response);
                }
            }
        }

        // Generate a random number between two numbers    
        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        // Generate a random string with a given size    
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        public string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(10, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        //test endpoint
        [Route("api/mailtest")]
        [HttpGet]
        public string MailTest()
        {
            string query = "select email from users where name = 'Admin'";
            con.Open();
            cmd = new MySqlCommand(query, con);
            var cron = cmd.ExecuteScalar();
            if (cron != null)
            {
                //Dictionary<string,object> email = new Dictionary<string, object>{
                //    { "email", cron.ToString() } };
                //response.description = "success";
                //response.status = HttpStatusCode.OK;
                //response.pair = email;
                con.Close();
                return cron.ToString();
            }
            else
            {
                response.description = "failed";
                response.status = HttpStatusCode.BadRequest;
                // response.pair = key;
                con.Close();
                return response.ToString();
            }
        }
    }
}