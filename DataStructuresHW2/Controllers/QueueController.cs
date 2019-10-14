using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DataStructures.Controllers
{
    public class QueueController : Controller
    {
        // GET: Queue
        static Queue myQueue = new Queue();
        public ActionResult Index()
        {
            ViewBag.myQueue = myQueue;
            return View();
        }
        public ActionResult AddOne()
        {
            //Add one new entry to the queue
            myQueue.Enqueue("New entry " + (myQueue.Count + 1));
            //Pass the queue to the viewbag
            ViewBag.myQueue = myQueue;
            return View("Index");
        }
        public ActionResult AddHugeList()
        {
            //Clear the current dictionary
            myQueue.Clear();
            //Add 2000 entries to the dictionary
            for (int iCount = 0; iCount < 2000; iCount++)
            {
                myQueue.Enqueue("New entry " + (myQueue.Count + 1));
            }
            //Pass the dictionary to the viewbag
            ViewBag.myQueue = myQueue;
            return View("Index");
        }
        public ActionResult Display()
        {
            //Pass the dictionary to the viewbag
            ViewBag.myQueue = myQueue;
            return View("Display");
        }
        public ActionResult Delete()
        {
            if (myQueue.Count > 0)
            {
                myQueue.Dequeue();
            }
            else
            {
                ViewBag.deleteOutput = "There are no items to delete";
            }
            return View("Index");
        }

        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            string searchValue = "New entry 5";
            bool bFound = false;
            sw.Start();
            foreach (string entryValue in myQueue)
            {
                if (entryValue == searchValue)
                {
                    sw.Stop();
                    bFound = true;
                }
            }
            if (bFound == true)
            {
                ViewBag.searchResult = "Your search for " + searchValue + " was found!";
            }
            else
            {
                sw.Stop();
                ViewBag.searchResult = "Your search for " + searchValue + " was not found!";
            }
            TimeSpan ts = sw.Elapsed;
            ViewBag.time = "It took " + ts + " seconds to search for your entry";
            //loop to do all the work
            ViewBag.StopWatch = ts;
            return View("Index");
        }
        public ActionResult ClearQueue()
        {
            //clear all items in the dictionary
            myQueue.Clear();
            //Pass the dictionary to the viewbag
            ViewBag.myQueue = myQueue;
            return View("Index");
        }
    }
}