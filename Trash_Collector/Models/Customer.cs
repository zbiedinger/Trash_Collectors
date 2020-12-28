using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public string Address { get; set; }
        public string PickupDay { get; set; }
        //public IEnumerable<SelectListItem> PickupDays { get; } = new List<SelectListItem>
        //{
        //new SelectListItem { Value = "Monday", Text = "Monday" },
        //new SelectListItem { Value = "Tuesday", Text = "Tuesday" },
        //new SelectListItem { Value = "Wednesday", Text = "Wednesday" },
        //new SelectListItem { Value = "Thursday", Text = "Thursday" },
        //new SelectListItem { Value = "Friday", Text = "Friday" },
        //new SelectListItem { Value = "Saturday", Text = "Saturday" },
        //new SelectListItem { Value = "Sunday", Text = "Sunday" }
        //};
        public DateTime ExtraPickupDay { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime SuspendedStart { get; set; }
        public DateTime SuspendedEnd { get; set; }
        public double ChargesDue { get; set; }
        public bool ConfirmPickup { get; set; }
        public DateTime LastPickup { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
