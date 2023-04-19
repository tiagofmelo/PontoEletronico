using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Microsoft.Ajax.Utilities;

namespace PontoEletronico.Models
{
    public class TimesheetModel
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime startLunch { get; set; }
        public DateTime endLunch { get; set; }
        public DateTime end { get; set; }
        public DateTime totalTime
        {
            get
            {
                long totalTime;

                //if (start.Ticks == 0)
                //    return string.Empty;

                if (end.Ticks == 0)
                {
                    totalTime =  DateTime.Now.Subtract(start).Ticks;
                }
                else
                {
                    totalTime = end.Subtract(start).Ticks;
                }

                DateTime dateTime = new DateTime(totalTime);
                //return String.Format("{0:t}", totalTime);
                return dateTime;
            }
        }
    }

    public class Pagination
    {
        public TimesheetModel[] items { get; set; }
        public int count { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalPages { get; set; }
        public string nextPage { get; set; }
        public string previousPage { get; set; }
    }
}