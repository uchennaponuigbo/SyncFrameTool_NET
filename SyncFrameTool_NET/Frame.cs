
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

        public void SetToZero() => hours = minutes = seconds = frames = 0;

        /// <summary>
        /// 0:00:00:00
        /// H:MM:SS:FF
        /// Hours:Minutes:Seconds:Frames
        /// </summary>
        public override string ToString()
        {
            return $"{hours}:" +
                $"{(minutes < 10 ? "0" + minutes : minutes)}:" +
                $"{(seconds < 10 ? "0" + seconds : seconds)}:" +
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
            return (timer.hours * 3600 * FPS) + (timer.minutes * 60 * FPS)
                        + (timer.seconds * FPS) + timer.frames;
        }

        public VideoTimer ConvertFrameCountToVideoTime(int frameCount)
        {
            frameCount = Math.Abs(frameCount);

            VideoTimer time = new VideoTimer();
            uint seconds = (uint)(frameCount / FPS); //uint because possible overflow as ushort
            time.frames = (ushort)(frameCount % FPS);
          
            if (seconds >= 60)
            {
                time.minutes = (ushort)(seconds / 60);
                seconds -= (ushort)(time.minutes * 60);
            }

            if (time.minutes >= 60)
            {
                time.hours = (ushort)(time.minutes / 60);
                time.minutes -= (ushort)(time.hours * 60);
            }
            time.seconds = (ushort)seconds;
            return time;
        }
        
        public int DeltaFrameOffset(VideoTimer refTime, VideoTimer endTime)
        {
            int start = ConvertVideoTimeToFrameCount(refTime);
            int end = ConvertVideoTimeToFrameCount(endTime);
            return end - start;
        }
    }
}
