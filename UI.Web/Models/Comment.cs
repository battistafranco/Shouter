using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Web.Models
{
    public class Comment
    {
        public ObjectId _id { get; set; }
        public string email { get; set; }
        public DateTime dateTime { get; set; }
        public string comment { get; set; }
        public string Since
        {
            get
            {
                double timeToShow = 0;                
                double time = Math.Truncate((DateTime.Now - dateTime).TotalMinutes);
            
                if (time > 60)
                {
                    timeToShow = Math.Truncate(time / 60);
                    return timeToShow + " Hours ago.";
                }
                else
                {
                    timeToShow = time;
                    return timeToShow + " Minutes ago.";
                }
            }
        }
    }
}