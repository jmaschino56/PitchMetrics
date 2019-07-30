using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PitchMetrics.Models
{
    public class Pitch
    {
        public string Date { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PitchNumber { get; set; }
        public string PitchType { get; set; }
        public string Velocity { get; set; }
        public string SpinRate { get; set; }
        public string HorizontalBreak { get; set; }
        public string VerticalBreak { get; set; }
    }
}