using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeaceDemo.Models
{
    public class Message
    {
        public int status { get; set; }
        public string notification { get; set; }

        public Message(int status, string notification)
        {
            this.status = status;
            this.notification = notification;
        }
    }
}