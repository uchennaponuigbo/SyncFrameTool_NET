
namespace SyncFrameTool_NET
{
    //no need for templates since it's only going to be a string and bool
    internal struct TimeErrorPair
    {
        public bool isNotCorrect { get; set; }
        public string Message { get; set; }
        public TimeErrorPair() { isNotCorrect = false; Message = ""; }
        public TimeErrorPair(bool error, string message) { isNotCorrect = error; Message = message; }      
    }
    internal class DisplayTimeError
    {
        private TimeErrorPair[] timeErrors;
        public DisplayTimeError() => timeErrors = new TimeErrorPair[4];
        
        public void SetMessages(int index, bool isErrorCorrect, string message)
        {
            if (index > 4 || index < 0)
                return;
            timeErrors[index].isNotCorrect = isErrorCorrect;
            timeErrors[index].Message = message;
        }

        public bool AreThereInputErrors()
        {
            //if there are input errors, return true to indicate this.
            for(int i = 0; i < 4; i++)
            {
                if (timeErrors[i].isNotCorrect)
                    return true;
            }
            return false;
        }

        public override string ToString()
        {
            string data = "";
            for(int i = 0; i < timeErrors.Length; i++)
            {
                data += timeErrors[i].Message + " ";
            }
            return data.Trim();
        }
    }
}
