using FoodService.Controllers;
using FoodService.DTOs;
using Infrastructure.Core;
using Infrastructure.Core.Command;
using Infrastructure.Core.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniteTest.Setup;
using static FoodService.Query.GetFoodQuery;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace UniteTest.Service
{
    [TestFixture]
    public class FoodServiceTest : BaseTest
    {
        public Mock<IQuery<FoodCreateEvent>> _mockIQuery = new Mock<IQuery<FoodCreateEvent>>();

        public override void Setup()
        {
            base.Setup();
        }

        [TestCase(1)]
        [Description("tra ra ket qua")]
        public async Task GetFoods(int id)
        {
            var result = new FoodCreateEvent
            {
                Code = "TC",
                Id = id,
                Name = "trung chien"
            };

            _mockQueryBus.Setup(p => p.Send(It.IsAny<QueryFood>(), default)).ReturnsAsync(result);

            var controller = new FoodController(_mockCommandBus.Object, _mockQueryBus.Object);

            var resultTest = await controller.GetFoods(id);

            var data = (OkObjectResult)resultTest.Result;
                
            Assert.AreEqual(result, data.Value);
        }
    }
}
