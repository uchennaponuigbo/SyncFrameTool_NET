
namespace SyncFrameTool_NET
{
    internal struct VideoTimer
    {
        public ushort hours, minutes, seconds, frames;
        public VideoTimer() => hours = minutes = seconds = frames = 0;
        public VideoTimer(ushort h, ushort m, ushort s, ushort f)
        {
            hours = h;
            minutes = m;
            seconds = s;
            frames = f;
        }

        /// <summary>
        /// 0:00:00.00
        /// H:MM:SS.FF
        /// Hours:Minutes:Seconds.Frames
        /// </summary>
        public override string ToString()
        {
            return $"{hours}:" +
                $"{(minutes < 10 ? "0" + minutes : minutes)}:" +
                $"{(seconds < 10 ? "0" + seconds : seconds)}." +
                $"{(frames < 10 ? "0" + frames : frames)}";
        }
    }

    internal class ManageVideoTimerFrame
    {
        //private string _referenceTime = "";

        //public string ReferenceTime 
        //{
        //    get { return _referenceTime; }
        //    set 
        //    {
        //        _referenceTime = value;
        //        VideoTimer timer = TokenizeFormat(_referenceTime);
        //        ReferenceFrame = ConvertVideoTimeToFrameCount(timer);
        //    } 
        //}
        //public int ReferenceFrame { get; private set; }

        public ushort FPS { get; set; }

        public ManageVideoTimerFrame(ushort frameRate)
        {
            FPS = frameRate;
        }
        //H:MM:SS.FF
        //public ManageVideoTimerFrame(string refTime, ushort frameRate)
        //{
        //    //_referenceTime = refTime;
        //    FPS = frameRate;

        //    if(IsFPSInBounds(refTime))
        //    {
        //        ReferenceTime = refTime;
        //        //VideoTimer timer = TokenizeFormat(_referenceTime);
        //        //ReferenceFrame = ConvertVideoTimeToFrameCount(timer);
        //    }
        //    else
        //    {
        //        SetDefaults();
        //    }
        //}

        //public VideoTimer TokenizeFormat(string time)
        //{
        //    string[] timeTokens = time.Split(':', '.');

        //    ushort hour = Convert.ToUInt16(timeTokens[0]);
        //    ushort minute = Convert.ToUInt16(timeTokens[1]);
        //    ushort second = Convert.ToUInt16(timeTokens[2]);
        //    ushort frame = Convert.ToUInt16(timeTokens[3]);

        //    return new VideoTimer(hour, minute, second, frame);
        //}

        //private void SetDefaults(ushort frameRate = 0)
        //{
        //    FPS = frameRate;
        //    ReferenceTime = "00:00:00.00";      
        //}

        public int ConvertVideoTimeToFrameCount(VideoTimer timer)
        {
            int frameCount = 0;
            frameCount += (timer.hours * 3600 + (timer.minutes * 60)
                        + (timer.seconds * FPS) + timer.frames);
            return frameCount;
        }

        public VideoTimer ConvertFrameCountToVideoTime(int frameCount)
        {
            ushort seconds = (ushort)(frameCount / FPS);
            ushort frames = (ushort)(frameCount % FPS);
            ushort minutes = 0;
            ushort hours = 0;

            if (seconds >= 60)
            {
                minutes = (ushort)(seconds / 60);
                seconds -= (ushort)(minutes * 60);
            }

            if (minutes >= 60)
            {
                hours = (ushort)(minutes / 60);
                minutes -= (ushort)(hours * 60);
            }

            return new VideoTimer(hours, minutes, seconds, frames);
        }

        //public string FormatTokensToVideoTime(VideoTimer tokens) 
        //    => $"{tokens.hours}:{tokens.minutes}:{tokens.seconds}.{tokens.frames}";
        
        //public int FrameOffset(string time)
        //{
        //    VideoTimer tokens = TokenizeFormat(time);
        //    int endTimeFrame = ConvertVideoTimeToFrameCount(tokens);
        //    return (int)(endTimeFrame - ReferenceFrame);
        //}

        public int FrameOffset(VideoTimer refTime, VideoTimer endTime)
        {
            int start = ConvertVideoTimeToFrameCount(refTime);
            int end = ConvertVideoTimeToFrameCount(endTime);
            return end - start;
        }

        //public bool IsFPSInBounds(string time)
        //{
        //    string[] split = time.Split('.');
        //    ushort frame = Convert.ToUInt16(split[1]);
        //    return FPS <= frame;
        //}
    }
}
