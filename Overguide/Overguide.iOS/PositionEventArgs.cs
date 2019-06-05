using System;

namespace Overguide.iOS
{
    public class PositionEventArgs
    {
        private string position { get; set; }

        public PositionEventArgs(string pos)
        {
            position = pos;
        }
    }
}