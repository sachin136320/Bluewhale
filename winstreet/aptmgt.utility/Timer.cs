using System;

namespace aptmgt.utility
{
    public class Timer
    {
        public static string GetTime()
        {
            return new DateTime().ToShortDateString();
        }
    }
}
