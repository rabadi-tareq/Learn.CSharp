using System;

namespace Experiment
{
    internal class WorkerException : Exception
    {
        public WorkerException(string message): base(message)
        {
            
        }
    }
}