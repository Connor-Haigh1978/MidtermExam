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
    public class RandomMemeController : Controller
    {
        // GET: RandomMeme
        public ActionResult Index()
        {

            Random rn = new Random();
            int num = rn.Next(101);

            IndividualInfo NewRand = new IndividualInfo();


            List<IndividualInfo> RandomMeme = new List<IndividualInfo>();
            string url = "https://api.imgflip.com/get_memes";

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
            foreach (IndividualInfo item in api.data.memes)
            {
                NewRand.RandomId = num;
                if (num == item.id)
                {
                    NewRand = item;
                    
                }
            }
            return View(NewRand);

        }
    }
}