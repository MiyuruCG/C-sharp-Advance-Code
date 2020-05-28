using System;

namespace EventsAndDelegates
{
    public class MessageService
    {
        public void OnVideoEncorded(object source, VideoEventArgs args)
        {
            Console.WriteLine("MessageService : sending message..."+args.Video.Title);
        }
    }
}