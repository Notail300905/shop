using PuzzleShop.v._2._0.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;



namespace PuzzleShop.v._2._0.Controllers
{
    public class LoginApiController : ApiController
    {
        private PuzzleShopEntities db = new PuzzleShopEntities();

        [HttpGet]
        public IHttpActionResult GetTest(object user)
        {
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult PostRegistration(Login data)
        {

            var user = new
            {
                username = data.username,
                role = new
                {
                    Title = data.role_Title,
                    bitMask = data.role_bitMask
                }
            };

            //db.Logins.Add(data);
            //db.SaveChanges();

           
            //var resp = new HttpResponseMessage();
            //resp.Content = new ObjectContent<object>(user, new JsonMediaTypeFormatter(), "application/json");
           

            var nvc = new NameValueCollection();
            nvc["username"] = user.username;
            nvc["Title"] = user.role.Title;
            nvc["bitMask"] = user.role.bitMask;


            var resp = Request.CreateResponse<NameValueCollection>(HttpStatusCode.OK, nvc);
   
            return ResponseMessage(resp);

            string user1 = "user";
            string jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(user1);
            var cookie = new CookieHeaderValue("user", user1);
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = null;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            //resp.Headers.Add("Content-Type", "application/json");
            resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //return ResponseMessage(resp);
            //return resp;
        }
        //public HttpResponseMessage Cookies1()
        //{
        //    var resp = new HttpResponseMessage();

        //    var cookie = new CookieHeaderValue("session-id", "12345");
        //    cookie.Expires = DateTimeOffset.Now.AddDays(1);
        //    cookie.Domain = Request.RequestUri.Host;
        //    cookie.Path = "http://localhost:3193/";

        //    resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
        //    resp.Content = new StringContent("fdsgjgggggggggggggggg");;
        //    return resp;
        //}
        [HttpPost]
        public IHttpActionResult PostLogin(object user)
        {
            db.Configuration.ProxyCreationEnabled = false;
            //int subId = 0;

            List<ItemsTable> subItems = new List<ItemsTable>();
            //    //subId = subName.Id;
            //foreach (var item2 in db.ItemsTables)
            //{
            //    if (item2.SubcategoryId == subId)
            //    {
            //        subItems.Add(item2);
            //    }
            //}
            return Ok(subItems);
        }
        }
    }


