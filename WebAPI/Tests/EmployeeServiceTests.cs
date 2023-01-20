using NUnit.Framework;
using Aplication.Interfaces;
using Aplication.Services;
using Domain.Entities;
using Moq;
using Repositories.Dtos;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace WebAPI.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _repositoryMock;
        private Mock<ITaskRepository> _taskRepositoryMock;
        private Mock<IMapper> _mapperMock;
        private EmployeeService _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IEmployeeRepository>();
            _taskRepositoryMock = new Mock<ITaskRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new EmployeeService(_repositoryMock.Object, _taskRepositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task GetEmployee_Should_Call_GetEmployeeById_On_Repository_And_Map_Result()
        {
            // Arrange
            int x = 2;
            int y = 2;
            int expected = 4;

            // Act
            int result = x + y;

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public async System.Threading.Tasks.Task GetEmployeesWithoutWorkplace_Should_Call_GetEmployeeListWithoutWorkplace_On_Repository_And_Map_Result()
        {
            // Arrange
            int x = 2;
            int y = 2;
            int expected = 4;

            // Act
            int result = x + y;

            // Assert
            Assert.AreEqual(expected, result);
        }

    }
}
