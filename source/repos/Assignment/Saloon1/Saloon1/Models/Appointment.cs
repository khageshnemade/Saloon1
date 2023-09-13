using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Saloon1.Models;

public partial class Appointment
{
    public int AppointmentId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? AppointmentDate { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }
 [Display(Name = "Stylist Name")] // Change the display name here
 public int? StylistId { get; set; }
 [Display(Name = "Stylist Name")] // Change the display name here
 public int? ServiceId { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Service? Service { get; set; }

 public virtual Stylist? Stylist { get; set; }
}
