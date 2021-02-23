using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DayOfWeek DayOfWeekChosenByCustomer { get; set; } //may have to revise this
        public DateTime ExtraDay { get; set; }
        public decimal AmountToPay { get; set; }
        public DateTime StartDateOfSuspension { get; set; }
        public DateTime EndDateOfSuspension { get; set; }
        public bool NormalPickedUp { get; set; }
        public bool ExtraPickedUp { get; set; }
        public int Charge { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }




        //[ForeignKey("Pickup")]
        //public int PickupId { get; set; }
        //public Pickup Pickup { get; set; }



        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
