using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace DataStructuresHW2.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>();
        // GET: Stack
        public ActionResult Index()
        {
            ViewBag.MyStack = myStack;
            return View();
        }
        public ActionResult AddOne()
        {
            myStack.Push("New entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;
            return View("Index");
        }
        public ActionResult AddMany()
        {
            myStack.Clear();
            for (int i = 0; i < 2000; i++)
            {
                myStack.Push("New entry " + (myStack.Count + 1));
            }
            ViewBag.MyStack = myStack;
            return View("Index");
        }
        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View();
        }
        public ActionResult DeleteItem()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
                return View("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "There are no items to delete in this stack!";
                return View("Index");
            }
        }
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Index");
        }
        public ActionResult Search()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool bFound = false;
            foreach (string entry in myStack)
            {
                if (entry == "New entry 17")
                {
                    bFound = true;
                    sw.Stop();
                }
            }
            if (bFound == true)
            {
                ViewBag.Search = "Your search for New entry 17 was found!";
            }
            else
            {
                ViewBag.Search = "No record found!";
                sw.Stop();
            }
            TimeSpan ts = sw.Elapsed;
            ViewBag.Time = "It took " + ts + " seconds to search this stack";
            return View("Index");
        }
    }
}