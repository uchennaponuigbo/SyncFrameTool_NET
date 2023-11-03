
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
        public ushort FPS { get; set; }

        public ManageVideoTimerFrame(ushort frameRate)
        {
            FPS = frameRate;
        }

        public int ConvertVideoTimeToFrameCount(VideoTimer timer)
        {
            int frameCount = 0;
            frameCount += (timer.hours * 3600 * FPS) + (timer.minutes * 60 * FPS)
                        + (timer.seconds * FPS) + timer.frames;
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
        
        public int FrameOffset(VideoTimer refTime, VideoTimer endTime)
        {
            int start = ConvertVideoTimeToFrameCount(refTime);
            int end = ConvertVideoTimeToFrameCount(endTime);
            return end - start;
        }
    }
}
