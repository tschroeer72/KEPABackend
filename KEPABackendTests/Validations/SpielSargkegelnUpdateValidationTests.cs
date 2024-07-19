using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpielSargkegelnUpdateValidationTests
{
    private SpielSargkegelnUpdateValidator SpielSargkegelnUpdateValidator { get; } = new SpielSargkegelnUpdateValidator();

    [Fact]
    public void SpielSargkegelnUpdate_Passes_Validation()
    {
        //Arrange
        SpielSargkegelnUpdate spielSargkegelnUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Platzierung = 1
        };

        //Act
        var result = SpielSargkegelnUpdateValidator.Validate(spielSargkegelnUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Greater_Than_0_Platzierung()
    {
        //Arrange
        SpielSargkegelnUpdate spielSargkegelnUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Platzierung = 0
        };

        //Act
        var result = SpielSargkegelnUpdateValidator.Validate(spielSargkegelnUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("Platzierung"));
    }
}