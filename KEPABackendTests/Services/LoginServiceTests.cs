using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Models;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEPABackendUnitTests.Services;

public class LoginServiceTests
{

    public LoginServiceTests()
    {
    }

    [Fact]
    public async Task Login_Success()
    {
        //Arrange
        var login = new Login()
        {
            Username = "Testuser",
            Password = "password"
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var loginService = new LoginService(mitgliederDBServiceMock.Object);

        //Act
        await loginService.AreCredentialsCorrectAsync(login.Username, login.Password);

        //Assert
        mitgliederDBServiceMock.Verify(mock => mock.AreCredentialsCorrectAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
    }

    [Fact]
    public async Task Login_Unauthorized()
    {
        //Arrange
        var login = new Login()
        {
            Username = "Testuser",
            Password = "password"
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.AreCredentialsCorrectAsync(It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(false);
        var loginService = new LoginService(mitgliederDBServiceMock.Object);

        //Act
        var result = await loginService.AreCredentialsCorrectAsync(login.Username, login.Password);

        //Assert
        Assert.False(result);
    }
}
