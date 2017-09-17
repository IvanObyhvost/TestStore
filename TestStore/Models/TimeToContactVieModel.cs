using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TestStore.Models
{
    public class TimeToContactVieModel
    {
        public bool AnyTime{ get;  set;}

        [Description("Monday AM")]
        public bool MondayAM { get; set; }
        [Description("Monday PM")]
        public bool MondayPM { get; set; }


        [Description("Tuesday AM")]
        public bool TuesdayAM { get; set; }
        [Description("Tuesday PM")]
        public bool TuesdayPM { get; set; }


        [Description("Wednesday AM")]
        public bool WednesdayAM { get; set; }
        [Description("Wednesday PM")]
        public bool WednesdayPM { get; set; }


        [Description("Thursday AM")]
        public bool ThursdayAM { get; set; }
        [Description("Thursday PM")]
        public bool ThursdayPM { get; set; }


        [Description("Friday AM")]
        public bool FridayAM { get; set; }
        [Description("Friday PM")]
        public bool FridayPM { get; set; }


        [Description("Saturday AM")]
        public bool SaturdayAM { get; set; }
        [Description("Saturday PM")]
        public bool SaturdayPM { get; set; }
    }
}