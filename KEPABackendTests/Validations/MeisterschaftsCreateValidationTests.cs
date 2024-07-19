using KEPABackend.DTOs.Input;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class MeisterschaftsCreateValidationTests
{
    private MeisterschaftCreateValidator MeisterschaftCreateValidator { get; } = new MeisterschaftCreateValidator();

    [Fact]
    public void Meisterschaft_Create_Passes_Validation()
    {
        //Arrange
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftCreateValidator.Validate(meisterschaftCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Empty_Bezeichnung()
    {
        //Arrange
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = string.Empty,
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftCreateValidator.Validate(meisterschaftCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Bezeichnung"));
    }

    [Fact]
    public void Validation_Error_For_To_Long_Bezeichnung()
    {
        //Arrange
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test ",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftCreateValidator.Validate(meisterschaftCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Bezeichnung"));
    }

    [Fact]
    public void Validation_Error_For_Ende_Date_Less_Than_Beginn_Date_Bezeichnung()
    {
        //Arrange
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now,
            Ende = DateTime.Now.AddDays(-1)
        };

        //Act
        var result = MeisterschaftCreateValidator.Validate(meisterschaftCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Ende"));
    }

    [Fact]
    public void Validation_Error_For_Less_Than_0_MeisterschaftsID()
    {
        //Arrange
        var meisterschaftCreate = new MeisterschaftCreate()
        {
            Bezeichnung = "Test",
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftCreateValidator.Validate(meisterschaftCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("MeisterschaftstypID"));
    }
}