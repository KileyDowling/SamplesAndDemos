﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCorpHR.Models
{
    public class Timesheet
    {
        public int TimesheetId { get; set; }
        public DateTime DateOfTimesheet { get; set; }
        public decimal TotalHoursByDay { get; set; }
        public int EmpId { get; set; }

        public string FormattedDateOfTimesheet
        {
            get
            {
                string returnVal = "";
                if (DateOfTimesheet != null)
                {
                    returnVal = DateOfTimesheet.ToShortDateString();
                }
                return returnVal;
            }
        }
    }
}