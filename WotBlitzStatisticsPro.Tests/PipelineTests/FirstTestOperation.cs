﻿using System;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Logic.Pipeline;

namespace WotBlitzStatisticsPro.Tests.PipelineTests
{
    public class FirstTestOperation: IOperation<TestContext>
    {
        public virtual Task Invoke(TestContext context, Func<TestContext, Task> next)
        {
            return Task.CompletedTask;
        }
    }
}