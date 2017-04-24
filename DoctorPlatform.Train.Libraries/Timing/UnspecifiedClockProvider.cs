using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorPlatform.Train.Libraries.Timing
{
    public class UnspecifiedClockProvider : IClockProvider
    {
        public DateTimeKind Kind => DateTimeKind.Unspecified;
        

        public DateTime Now => DateTime.Now;

        public bool SupportsMultipleTimezone => false;
        

        public DateTime Normalize(DateTime dateTime)
        {
            return dateTime;
        }

        internal UnspecifiedClockProvider()
        {

        }
    }
}
