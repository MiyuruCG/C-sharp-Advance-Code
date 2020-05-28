using System;

namespace EventsAndDelegates
{
    public class MailService
    {
        public void OnVideoEncorded(object scource, VideoEventArgs e)
        {
            Console.WriteLine("MailService : sending an email..." + e.Video.Title);
        }
    }
}