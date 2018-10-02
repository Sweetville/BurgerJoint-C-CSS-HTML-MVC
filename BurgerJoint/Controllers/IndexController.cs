using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BurgerJoint.Controllers
{

    public class IndexController : Controller
    {
        public static Random random = new Random();
        public static string randomName()
        {
            string[] names = new string[8] { "Dan Morain", "Emily Bell", "Carol Roche", "Ann Rose", "John Miller", "Greg Anderson", "Arthur McKinney", "Joann Fisher" };
            int randomIndex = Convert.ToInt32(random.NextDouble() * 7);
            return names[randomIndex];
        }
        public static int randomNumberInRange()
        {
            return Convert.ToInt32(random.NextDouble() * 20);
        }
        // GET: Index
        public ActionResult Index()
        {
            Queue<string> line = new Queue<string>();
            Dictionary<string, int> dict = new Dictionary<string, int>();
            Dictionary<string, int> sortedDict = new Dictionary<string, int>();
            string tempName;

            for (int i = 0; i < 100; i++)
            {
                line.Enqueue(randomName());
            }

            for (int i = 0; i < 100; i++)
            {
                tempName = line.Dequeue();
                if (dict.ContainsKey(tempName) == false)
                {
                    dict.Add(tempName, 0);
                }
                dict[tempName] += randomNumberInRange();
            }

            foreach (KeyValuePair<string, int> entry in dict.OrderByDescending(i=>i.Value))
            {
                sortedDict.Add(entry.Key, entry.Value);
            }

            ViewBag.Customers = sortedDict;
            


            return View();
        }
    }
}