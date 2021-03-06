﻿using System.Threading.Tasks;
using AllReady.Features.Tasks;
using AllReady.Models;
using Xunit;

namespace AllReady.UnitTest.Features.Tasks
{
    using System.Linq;

    public class AddTaskCommandHandlerAsyncTests : InMemoryContextTest
    {
        [Fact]
        public async Task HandleInvokesAddTaskAsyncWithCorrectData()
        {
            var options = this.CreateNewContextOptions();

            using (var context = new AllReadyContext(options)) {
                var sut = new AddTaskCommandHandlerAsync(context);
                var message = new AddTaskCommandAsync { AllReadyTask = new AllReadyTask() };
                await sut.Handle(message);
            }

            using (var context = new AllReadyContext(options)) {
                var tasks = context.Tasks.Count();
                Assert.Equal(tasks, 1);
            }
        }
    }
}
