using ApiWebshop.Controllers;
using ApiWebshop.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Security.Claims;
using Xunit;

namespace ApiWebshop.Tests
{
    public class AuthentificationControllerTests
    {
        private readonly Mock<InterfaceJwtAuthentificationService> _mockAuthService;
        private readonly IConfiguration _mockConfig;

        public AuthentificationControllerTests()
        {
            _mockAuthService = new Mock<InterfaceJwtAuthentificationService>();
            _mockConfig = new ConfigurationBuilder().AddInMemoryCollection(new Dictionary<string, string>{{ "Jwt:Key", "mysecretkey" }}).Build();
        }

        [Fact]
        public void Login_ReturnsOk_WithValidCredentials()
        {
            // Arrange
            var controller = new AuthentificationController(_mockAuthService.Object, _mockConfig);
            var model = new ConnexionModel { Email = "admin@gmail.com", Password = "Epsi2023" };
            var claims = new List<Claim> { new Claim(ClaimTypes.Email, model.Email) };
            var token = "myjwttoken";
            _mockAuthService.Setup(s => s.Authenticate(model.Email, model.Password)).Returns(new Utilisateur { Email = model.Email });
            _mockAuthService.Setup(s => s.GenerateToken(_mockConfig["Jwt:Key"], claims)).Returns(token);

            // Act
            var result = controller.Login(model);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualToken = Assert.IsType<string>(okResult.Value);
            Assert.Equal(token, actualToken);
        }

        [Fact]
        public void Login_ReturnsUnauthorized_WithInvalidCredentials()
        {
            // Arrange
            var controller = new AuthentificationController(_mockAuthService.Object, _mockConfig);
            var model = new ConnexionModel { Email = "invalid@gmail.com", Password = "invalidpassword" };
            _mockAuthService.Setup(s => s.Authenticate(model.Email, model.Password)).Returns((Utilisateur)null);

            // Act
            var result = controller.Login(model);

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}
