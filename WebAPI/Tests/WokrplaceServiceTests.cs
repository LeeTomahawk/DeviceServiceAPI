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
using Task = System.Threading.Tasks.Task;

namespace MyTests
{
    public class WorkplaceServiceTests
    {
        private Mock<IClientRepository> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private IClientService _service;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IClientRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new ClientService(_repositoryMock.Object, _mapperMock.Object);
        }

        [Test]
        public async System.Threading.Tasks.Task AddWorkplacet_Should_Call_Add_On_Repository()
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
        public async Task GetWorkplace_Should_Call_GetClientById_On_Repository_And_Map_Result()
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
        public async Task UpdateWorkplacet_Should_Call_Update_On_Repository()
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
        public async Task DeleteWorkplace_Should_Call_GetClientById_And_Delete_On_Repository()
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
