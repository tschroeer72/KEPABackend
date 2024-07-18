using FluentValidation;
using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpielPokalUpdateValidationTests
{
    private SpielPokalUpdateValidator SpielPokalUpdateValidator { get; } = new SpielPokalUpdateValidator();

    [Fact]
    public void SpielPokalUpdate_Passes_Validation()
    {
        //Arrange
        SpielPokalUpdate spielPokalUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Platzierung = 1
        };

        //Act
        var result = SpielPokalUpdateValidator.Validate(spielPokalUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Greater_Than_0_Platzierung()
    {
        //Arrange
        SpielPokalUpdate spielPokalUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Platzierung = 0
        };

        //Act
        var result = SpielPokalUpdateValidator.Validate(spielPokalUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanValidator") && err.PropertyName.Equals("Platzierung"));
    }
}