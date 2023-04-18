using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace PontoEletronico.Models
{
    public class TimesheetModel
    {
        public int id { get; set; }
        public DateTime start { get; set; }
        public DateTime startLunch { get; set; }
        public DateTime endLunch { get; set; }
        public DateTime end { get; set; }
        public string date
        {
            get
            {
                if (start.Ticks == 0)
                    return string.Empty;

                return start.ToString("d");
            }
        }
        public string totalTime
        {
            get
            {
                
                TimeSpan totalTime;

                if (start.Ticks == 0)
                    return string.Empty;

                if (end.Ticks == 0)
                {
                    totalTime = DateTime.Now.Subtract(start);
                }
                else
                {
                    totalTime = end.Subtract(start);
                }

                return String.Format("{0:t}", totalTime);
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