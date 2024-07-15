using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;
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

public class SpieleingabeServiceTests
{
    private IMapper Mapper { get; }
    private SpieltagCreateValidator SpieltagCreateValidator {  get; }

    public SpieleingabeServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        SpieltagCreateValidator = new SpieltagCreateValidator();
        ApplicationDbContext dbContext = new();
    }

    [Fact]
    public async Task CreateSpieltag_Success()
    {
        //Arrange
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1,
            Spieltag = DateTime.Now
        };
        
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>())).ReturnsAsync(1);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMeisterschaften());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object, 
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator);

        //Act
        var result = await spieleingabeService.CreateSpieltagAsync(spieltagCreate);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>()), Times.Once);
    }

    [Fact]
    public void MeisterschaftNotFoundException_For_Non_Existing_MeisterschaftsID_by_SpieltagCreate()
    {
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1,
            Spieltag = DateTime.Now
        };

        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>())).ReturnsAsync(1);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator);

        //Act
        async Task func() => await spieleingabeService.CreateSpieltagAsync(spieltagCreate);

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }

    [Fact]
    public async Task CloseSpieltag_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        spieleingabeDBServiceMock.Setup(mock => mock.CloseSpieltagAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator);

        //Act
        await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.CloseSpieltagAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_for_CloseSpieltag()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CloseSpieltagAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator);

        //Act
        async Task func() => await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }
}
