using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web;


namespace DataLayer.Logics
{
    public class Sessions 
    {
        public ControllerBase bb { get;}
        //public Sessions()
        //{
        //    ControllerBase bas;
        //    bb = bas;
        //}

        public void getSession(string value)
        {
            bb.HttpContext.Session.SetString("key", value);
            //return value;
            //    HttpContext.Session.SetString("key", value);
            //var session = HttpContext.Session.GetString("key");
            //return session;
        }
        
    }
}
