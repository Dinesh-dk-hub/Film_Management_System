using System;

namespace Exception_Layer
{
    public class InvalidAttemptException : Exception
    {
        public InvalidAttemptException() { }

        public InvalidAttemptException(string j)
            : base(String.Format("InvalidAttemptException"))
        {

        }
    }

}
