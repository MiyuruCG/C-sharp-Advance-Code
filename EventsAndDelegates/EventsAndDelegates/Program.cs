namespace EventsAndDelegates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var video = new Video() { Title = "video 1" };
            var videoEncoder = new VideoEncorder();//the publisher
            var mailService = new MailService();//subscriber
            var messageService = new MessageService();//subscriber

            videoEncoder.VideoEncorded += mailService.OnVideoEncorded; //referance to this method
            /*
             * because of the above code line the if fuction of the OnVideoEncorder function in VideoEncorder class will be true
             */
            videoEncoder.VideoEncorded += messageService.OnVideoEncorded; //referance to this method

            //need to do the subscription before calling the Encorde method
            videoEncoder.Encode(video);
        }
    }
}