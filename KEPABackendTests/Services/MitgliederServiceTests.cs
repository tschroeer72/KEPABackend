using AutoMapper;
using KEPABackend.DTOs;
using KEPABackend.Interfaces;
using KEPABackend.Modell;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using Xunit;
using FluentValidation;

namespace KEPABackendUnitTests.Services;

public class MitgliederServiceTests
{
    private IMapper Mapper { get; }
    private MitgliederValidator Validator { get; }

    public MitgliederServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        Validator = new MitgliederValidator();
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
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, Validator);

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
        var mitgliederService = new MitgliederService(mitgliederDBServiceMock.Object, Mapper, Validator);

        //Act
        try
        {
            await mitgliederService.CreateMitgliederAsync(mitgliedCreate);
            throw new Exception("Supposed to throw ValidationException");
        }
        catch(ValidationException ex)
        {
            //Assert
            
        }
    }
}
