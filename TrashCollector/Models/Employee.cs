using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int ZipCode { get; set; }
        public DayOfWeek DayOfWeekSelectedByEmployee { get; set; } //DayOfWeekSelected



        //[ForeignKey("Customer")]
        //public int CustomerId { get; set; }
        //public Customer Customer { get; set; }



        //public string Name { get; set; }
        //public DayOfWeek DayOfWeekChosenByCustomer { get; set; }
        //public DateTime ExtraDay { get; set; }

        //[ForeignKey("Pickup")]
        //public int PickupId { get; set; }
        //public Pickup Pickup { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
