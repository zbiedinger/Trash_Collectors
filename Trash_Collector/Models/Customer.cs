using Microsoft.AspNetCore.Identity;
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
        public DateTime ExtraPickupDay { get; set; }
        public bool IsSuspended { get; set; }
        public DateTime SuspendedStart { get; set; }
        public DateTime SuspendedEnd { get; set; }
        public double ChargesDue { get; set; }


        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
