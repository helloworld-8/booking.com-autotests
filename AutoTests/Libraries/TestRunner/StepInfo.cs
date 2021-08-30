using System;

namespace AutoTests.Libraries.TestRunner
{
    public enum Status
    {
        Passed,
        Failed,
        Skipped,
        Ready
    }
    
    public class StepInfo
    {
        public string Description { get; set; }
        public Status Status { get; set; }

        public StepInfo()
        {
            this.Init();
        }
        protected void Init()
        {
            Description = "Step Description not defined";
            Status = Status.Ready;
        }

    }
}
