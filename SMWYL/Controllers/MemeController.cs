using Newtonsoft.Json;
using SMWYL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SMWYL.Controllers
{
    public class MemeController : Controller
    {
        
        public ActionResult Index()
        {
            string url = "https://api.imgflip.com/get_memes";

            //info api;

            List<string> ListMemes = new List<string>();

            info api;

            using (var client = new HttpClient())
            {
                var JsonData = client.GetStringAsync(url).Result;

                api = JsonConvert.DeserializeObject<info>(JsonData);

            }

            for (int i = 0; i < 100; i++)
            {
                api.data.memes[i].id = i;
            };
           
            return View(api.data.memes);
        }
    }
}