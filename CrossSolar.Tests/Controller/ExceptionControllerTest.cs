using System.Threading.Tasks;
using CrossSolar.Controllers;
using CrossSolar.Models;
using CrossSolar.Repository;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using Microsoft.EntityFrameworkCore;
using CrossSolar.Exceptions;

namespace CrossSolar.Tests.Controller
{
    public class ExceptionControllerTest
    {
        [Fact]
        public void Throw_ExpectetContentType()
        {  
            HttpStatusCodeException _exceptionCode = new HttpStatusCodeException(200);
            Assert.True(_exceptionCode.ContentType.Contains("text"));
        }
    }
}