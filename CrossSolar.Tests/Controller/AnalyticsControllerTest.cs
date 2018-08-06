using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CrossSolar.Domain;

namespace CrossSolar.Tests.Controller
{
    public class AnalyticsControllerTest
    {       
        public AnalyticsControllerTest()
        {
            _analyticsController = new AnalyticsController(_analyticsRepositoryMock.Object, _panelRepositoryMock.Object);
        }

        private const string PanelId = "AAAAA";
        private readonly AnalyticsController _analyticsController;
        private readonly PanelController _panelController;
        private readonly Mock<IAnalyticsRepository> _analyticsRepositoryMock = new Mock<IAnalyticsRepository>();
        private readonly Mock<IPanelRepository> _panelRepositoryMock = new Mock<IPanelRepository>();

        [Fact]
        public async Task Post_ShouldInsertOneHourElectricity()
        {
            var oneHourElec = new OneHourElectricityModel
            {
                KiloWatt = 5510,
                DateTime = DateTime.Now,
                Id = 0
            };
            // Arrange

            // Act
            var result = await _analyticsController.Post("12",oneHourElec);

            // Assert
            Assert.NotNull(result);

            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.Equal(201, createdResult.StatusCode);
        }

        [Fact]
        public void Get_ShouldReturnPanelAnalytics()
        {
            // Arrange
            
            // Act
            var _actionResult = _analyticsController.Get("AAAAA");
           
            // Assert
            Assert.NotNull(_actionResult);
        }

        [Fact]
        public void Get_ShouldReturnPanelAnalyticsDay()
        {

            // Arrange
            
            // Act
            var _actionResult = _analyticsController.DayResults("12");

            // Assert
            Assert.NotNull(_actionResult);
        }

        [Fact]
        public void Eval_TypeModelOneDayElectricity()
        {
            var _pruebas = new  Domain.OneDayElectricityModel{
                Sum = 0,
                Average = 0,
                Maximum = 0,
                Minimum = 0,
                DateTime  = DateTime .Now
            };

            Assert.NotNull(_pruebas);
            
        }

        [Fact]
        public void Eval_TypeModelOneHourElectricity()
        {  
            List<OneHourElectricityModel> _pruebas1 = new List<OneHourElectricityModel>();
            _pruebas1.Add(new OneHourElectricityModel{
                Id = 0,
                KiloWatt = 2000,
                DateTime = DateTime.Now
            });

            var _pruebas = new OneHourElectricityListModel
            {
                OneHourElectricitys = _pruebas1
            };

            Assert.NotNull(_pruebas);
        }

        [Fact]
        public void Eval_TypeModelAnalyticsRepository()
        {  
            var optionsBuilder = new DbContextOptionsBuilder<CrossSolarDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CrossSolarDb;Trusted_Connection=True;");
            
            CrossSolarDbContext _context = new CrossSolarDbContext(optionsBuilder.Options); 
            Repository.AnalyticsRepository _pruebas = new Repository.AnalyticsRepository(_context);

            var _res = _pruebas.Query();


            Assert.NotNull(_res);
        }

        [Fact]
        public void Eval_TypeModelDayAnalyticsRepository()
        {  
            var optionsBuilder = new DbContextOptionsBuilder<CrossSolarDbContext>();
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=CrossSolarDb;Trusted_Connection=True;");
            
            CrossSolarDbContext _context = new CrossSolarDbContext(optionsBuilder.Options); 
            Repository.DayAnalyticsRepository _pruebas = new Repository.DayAnalyticsRepository(_context);

            var _res = _pruebas.Query();


            Assert.NotNull(_res);
        }
    }
}