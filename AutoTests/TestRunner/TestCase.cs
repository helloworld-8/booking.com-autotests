using System;
using System.Collections.Generic;

namespace AutoTests.TestRunner
{
    public class TestCase
    {
        public void RunTestSteps(Action testStepsAction)
        {
            testStepsAction();
        }

        public void RunTestSteps<T>(Action<T> testStepsAction, T testStepsProperties)
        {
            testStepsAction(testStepsProperties);
        }

    }
}