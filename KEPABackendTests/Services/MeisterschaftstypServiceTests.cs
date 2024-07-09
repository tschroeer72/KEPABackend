using AutoMapper;
using KEPABackend.DTOs.Get;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEPABackendUnitTests.Services;

public class MeisterschaftstypServiceTests
{
    [Fact]
    public async Task GetAllMeisterschaftstypen_Success()
    {
        //Arrange
        var lstMeisterschaftstypen = new List<Meisterschaftstypen>()
        {
            new Meisterschaftstypen()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new Meisterschaftstypen()
            {
                ID = 2,
                Meisterschaftstyp = "Typ 2"
            }
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftstypService = new MeisterschaftstypenService(meisterschaftstypenDBServiceMock.Object);

        //Act
        var result = await meisterschaftstypService.GetAllMeisterschaftstypenAsync();

        //Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetMeisterschaftstypByID_Success()
    {
        //Arrange
        var meisterschaftstyp = new Meisterschaftstypen()
        {
            ID = 1,
            Meisterschaftstyp = "Typ 1"
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetMeisterschaftstypByIDAsync(1)).ReturnsAsync(meisterschaftstyp);
        var meisterschaftstypService = new MeisterschaftstypenService(meisterschaftstypenDBServiceMock.Object);

        //Act
        var result = await meisterschaftstypService.GetMeisterschaftstypByIDAsync(meisterschaftstyp.ID);

        //Assert
        Assert.Equal(1, result.ID);
    }

    [Fact]
    public void MeisterschaftNotFoundExeption_for_GetMeisterschaftstypByIDAsync_with_Non_Exiting_ID()
    {
        //Arrange
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var mitgliederService = new MeisterschaftstypenService(meisterschaftstypenDBServiceMock.Object);

        //Act
        Func<Task> func = async () => await mitgliederService.GetMeisterschaftstypByIDAsync(It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }
}
