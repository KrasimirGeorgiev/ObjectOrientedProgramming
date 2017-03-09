namespace MobileDevices
{
    using System;

    public class Call
    {
        public Call(DateTime startTime, string dialedNumber, TimeSpan duration)
        {
            this.Date = startTime.ToShortDateString();
            this.Time = startTime.ToShortTimeString();
            this.DialedNumber = dialedNumber;
            this.CallDuration = duration;
        }

        public Call(DateTime startTime, string dialedNumber, DateTime endTime)
            : this(startTime, dialedNumber, endTime - startTime)
        {

        }

        public string Date { get; private set; }

        public string Time { get; private set; }

        public string DialedNumber { get; private set; }

        public TimeSpan CallDuration { get; private set; }

        public string GetCallInformation()
        {
            return string.Format("{0}, Dialed Number: {1} | Duration: {2}min {3}s",
                                this.Date, 
                                this.DialedNumber, 
                                this.CallDuration.Minutes + (this.CallDuration.Hours * 60), 
                                this.CallDuration.Seconds);
        }

    }
}
