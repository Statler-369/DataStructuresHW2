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
        
        //Add one new record to stack
        
        public ActionResult AddOne()
        {
            myStack.Push("New entry " + (myStack.Count + 1));
            ViewBag.MyStack = myStack;
            return View("Index");
        }
        
        //add 2000 new records to the stack
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
        
        //display the items in the stack
        
        public ActionResult Display()
        {
            ViewBag.MyStack = myStack;
            return View();
        }
        
        //delete the top item in the stack
        
        public ActionResult DeleteItem()
        {
            if (myStack.Count > 0)
            {
                myStack.Pop();
                return View("Index");
            }
            else
            
            //if there are no records, return an error message
            
            {
                ViewBag.ErrorMessage = "There are no items to delete in this stack!";
                return View("Index");
            }
        }
        
        //clear all items in the stack
        
        public ActionResult Clear()
        {
            myStack.Clear();
            return View("Index");
        }
        
        //search for new entry 17 in the stack
        
        public ActionResult Search()
        {
        
        //start the stopwatch
        
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            bool bFound = false;
            
            //cycle through each record in the stack looking for new entry 17
            //if the record is found, stop the stopwatch and return the message
            
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
            
            // if record is not found, stop the stopwatch and return the stop message
            
            else
            {
                ViewBag.Search = "No record found!";
                sw.Stop();
            }
            
            //return the amount of time elapsed
            
            TimeSpan ts = sw.Elapsed;
            ViewBag.Time = "It took " + ts + " seconds to search this stack";
            return View("Index");
        }
    }
}
