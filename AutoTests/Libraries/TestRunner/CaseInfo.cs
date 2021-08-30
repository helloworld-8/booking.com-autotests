using System;

namespace AutoTests.Libraries.TestRunner
{
    public class CaseInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        public CaseInfo()
        {
            this.Init();
        }
        protected void Init()
        {
            Name = "Test case description not defined";
            Description = "Test case name not defined";
            Status = Status.Ready;
        }

    }
}
