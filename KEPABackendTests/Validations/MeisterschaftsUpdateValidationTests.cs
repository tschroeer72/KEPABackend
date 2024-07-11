using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class MeisterschaftsUpdateValidationTests
{
    private MeisterschaftUpdateValidator MeisterschaftUpdateValidator { get; } = new MeisterschaftUpdateValidator();

    [Fact]
    public void Meisterschaft_Update_Passes_Validation()
    {
        //Arrange
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftUpdateValidator.Validate(meisterschaftUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Empty_Bezeichnung()
    {
        //Arrange
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = string.Empty,
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftUpdateValidator.Validate(meisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Bezeichnung"));
    }

    [Fact]
    public void Validation_Error_For_To_Long_Bezeichnung()
    {
        //Arrange
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test Test ",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftUpdateValidator.Validate(meisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Bezeichnung"));
    }

    [Fact]
    public void Validation_Error_For_Ende_Date_Less_Than_Beginn_Date_Bezeichnung()
    {
        //Arrange
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test",
            MeisterschaftstypID = 1,
            Beginn = DateTime.Now,
            Ende = DateTime.Now.AddDays(-1)
        };

        //Act
        var result = MeisterschaftUpdateValidator.Validate(meisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Ende"));
    }

    [Fact]
    public void Validation_Error_For_Less_Than_0_MeisterschaftsID()
    {
        //Arrange
        var meisterschaftUpdate = new MeisterschaftUpdate()
        {
            ID = 1,
            Bezeichnung = "Test",
            Beginn = DateTime.Now
        };

        //Act
        var result = MeisterschaftUpdateValidator.Validate(meisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("MeisterschaftstypID"));
    }
}