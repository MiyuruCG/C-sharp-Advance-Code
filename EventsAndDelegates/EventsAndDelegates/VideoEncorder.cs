using System;
using System.Threading;

namespace EventsAndDelegates
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }
    public class VideoEncorder
    {
        //1: define delegate = the contract between the publisher and subscriber
        //2: define an event based on that delegate
        //3: raise the event

        //1 :: delegate will holds a reference to a function that looks as below (void and 2 input parameters ; object and EventArgs)
        //public delegate void VideoEncordedEventHandler(object source, VideoEventArgs args);



        //2:: create event
        //public event VideoEncordedEventHandler VideoEncorded;
        public event EventHandler<VideoEventArgs> VideoEncorded; //steps 1 & 2
        

        public void Encode(Video video)
        {
            Console.WriteLine("Encording video...");
            Thread.Sleep(3000);

            OnVideoEncorded(video);
        }

        //3::
        protected virtual void OnVideoEncorded(Video video)
        {
            if (VideoEncorded != null)
            {
                VideoEncorded(this, new VideoEventArgs() { Video = video});
            }
        }
    }
}