using NUnit.Framework;
using Repositories.Dtos;
using Aplication.Interfaces;
using AutoMapper;
using Domain.Entities;
using Repositories.Interfaces;
using System;
using System.Threading.Tasks;
using Moq;

namespace Aplication.Services.Tests
{
    [TestFixture]
    public class EquipmentServiceTests
    {
        private Mock<IEquipmentRepository> _mockEquipmentRepository;
        private Mock<IWorkplaceRepository> _mockWorkplaceRepository;
        private Mock<IMapper> _mockMapper;
        private EquipmentService _equipmentService;

        [SetUp]
        public void Setup()
        {
            // Initialize mock repositories and mapper
            _mockEquipmentRepository = new Mock<IEquipmentRepository>();
            _mockWorkplaceRepository = new Mock< IWorkplaceRepository >();
            _mockMapper = new Mock<IMapper>();

            // Initialize service with mock dependencies
            _equipmentService = new EquipmentService(_mockEquipmentRepository.Object, _mockMapper.Object, _mockWorkplaceRepository.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task TestAddEquipment()
        {
            // Arrange
            var equipment = new EquipmentCreateDto
            {
                Name = "Equipment 1",
                Description = "Description of Equipment 1",
                Amount = 100
            };

            // Act
            var result = await _equipmentService.AddEquipment(equipment);

            // Assert
            Assert.AreEqual(equipment.Name, result.Name);
        }


    }
}
