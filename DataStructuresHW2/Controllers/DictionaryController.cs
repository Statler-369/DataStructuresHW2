using DataStructuresHW2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataStructuresHW2.Controllers
{
    public class DictionaryController : Controller
    {
        static Stack<string> myStack = new Stack<string>;
        // GET: Dictionary
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult AddOne()
        {
            //Add stuff to the stack. Not quite done yet. Watch the video to finish.
            myStack.Push("Stack Item " + );
            return ("Index");
        }
    }
}