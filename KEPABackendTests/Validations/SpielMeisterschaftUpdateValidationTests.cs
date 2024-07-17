using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpielMeisterschaftUpdateValidationTests
{
    private SpielMeisterschaftUpdateValidator SpielMeisterschaftUpdateValidator { get; } = new SpielMeisterschaftUpdateValidator();

    [Fact]
    public void SpielMeisterschaftUpdate_Passes_Validation()
    {
        //Arrange
        SpielMeisterschaftUpdate spielMeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            HolzSpieler1 = 1,
            HolzSpieler2 = 1
        };

        //Act
        var result = SpielMeisterschaftUpdateValidator.Validate(spielMeisterschaftUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_HolzSpieler1()
    {
        //Arrange
        SpielMeisterschaftUpdate spielMeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            HolzSpieler1 = -1,
            HolzSpieler2 = 1
        };

        //Act
        var result = SpielMeisterschaftUpdateValidator.Validate(spielMeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("HolzSpieler1"));
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_HolzSpieler2()
    {
        //Arrange
        SpielMeisterschaftUpdate spielMeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            HolzSpieler1 = 1,
            HolzSpieler2 = -1
        };

        //Act
        var result = SpielMeisterschaftUpdateValidator.Validate(spielMeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("HolzSpieler2"));
    }
}