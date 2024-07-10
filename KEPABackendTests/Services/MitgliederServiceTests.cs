using AutoMapper;
using KEPABackend.DTOs;
using KEPABackend.Modell;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using Xunit;
using FluentValidation;
using KEPABackend.Exceptions;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Interfaces.DBServices;

namespace KEPABackendUnitTests.Services;

public class MitgliederServiceTests
{
    private IMapper Mapper { get; }
    private MitgliederCreateValidator MitgliederCreateValidator { get; }
    private MitgliederUpdateValidator MitgliederUpdateValidator { get; }

    public MitgliederServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        MitgliederCreateValidator = new MitgliederCreateValidator();
        MitgliederUpdateValidator = new MitgliederUpdateValidator();
    }

    [Fact]
    public async Task Mitglied_Created()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate()
        {
            Vorname = "Test",
            Nachname = "Test",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.CreateMitgliederAsync(It.IsAny<TblMitglieder>())).ReturnsAsync(1);
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        await mitgliederService.CreateMitgliederAsync(mitgliedCreate);

        //Assert
        mitgliederDBServiceMock.Verify(mock => mock.CreateMitgliederAsync(It.IsAny<TblMitglieder>()), Times.Once);
    }

    [Fact]
    public async Task ValidationExecption_for_Invalid_MitgliederCreate()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate()
        {
            Vorname = string.Empty,
            Nachname = "Test",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        try
        {
            await mitgliederService.CreateMitgliederAsync(mitgliedCreate);
            throw new Exception("Supposed to throw ValidationException");
        }
        catch(ValidationException ex)
        {
            string message = ex.Message;
            //Assert

        }
    }

    [Fact]
    public async Task GetAllMitglieder_Success()
    {
        //Arrange
        var lstMitglieder = new List<Mitgliederliste>()
        {
            new Mitgliederliste()
            {
                ID = 1,
                Vorname = "Test 1",
                Nachname = "Test 1",
                MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
            },
            new Mitgliederliste()
            {
                ID = 2,
                Vorname = "Test 2",
                Nachname = "Test 2",
                MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
            }
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetAllMitgliederAsync(It.IsAny<bool>())).ReturnsAsync(lstMitglieder);
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        var result = await mitgliederService.GetAllMitgliederAsync();

        //Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetMitgliedByID_Success()
    {
        //Arrange
        var mitglieder = new TblMitglieder()
        {
            Id = 1,
            Vorname = "Test 1",
            Nachname = "Test 1",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(mitglieder);
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        var result = await mitgliederService.GetMitgliedByIDAsync(mitglieder.Id);

        //Assert
        Assert.Equal(1, result.ID);
    }

    [Fact]
    public void MitgliedNotFoundExeption_for_GetMitgliedByID_with_Non_Exiting_ID()
    {
        //Arrange
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        Func<Task> func = async () => await mitgliederService.GetMitgliedByIDAsync(It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<MitgliedNotFoundException>(func);
    }

    [Fact]
    public async Task Mitglied_Updated()
    {
        //Arrange
        var mitgliedUpdate = new MitgliedUpdate()
        {
            ID = 1,
            Vorname = "Test",
            Nachname = "Test",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(new TblMitglieder());
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        await mitgliederService.UpdateMitgliederAsync(mitgliedUpdate);

        //Assert
        mitgliederDBServiceMock.Verify(mock => mock.UpdateMitgliederAsync(), Times.Once);
    }

    [Fact]
    public void ValidationExeption_For_UpdateMitglied()
    {
        //Arrange
        var mitgliedUpdate = new MitgliedUpdate()
        {
            ID = 1,
            Vorname = string.Empty,
            Nachname = "Test",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(new TblMitglieder() { Id = 1 });
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        Func<Task> func = async () => await mitgliederService.UpdateMitgliederAsync(mitgliedUpdate);

        //Assert
        Assert.ThrowsAsync<ValidationException>(func);
    }

    [Fact]
    public void MitgliedNotFoundExeption_For_UpdateMitglied_with_Non_Existing_ID()
    {
        //Arrange
        var mitgliedUpdate = new MitgliedUpdate()
        {
            ID = 1,
            Vorname = string.Empty,
            Nachname = "Test",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, MitgliederCreateValidator, MitgliederUpdateValidator);

        //Act
        Func<Task> func = async () => await mitgliederService.UpdateMitgliederAsync(mitgliedUpdate);

        //Assert
        Assert.ThrowsAsync<MitgliedNotFoundException>(func);
    }
}
