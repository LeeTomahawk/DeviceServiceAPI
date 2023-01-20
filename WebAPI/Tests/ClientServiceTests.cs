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
    public class ClientServiceTests
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
        public async System.Threading.Tasks.Task AddClient_Should_Call_Add_On_Repository()
        {
            // Arrange
            var clientDto = new ClientCreateDto { FirstName = "Jan", LastName = "Kowalski" };
            var client = new Client();
            _mapperMock.Setup(x => x.Map<Client>(clientDto)).Returns(client);

            // Act
            await _service.AddClient(clientDto);

            // Assert
            _repositoryMock.Verify(x => x.Add(client), Times.Once());
        }

        [Test]
        public async Task GetClient_Should_Call_GetClientById_On_Repository_And_Map_Result()
        {
            // Arrange
            var id = Guid.NewGuid();
            var client = new Client { Id = id };
            var clientDto = new ClientDto { Id = id };
            _repositoryMock.Setup(x => x.GetClientById(id)).ReturnsAsync(client);
            _mapperMock.Setup(x => x.Map<ClientDto>(client)).Returns(clientDto);

            // Act
            var result = await _service.GetClient(id);

            // Assert
            Assert.AreEqual(clientDto, result);
            _repositoryMock.Verify(x => x.GetClientById(id), Times.Once());
            _mapperMock.Verify(x => x.Map<ClientDto>(client), Times.Once());
        }

        [Test]
        public async Task UpdateClient_Should_Call_Update_On_Repository()
        {
            // Arrange
            var clientDto = new ClientUpdateDto { Id = Guid.NewGuid() };

            // Act
            await _service.UpdateClient(clientDto);

            // Assert
            _repositoryMock.Verify(x => x.Update(clientDto), Times.Once());
        }

        [Test]
        public async Task GetClientByPhoneNumber_Should_Call_GetClientByPhoneNumber_On_Repository_And_Map_Result()
        {
            // Arrange
            var phoneNumber = "1234567890";
            var itentiti = new Identiti { PhoneNumber = phoneNumber };
            var itentitidto = new IdentitiDto { PhoneNumber = phoneNumber };
            var client1 = new Client { Id = Guid.NewGuid(), Identiti = itentiti };
            var client2 = new Client { Id = Guid.NewGuid(), Identiti = itentiti };
            var clientDto1 = new ClientDto { Id = client1.Id, Identiti = itentitidto };
            var clientDto2 = new ClientDto { Id = client2.Id, Identiti = itentitidto };
            var clients = new List<Client> { client1, client2 };
            var clientDtos = new List<ClientDto> { clientDto1, clientDto2 };
            _repositoryMock.Setup(x => x.GetClientByPhoneNumber(phoneNumber)).ReturnsAsync(clients);
            _mapperMock.Setup(x => x.Map<IEnumerable<ClientDto>>(clients)).Returns(clientDtos);

            // Act
            var result = await _service.GetClientByPhoneNumber(phoneNumber);

            // Assert
            Assert.AreEqual(clientDtos, result);
            _repositoryMock.Verify(x => x.GetClientByPhoneNumber(phoneNumber), Times.Once());
            _mapperMock.Verify(x => x.Map<IEnumerable<ClientDto>>(clients), Times.Once());
        }

        [Test]
        public async Task DeleteClient_Should_Call_GetClientById_And_Delete_On_Repository()
        {
            // Arrange
            var id = Guid.NewGuid();
            var client = new Client { Id = id };
            _repositoryMock.Setup(x => x.GetClientById(id)).ReturnsAsync(client);

            // Act
            await _service.DeleteClient(id);

            // Assert
            _repositoryMock.Verify(x => x.GetClientById(id), Times.Once());
            _repositoryMock.Verify(x => x.Delete(client), Times.Once());
        }


    }
}
