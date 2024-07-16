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

namespace KEPABackendUnitTests.Services;

public class SpieleingabeServiceTests
{
    private IMapper Mapper { get; }
    private SpieltagCreateValidator SpieltagCreateValidator {  get; }
    private NeunerRattenUpdateValidator NeunerRattenUpdateValidator { get; }

    public SpieleingabeServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        SpieltagCreateValidator = new SpieltagCreateValidator();
        NeunerRattenUpdateValidator = new NeunerRattenUpdateValidator();
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
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

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
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

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
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.CloseSpieltagAsync(It.IsAny<int>()), Times.Once);
    }


    [Fact]
    public async Task DeleteSpieltag_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        await spieleingabeService.DeleteSpieltagAsync(It.IsAny<int>());

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.DeleteSpieltagAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_For_DeleteSpieltag()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        Func<Task> func = async () => await spieleingabeService.DeleteSpieltagAsync(It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_for_CloseSpieltag()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CloseSpieltagAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        async Task func() => await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public async Task GetSpieltagInBearbeitung_Success()
    {
        //Arrange
        var aktuellerSpieltag = new AktuellerSpieltag()
        {
            ID = 1,
            Spieltag = DateTime.Now
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagInBearbeitung()).ReturnsAsync(aktuellerSpieltag);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        var result = await spieleingabeService.GetSpieltagInBearbeitung();

        //Assert
        Assert.Equal(aktuellerSpieltag.ID, result.ID);
    }

    [Fact]
    public async Task CreateNeunerRatten_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        NeunerRattenCreate neunerRattenCreate = new()
        {
            SpieltagID = 1,
            SpielerID = 1
        };
        spieleingabeDBServiceMock.Setup(mock => mock.Create9erRattenAsync(It.IsAny<Tbl9erRatten>())).ReturnsAsync(1);
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        var result = await spieleingabeService.Create9erRattenAsync(neunerRattenCreate);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.Create9erRattenAsync(It.IsAny<Tbl9erRatten>()), Times.Once);        
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_For_Create9erRatten()
    {
        //Arrange
        NeunerRattenCreate neunerRattenCreate = new()
        {
            SpieltagID = -1,
            SpielerID = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Check9erRattenExistingAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(1);
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(neunerRattenCreate);

        //Assert
        Assert.ThrowsAsync<NeunerRattenAlreadyExistsException>(func);
    }

    [Fact]
    public void MitgliedNotFoundException_For_Non_Existing_SpielerID_For_Create9erRatten()
    {
        //Arrange
        NeunerRattenCreate neunerRattenCreate = new()
        {
            SpieltagID = 1,
            SpielerID = -1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object, 
            NeunerRattenUpdateValidator);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(neunerRattenCreate);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public void NeunerRattenAlreadyExistsException_For_Create9erRatten()
    {
        //Arrange
        NeunerRattenCreate neunerRattenCreate = new()
        {
            SpieltagID = 1,
            SpielerID = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(neunerRattenCreate);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public async Task UpdateNeunerRatten_Success()
    {
        //Arrange
        NeunerRattenUpdate neunerRattenUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 1,
            Ratten = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>())).ReturnsAsync(new Tbl9erRatten());
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        var result = await spieleingabeService.Update9erRattenAsync(neunerRattenUpdate);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.Update9erRattenAsync(), Times.Once);
    }

    [Fact]
    public void NeunerRattenNotFoundException_For_Non_Existing_NeunerRattenID_for_UpdateNeunerRatten()
    {
        //Arrange
        NeunerRattenUpdate neunerRattenUpdate = new()
        {
            ID = -1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 1,
            Ratten = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>()));
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        //Act
        Func<Task> func = async () => await spieleingabeService.Update9erRattenAsync(neunerRattenUpdate);

        //Assert
        Assert.ThrowsAsync<NeunerRattenNotFoundException>(func);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_for_UpdateNeunerRatten()
    {
        //Arrange
        NeunerRattenUpdate neunerRattenUpdate = new()
        {
            ID = 1,
            SpieltagID = -1,
            SpielerID = 1,
            Neuner = 1,
            Ratten = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>())).ReturnsAsync(new Tbl9erRatten());
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        Func<Task> func = async () => await spieleingabeService.Update9erRattenAsync(neunerRattenUpdate);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public void MitgliedNotFoundException_For_Non_Existing_SpieltagID_for_UpdateNeunerRatten()
    {
        //Arrange
        NeunerRattenUpdate neunerRattenUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = -1,
            Neuner = 1,
            Ratten = 1
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>())).ReturnsAsync(new Tbl9erRatten());
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>()));
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        //Act
        Func<Task> func = async () => await spieleingabeService.Update9erRattenAsync(neunerRattenUpdate);

        //Assert
        Assert.ThrowsAsync<MitgliedNotFoundException>(func);
    }

    [Fact]
    public async Task DeleteNeunerRatten_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>())).ReturnsAsync(new Tbl9erRatten());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        await spieleingabeService.DeleteNeunerRattenAsync(It.IsAny<int>());

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.DeleteNeunerRattenAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void NeunerRattenNotFoundException_For_Non_Existing_NeunerRattenID_For_DeleteNeunerRatten()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Get9erRattenByID(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object,
            NeunerRattenUpdateValidator);

        //Act
        Func<Task> func = async () => await spieleingabeService.DeleteNeunerRattenAsync(It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<NeunerRattenNotFoundException>(func);
    }
}
