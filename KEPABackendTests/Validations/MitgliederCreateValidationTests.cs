using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class MitgliederCreateValidationTests
{
    private DateTime dtTestDatum20240101_090000 = Convert.ToDateTime("2024-01-01 09:00:00");
    private DateTime dtTestDatum20241201_090000 = Convert.ToDateTime("2024-01-01 09:00:00");

    private MitgliederCreateValidator MitgliederCreateValidator { get; } = new MitgliederCreateValidator();

    [Fact]
    public void Mitglied_Create_Passes_Validation()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate(string.Empty, "Test", "Test", dtTestDatum20240101_090000);
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname= "Test",
            Nachname = "Test",
            Anrede = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Empty_Vorname()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate(string.Empty, "Test", "Test", dtTestDatum20240101_090000);
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = string.Empty,
            Nachname = "Test",
            Anrede = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Vorname"));
    }

    [Fact]
    public void Validation_Error_For_Empty_Nachname()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", string.Empty, "Test", dtTestDatum20240101_090000);
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = string.Empty,
            Anrede = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Nachname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Vorname()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("TestTestTestTestTestTestTestTestTestTestTestTestTest", "Test", "Test", dtTestDatum20240101_090000);
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            Nachname = "Test",
            Anrede = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Vorname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Nachname()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", "TestTestTestTestTestTestTestTestTestTestTestTestTest", "Test", dtTestDatum20240101_090000);
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            Anrede = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Nachname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Spitzname()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Spitzname = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Spitzname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Short_PLZ()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            PLZ = "1",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MinimumLengthValidator") && err.PropertyName.Equals("PLZ"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_PLZ()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            PLZ = "123456",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("PLZ"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Ort()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Ort = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Ort"));
    }

    [Fact]
    public void Valid_Email()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Email = "test@test.de",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Theory]
    [InlineData("test@TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest.de")]
    [InlineData("TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest@test.de")]
    public void Validation_Error_For_Too_Long_Email(string email)
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Email = email,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Email"));
    }

    [Fact]
    public void Validation_Error_For_Non_Email()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Email = "Test",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("EmailValidator") && err.PropertyName.Equals("Email"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Strasse()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Straße = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Straße"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Fax()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Fax = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Fax"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_TelefonFirma()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            TelefonFirma = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("TelefonFirma"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_TelefonMobil()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            TelefonMobil = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("TelefonMobil"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_TelefonPrivat()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            TelefonPrivat = "TestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("TelefonPrivat"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Platz()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Platz = "TestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTestTest",
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Platz"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_SpAnz()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            SpAnz = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("SpAnz"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_SpGew()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            SpGew = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("SpGew"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_SpUn()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            SpUn = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("SpUn"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_SpVerl()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            SpVerl = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("SpVerl"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_HolzGes()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            HolzGes = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("HolzGes"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_HolzMax()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            HolzMax = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("HolzMax"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_HolzMin()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            HolzMin = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("HolzMin"));
    }

    [Fact]
    public void Validation_Error_For_Greater_Than_Or_Equal_0_Punkte()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Punkte = -1,
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Punkte"));
    }

    [Fact]
    public void Validation_Error_For_MitgliedSeit_In_Future()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", DateTime.Now.AddDays(1));
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            MitgliedSeit = DateTime.Now.AddDays(1)
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("LessThanOrEqualValidator") && err.PropertyName.Equals("MitgliedSeit"));
    }

    [Fact]
    public void Validation_Error_For_MitgliedSeit_Less_Than_Geburtsdatum()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", DateTime.Now.AddDays(1));
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Geburtsdatum = DateTime.Now.AddDays(1),
            MitgliedSeit = dtTestDatum20240101_090000
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("LessThanValidator") && err.PropertyName.Equals("Geburtsdatum"));
    }

    [Fact]
    public void Validation_Error_For_PassivSeit_Greather_Than_MitgliedSeit_And_Geburtsdatum()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", DateTime.Now.AddDays(1));
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Geburtsdatum = dtTestDatum20240101_090000,
            PassivSeit = Convert.ToDateTime("2024-05-01 09:00:00"),
            MitgliedSeit = Convert.ToDateTime("2024-06-01 09:00:00")
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("PassivSeit"));
    }

    [Fact]
    public void Validation_Error_For_AusgeschiedenAm_Greather_Than_MitgliedSeit_And_Geburtsdatum()
    {
        //Arrange
        //var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", DateTime.Now.AddDays(1));
        var mitgliedCreate = new MitgliedCreate
        {
            Vorname = "Test",
            Nachname = "Test",
            Geburtsdatum = dtTestDatum20240101_090000,
            AusgeschiedenAm = Convert.ToDateTime("2024-05-01 09:00:00"),
            MitgliedSeit = Convert.ToDateTime("2024-06-01 09:00:00")
        };

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("AusgeschiedenAm"));
    }
}