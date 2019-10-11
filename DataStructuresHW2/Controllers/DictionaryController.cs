using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresHW2.Controllers
{
    public class DictionaryController : Controller
    {
        static Dictionary<string, int> myDict = new Dictionary<string, int>();
        // GET: Dictionary
        public ActionResult Index()
        {

            ViewBag.MyDictionary = myDict;

            return View();
        }

        public ActionResult AddOne()
        {
            //Add stuff to the stack. Not quite done yet. Watch the video to finish.
            myDict.Add("New entry " + (myDict.Count + 1), (myDict.Count + 1));

            ViewBag.MyDictionary = myDict;

            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            //myDict.Clear();

            for(int iCount = 0; iCount <= 2000; iCount ++)
            {
                myDict.Add("New entry " + (myDict.Count + 1), (myDict.Count + 1));
            }

            ViewBag.Dictionary = myDict;

            return View("Index");
        }
    }
}