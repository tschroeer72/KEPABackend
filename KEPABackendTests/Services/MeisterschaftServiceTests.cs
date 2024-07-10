using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEPABackendUnitTests.Services;

public class MeisterschaftServiceTests
{
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator {  get; }

    public MeisterschaftServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        MeisterschaftCreateValidator = new MeisterschaftCreateValidator();
    }

    [Fact]
    public async Task CreateMeisterschaft_Success()
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
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test",
            MeisterschaftstypID = lstMeisterschaftstypen[0].ID,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.CreateMeisterschaftAsync(It.IsAny<TblMeisterschaften>())).ReturnsAsync(1);
        var meisterschaftService = new MeisterschaftService(meisterschaftstypenDBServiceMock.Object, meisterschaftDBServiceMock.Object, Mapper, MeisterschaftCreateValidator);

        //Act
        var result = await meisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);

        //Assert
        meisterschaftDBServiceMock.Verify(mock => mock.CreateMeisterschaftAsync(It.IsAny<TblMeisterschaften>()), Times.Once);
    }

    [Fact]
    public async Task ValidationExecption_for_Invalid_CreateMeisterschaft()
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
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = string.Empty,
            MeisterschaftstypID = lstMeisterschaftstypen[0].ID,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var meisterschaftService = new MeisterschaftService(meisterschaftstypenDBServiceMock.Object, meisterschaftDBServiceMock.Object, Mapper, MeisterschaftCreateValidator);

        //Act
        try
        {
            await meisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);
            throw new Exception("Supposed to throw ValidationException");
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            //Assert

        }
    }

    [Fact]
    public void MeisterschaftstypNotFoundException_for_Non_Existing_MeisterschaftstypID()
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
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test",
            MeisterschaftstypID = 99,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var meisterschaftService = new MeisterschaftService(meisterschaftstypenDBServiceMock.Object, meisterschaftDBServiceMock.Object, Mapper, MeisterschaftCreateValidator);

        //Act
        Func<Task> func = async () => await meisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }
}
