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
        [ForeignKey("Pickup")]
        public int PickupId { get; set; }
        public Pickup Pickup { get; set; }
    }
}
