using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresHW2.Controllers
{
    public class StackController : Controller
    {
        static Stack<string> myStack = new Stack<string>;
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

            for(int i = 0; i < 2000; i++)
            {
                myStack.Push("New entry " + (myStack.Count + 1));
            }


            ViewBag.MyStack = myStack;

            return View("Index");
        }
    }
}