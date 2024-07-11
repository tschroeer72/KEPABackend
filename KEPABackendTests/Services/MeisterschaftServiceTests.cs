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

public class MeisterschaftServiceTests
{
    private IMapper Mapper { get; }
    private MeisterschaftCreateValidator MeisterschaftCreateValidator {  get; }
    private MeisterschaftUpdateValidator MeisterschaftUpdateValidator { get; }
    private IMitgliederDBService MitgliederDBService {  get; }

    public MeisterschaftServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        MeisterschaftCreateValidator = new MeisterschaftCreateValidator();
        MeisterschaftUpdateValidator = new MeisterschaftUpdateValidator();
        ApplicationDbContext dbContext = new();
        MitgliederDBService = new MitgliederDBService(dbContext);
    }

    [Fact]
    public async Task CreateMeisterschaft_Success()
    {
        //Arrange
        var lstMeisterschaftstypen = new List<Meisterschaftstypen>()
        {
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
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
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator, 
            MeisterschaftUpdateValidator,
            MitgliederDBService);

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
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
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
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

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
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
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
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.CreateMeisterschaftAsync(meisterschaftCreate);

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }

    [Fact]
    public async Task UpdateMeisterschaft_Success()
    {
        //Arrange
        var lstMeisterschaftstypen = new List<Meisterschaftstypen>()
        {
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
            {
                ID = 2,
                Meisterschaftstyp = "Typ 2"
            }
        };
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test",
            MeisterschaftstypID = lstMeisterschaftstypen[0].ID,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(new TblMeisterschaften());
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        await meisterschaftService.UpdateMeisterschaftAsync(meisterschaftUpdate);

        //Assert
        meisterschaftDBServiceMock.Verify(mock => mock.UpdateMeisterschaftAsync(), Times.Once);
    }

    [Fact]
    public async Task ValidationExecption_for_Invalid_UpdateMeisterschaft()
    {
        //Arrange
        var lstMeisterschaftstypen = new List<Meisterschaftstypen>()
        {
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
            {
                ID = 2,
                Meisterschaftstyp = "Typ 2"
            }
        };
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = string.Empty,
            MeisterschaftstypID = lstMeisterschaftstypen[0].ID,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        try
        {
            await meisterschaftService.UpdateMeisterschaftAsync(meisterschaftUpdate);
            throw new Exception("Supposed to throw ValidationException");
        }
        catch (ValidationException ex)
        {
            string message = ex.Message;
            //Assert

        }
    }

    [Fact]
    public void MeisterschaftstypNotFoundException_for_Non_Existing_MeisterschaftstypID_For_UpdateMEisterschaft()
    {
        //Arrange
        var lstMeisterschaftstypen = new List<Meisterschaftstypen>()
        {
            new()
            {
                ID = 1,
                Meisterschaftstyp = "Typ 1"
            },
            new()
            {
                ID = 2,
                Meisterschaftstyp = "Typ 2"
            }
        };
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test",
            MeisterschaftstypID = 99,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        meisterschaftstypenDBServiceMock.Setup(mock => mock.GetAllMeisterschaftstypenAsync()).ReturnsAsync(lstMeisterschaftstypen);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.UpdateMeisterschaftAsync(meisterschaftUpdate);

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }

    [Fact]
    public async Task GetAllMeisterschaften_Success()
    {
        //Arrange
        var lstMeisterschaften = new List<Meisterschaft>()
        {
            new()
            {
                ID = 1,
                Bezeichnung = "Test 1",
                MeisterschaftstypID = 1,
                Aktiv = 0,
                Beginn = DateTime.Now
            },
            new()
            {
                ID = 2,
                Bezeichnung = "Test 2",
                MeisterschaftstypID = 1,
                Aktiv = 0,
                Beginn = DateTime.Now
            }
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetAllMeisterschaften()).ReturnsAsync(lstMeisterschaften);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator, 
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        var result = await meisterschaftService.GetAllMeisterschaftenAsync();

        //Assert
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetMeisterschaftByID_Success()
    {
        //Arrange
        var meisterschaft = new TblMeisterschaften()
        {
            Id = 1,
            Bezeichnung = "Test 1",
            MeisterschaftstypId = 1,
            Aktiv = 0,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(meisterschaft);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator, 
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        var result = await meisterschaftService.GetMeisterschaftByIDAsync(meisterschaft.Id);

        //Assert
        Assert.Equal(1, result.ID);
    }

    [Fact]
    public void MeisterschaftNotFoundExeption_for_GetMeisterschaftByIDAsync_with_Non_Exiting_ID()
    {
        //Arrange
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object, 
            meisterschaftDBServiceMock.Object, 
            Mapper, 
            MeisterschaftCreateValidator, 
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.GetMeisterschaftByIDAsync(It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<MeisterschaftNotFoundException>(func);
    }

    [Fact]
    public async Task Add_Teilnehmer_Success()
    {
        //Arrange
        var meisterschaft = new TblMeisterschaften()
        {
            Id = 1,
            Bezeichnung = "Test 1",
            MeisterschaftstypId = 1,
            Aktiv = 0,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(meisterschaft);
        meisterschaftDBServiceMock.Setup(mock => mock.AddTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var mitglied = new TblMitglieder()
        {
            Id = 1,
            Vorname = "Test 1",
            Nachname = "Test 1",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(mitglied);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        await meisterschaftService.AddTeilnehmerAsync(meisterschaft.Id, mitglied.Id);

        //Assert
        meisterschaftDBServiceMock.Verify(mock => mock.AddTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void MeisterschaftNotFoundExeption_For_Non_Existing_MeisterschaftsID_AddTeilnehmer()
    {
        //Arrange
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.AddTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var mitglied = new TblMitglieder()
        {
            Id = 1,
            Vorname = "Test 1",
            Nachname = "Test 1",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(mitglied);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.AddTeilnehmerAsync(It.IsAny<int>(), mitglied.Id);

        //Assert
        Assert.ThrowsAsync<MeisterschaftNotFoundException>(func);
    }

    [Fact]
    public void MitgliedNotFoundExeption_For_Non_Existing_MitgliederID_AddTeilnehmer()
    {
        //Arrange
        var meisterschaft = new TblMeisterschaften()
        {
            Id = 1,
            Bezeichnung = "Test 1",
            MeisterschaftstypId = 1,
            Aktiv = 0,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(meisterschaft);
        meisterschaftDBServiceMock.Setup(mock => mock.AddTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.AddTeilnehmerAsync(meisterschaft.Id, It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<MitgliedNotFoundException>(func);
    }

    [Fact]
    public async Task Delete_Teilnehmer_Success()
    {
        //Arrange
        var meisterschaft = new TblMeisterschaften()
        {
            Id = 1,
            Bezeichnung = "Test 1",
            MeisterschaftstypId = 1,
            Aktiv = 0,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(meisterschaft);
        meisterschaftDBServiceMock.Setup(mock => mock.DeleteTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var mitglied = new TblMitglieder()
        {
            Id = 1,
            Vorname = "Test 1",
            Nachname = "Test 1",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(mitglied);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        await meisterschaftService.DeleteTeilnehmerAsync(meisterschaft.Id, mitglied.Id);

        //Assert
        meisterschaftDBServiceMock.Verify(mock => mock.DeleteTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void MeisterschaftNotFoundExeption_For_Non_Existing_MeisterschaftsID_DeleteTeilnehmer()
    {
        //Arrange
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.DeleteTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var mitglied = new TblMitglieder()
        {
            Id = 1,
            Vorname = "Test 1",
            Nachname = "Test 1",
            MitgliedSeit = Convert.ToDateTime("2024-01-01 00:00:00")
        };
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(1)).ReturnsAsync(mitglied);
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.DeleteTeilnehmerAsync(It.IsAny<int>(), mitglied.Id);

        //Assert
        Assert.ThrowsAsync<MeisterschaftNotFoundException>(func);
    }

    [Fact]
    public void MitgliedNotFoundExeption_For_Non_Existing_MitgliederID_DeleteTeilnehmer()
    {
        //Arrange
        var meisterschaft = new TblMeisterschaften()
        {
            Id = 1,
            Bezeichnung = "Test 1",
            MeisterschaftstypId = 1,
            Aktiv = 0,
            Beginn = DateTime.Now
        };
        var meisterschaftstypenDBServiceMock = new Mock<IMeisterschaftstypenDBService>();
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(1)).ReturnsAsync(meisterschaft);
        meisterschaftDBServiceMock.Setup(mock => mock.DeleteTeilnehmerAsync(It.IsAny<int>(), It.IsAny<int>()));
        var meisterschaftService = new MeisterschaftService(
            meisterschaftstypenDBServiceMock.Object,
            meisterschaftDBServiceMock.Object,
            Mapper,
            MeisterschaftCreateValidator,
            MeisterschaftUpdateValidator,
            MitgliederDBService);

        //Act
        async Task func() => await meisterschaftService.DeleteTeilnehmerAsync(meisterschaft.Id, It.IsAny<int>());

        //Assert
        Assert.ThrowsAsync<MitgliedNotFoundException>(func);
    }
}
