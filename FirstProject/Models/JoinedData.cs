using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.Models
{
    public class JoinedData
    {
        public List<SelectListItem> departments { get; set; } = new List<SelectListItem>();//
        public int ID { get; set; }
        public int ShiftID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        
        public string FullName { get; set; }
        public int SWY { get; set; }
        public string Dep { get; set; }
        public int DepID { get; set; }//

        public System.DateTime ShiftDate { get; set; }
        public int StartTime { get; set; }
        public int EndTime { get; set; }
    }
}