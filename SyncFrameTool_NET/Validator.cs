using System;
using System.Windows.Forms;
namespace SyncFrameTool_NET
{
    public static class Validator
    {
        private static bool CheckRangeMinInclusive(ushort number, ushort min, ushort max) 
            => number >= min && number < max;
        
        public static bool IsWithinRange(TextBox textBox, ushort min = 0, ushort max = 59)
           => CheckRangeMinInclusive(Convert.ToUInt16(textBox.Text), min, max);

        public static bool IsWithinRange(string text, ushort min = 0, ushort max = 59)
            => CheckRangeMinInclusive(Convert.ToUInt16(text), min, max);

        private static bool CheckIfInteger(string text) 
            => ushort.TryParse(text, out _);
        public static bool IsInteger(TextBox textBox)
            => CheckIfInteger(textBox.Text);
        
        public static bool IsInteger(string text) 
            => CheckIfInteger(text);

        public static bool IsEmpty(TextBox textBox)
            => string.IsNullOrEmpty(textBox.Text);   
    }
}
