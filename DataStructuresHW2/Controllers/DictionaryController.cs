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
            int errorCheckVar = 0;

            //If a record was deleted from the middle of the dictionary, we need to make sure a different key is added.            
            while (myDict.ContainsKey("New entry " + (myDict.Count + 1 + errorCheckVar)))
            {
                errorCheckVar++;
            } 
            
            //Add one new entry to the dictionary
            myDict.Add("New entry " + (myDict.Count + 1 + errorCheckVar), (myDict.Count + 1 + errorCheckVar));

            //Pass the dictionary to the viewbag
            ViewBag.MyDictionary = myDict;

            return View("Index");
        }

        public ActionResult AddHugeList()
        {
            //Clear the current dictionary
            myDict.Clear();

            //Add 2000 entries to the dictionary
            for(int iCount = 0; iCount < 2000; iCount ++)
            {
                myDict.Add("New entry " + (myDict.Count + 1), (myDict.Count + 1));
            }

            //Pass the dictionary to the viewbag
            ViewBag.MyDictionary = myDict;

            return View("Index");
        }

        public ActionResult Display()
        {

            //Pass the dictionary to the viewbag. The view will do the rest.
            ViewBag.MyDictionary = myDict;

            return View();
        }

        public ActionResult SelectDelete()
        {
            //Navigate to the SelectDelete View. Code in the view will do the rest
            ViewBag.MyDictionary = myDict;

            return View();
        }

        [HttpPost]
        public ActionResult DeleteItem(string DeleteKey)
        {            
            //A key to delete has been passed from the view.

            //Make sure the key is in the dictionary
            if (!myDict.ContainsKey(DeleteKey))
            {
                //If the key is not in the dictionary, have the user try again.
                ViewBag.DeleteKey = DeleteKey;
                ViewBag.KeyFound = false;
                return View("SelectDelete");
            }

            //Otherwise, continue forward.
            //Remove the key. Delete the key/value pair.
            myDict.Remove(DeleteKey);

            //set myDict to the new dictionary
            ViewBag.MyDictionary = myDict;

            return View("Index");
        }

        public ActionResult ClearDict()
        {
            //clear all items in the dictionary
            myDict.Clear();

            //Pass the dictionary to the viewbag
            ViewBag.MyDictionary = myDict;

            return View("Index");
        }

        public ActionResult SearchDict()
        {

            //Pass the dictionary to the viewbag. Navigate to the search view.
            ViewBag.MyDictionary = myDict;

            return View();
        }

        public ActionResult SearchKey(string SearchKey)
        {
            //Set the viewbag to the value passed from the view.
            ViewBag.SearchKey = SearchKey;

            //Initialize the stopwatch
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            //Make sure the key is in the dictionary
            if (!myDict.ContainsKey(SearchKey))
            {
                //If the key is not in the dictionary, have the user try again.                
                ViewBag.SearchKeyFound = false;
                return View("SearchDict");
            }

            //not in the key was found in the dictionary.
            ViewBag.SearchKeyFound = true;

            //Figure out how long it takes for the dictionary to find a value.
            sw.Start();
            if (myDict.ContainsKey(SearchKey))
            {
                sw.Stop();
            }

            //Set a variable to the elapsed time.
            TimeSpan ts = sw.Elapsed;

            //Pass the elapsed time to the view.
            ViewBag.StopWatch = ts;

            //Pass the dictionary to the viewbag
            ViewBag.MyDictionary = myDict;

            return View("SearchDict");
        }
    }
}