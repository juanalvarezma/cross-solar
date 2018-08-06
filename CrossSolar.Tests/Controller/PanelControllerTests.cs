using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using CrossSolar.Domain;

namespace CrossSolar.Tests.Controller
{
    public class PanelControllerTests
    {
        public PanelControllerTests()
        {
            _panelController = new PanelController(_panelRepositoryMock.Object);
        }

        private readonly PanelController _panelController;

        private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        [Fact]
        public async Task Register_ShouldInsertPanel()
        {
            var panel = new PanelModel
            {
                Brand = "Areva",
                Latitude = 12.345678,
                Longitude = 98.7655432,
                Serial = "AAAA1111BBBB2222",
                Id= 0 
            };

            // Arrange

            // Act
            var result = await _panelController.Register(panel);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public void Get_RecordsPanelInserted()
        {  
            var optionsBuilder = new DbContextOptionsBuilder<CrossSolarDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CrossSolarDb;Trusted_Connection=True;");
            
            CrossSolarDbContext _context = new CrossSolarDbContext(optionsBuilder.Options); 
            Repository.PanelRepository _pruebas = new Repository.PanelRepository(_context);

            var _res = _pruebas.Query();
            Assert.NotNull(_res);
        }
    }
}