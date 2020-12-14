using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace activitytracker.Models
{
    public class ActivityModel
    {
        [Required]
        public string Activity { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
