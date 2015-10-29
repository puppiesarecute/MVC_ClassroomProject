using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMvcApp.TDD
{
    public class PinkFloydsTime
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        public PinkFloydsTime(DateTime startTime, DateTime endTime)
        {
            if (startTime < endTime)
            {
                this.StartTime = startTime;
                this.EndTime = endTime;
            }
            else
            {
                throw new System.ArgumentException("Start Time should not be same or later than End Time");
            }
        }

        public bool IsOverlapped(PinkFloydsTime otherTime)
        {
            // other start time is in the middle OR other end time is in the middle
            //if ((otherTime.StartTime >= this.StartTime && otherTime.StartTime < this.EndTime)
            //    || (otherTime.EndTime > this.StartTime && otherTime.EndTime <= this.EndTime))
            //{
            //    return true;
            //}
            //// other time is outside
            //else if (otherTime.StartTime < this.StartTime && otherTime.EndTime > this.EndTime)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return ((otherTime.StartTime >= this.StartTime && otherTime.StartTime < this.EndTime) || (otherTime.EndTime > this.StartTime && otherTime.EndTime <= this.EndTime)
                    || (otherTime.StartTime < this.StartTime && otherTime.EndTime > this.EndTime));
        }
    }
}