using KEPABackend.DTOs.Input;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpieltagCreateValidationTests
{
    private SpieltagCreateValidator SpieltagCreateValidation { get; } = new SpieltagCreateValidator();

    [Fact]
    public void Spieltag_Create_Passes_Validation()
    {
        //Arrange
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1,
            Spieltag = DateTime.Now
        };

        //Act
        var result = SpieltagCreateValidation.Validate(spieltagCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_DateTime_Min_Spieltag()
    {
        //Arrange
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1
        };

        //Act
        var result = SpieltagCreateValidation.Validate(spieltagCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("Spieltag"));
    }
}