using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VideoRentalSystem.Models
{
    public class JsonResponse
    {
        public Object Data { get; set; }
        public Object Errors { get; set; }
        public Object Meta { get; set; }


        public JsonResponse(Exception e)
        {
            Data = null;
            Errors = e;
            Meta = null;
        }

        public JsonResponse(string s)
        {
            Data = null;
            Errors = s;
            Meta = null;
        }
        public JsonResponse(Object d)
        {
            Data = d;
            Errors = null;
            Meta = new List<Object>();
        }

        //Successful call - accepts any object, returned as JSON
        public static JsonResponse getInstance(Object d)
        {
            return new JsonResponse(d);
        }

        //Unsuccessful call - pass in the exception thrown
        public static JsonResponse getInstance(Exception e)
        {
            return new JsonResponse(e);
        }

        //Used when we want to pass a message back to front end - ie for login page if invalid credentials attempted
        public static JsonResponse getInstance(String s)
        {
            return new JsonResponse(s);
        }
    }
}