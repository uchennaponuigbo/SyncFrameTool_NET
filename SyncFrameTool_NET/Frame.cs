
namespace SyncFrameTool_NET
{
    internal struct VideoTimer
    {
        public ushort hour, minutes, seconds, frames;
        public VideoTimer() => hour = minutes = seconds = frames = 0;
        public VideoTimer(ushort h, ushort m, ushort s, ushort f)
        {
            hour = h;
            minutes = m;
            seconds = s;
            frames = f;
        }
    }

    internal class ManageTimerFrame
    {
        private string _referenceTime;
        public string ReferenceTime 
        {
            get { return _referenceTime; }
            set 
            {
                _referenceTime = value;
                VideoTimer timer = TokenizeFormat(_referenceTime);
                ReferenceFrame = ConvertVideoTimeToFrameCount(timer);
            } 
        }
        public uint ReferenceFrame { get; private set; }

        public ushort FPS { get; set; }
        //H:MM:SS.FF
        public ManageTimerFrame(string refTime, ushort frameRate)
        {
            _referenceTime = refTime;
            FPS = frameRate;
            VideoTimer timer = TokenizeFormat(_referenceTime);
            ReferenceFrame = ConvertVideoTimeToFrameCount(timer);
        }

        public VideoTimer TokenizeFormat(string time)
        {
            string[] timeTokens = time.Split(':', '.');

            ushort hour = Convert.ToUInt16(timeTokens[0]);
            ushort minute = Convert.ToUInt16(timeTokens[1]);
            ushort second = Convert.ToUInt16(timeTokens[2]);
            ushort frame = Convert.ToUInt16(timeTokens[3]);

            return new VideoTimer(hour, minute, second, frame);
        }

        public uint ConvertVideoTimeToFrameCount(VideoTimer timer)
        {
            uint frameCount = 0;
            frameCount += (uint)(timer.hour * 3600 + (timer.minutes * 60)
                        + (timer.seconds * FPS) + timer.frames);
            return frameCount;
        }

        public VideoTimer ConvertFrameCountToVideoTime(uint frameCount)
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

        public string FormatTokensToVideoTime(VideoTimer tokens) 
            => $"{tokens.hour}:{tokens.minutes}:{tokens.seconds}.{tokens.frames}";
        
        public int FrameOffset(string time)
        {
            VideoTimer tokens = TokenizeFormat(time);
            uint endTimeFrame = ConvertVideoTimeToFrameCount(tokens);
            return (int)(endTimeFrame - ReferenceFrame);
        }
    }
}
