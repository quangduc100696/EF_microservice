using FoodService.DTOs;
using Infrastructure.Core.Command;
using Infrastructure.Core.Query;
using Infrastructure.Core;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniteTest.Setup
{
    public class BaseTest
    {
        protected Mock<IQueryBus> _mockQueryBus;
        protected Mock<ICommandBus> _mockCommandBus;

        [SetUp]
        public virtual void Setup()
        {
            _mockQueryBus = new Mock<IQueryBus>();
            _mockCommandBus = new Mock<ICommandBus>();
        }
    }
}
