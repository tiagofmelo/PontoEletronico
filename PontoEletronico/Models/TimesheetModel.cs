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
                try
                {
                    long totalTime;

                    if (end.Ticks > 0)
                    {
                        totalTime = end.Subtract(start).Ticks;
                    }
                    else if (endLunch.Ticks > 0)
                    {
                        totalTime = endLunch.Subtract(start).Ticks;
                    }
                    else if (startLunch.Ticks > 0)
                    {
                        totalTime = startLunch.Subtract(start).Ticks;
                    }
                    else
                    {
                        totalTime = DateTime.MinValue.Ticks;
                    }

                    DateTime dateTime = new DateTime(totalTime);

                    return dateTime;
                }
                catch 
                {
                    return DateTime.MinValue;
                }
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