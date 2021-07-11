using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstProject.Models
{
    public class EmployeeWithShifts
    {
        public List<SelectListItem> shifts { get; set; } = new List<SelectListItem>();
        public string Name { get; set; }
        
        public int EmployeeID { get; set; }
        public int ShiftID { get; set; }
    }
}