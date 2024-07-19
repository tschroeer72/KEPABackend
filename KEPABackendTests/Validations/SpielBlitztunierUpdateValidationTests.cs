using KEPABackend.DTOs.Input;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpielBlitztunierUpdateValidationTests
{
    private SpielBlitztunierUpdateValidator SpielBlitztunierUpdateValidator { get; } = new SpielBlitztunierUpdateValidator();

    [Fact]
    public void SpielBlitztunierUpdate_Passes_Validation()
    {
        //Arrange
        SpielBlitztunierUpdate spielBlitztunierUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            PunkteSpieler1 = 1,
            PunkteSpieler2 = 1
        };

        //Act
        var result = SpielBlitztunierUpdateValidator.Validate(spielBlitztunierUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_PunkteSpieler1()
    {
        //Arrange
        SpielBlitztunierUpdate spielBlitztunierUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            PunkteSpieler1 = -1,
            PunkteSpieler2 = 1
        };

        //Act
        var result = SpielBlitztunierUpdateValidator.Validate(spielBlitztunierUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("PunkteSpieler1"));
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_PunkteSpieler2()
    {
        //Arrange
        SpielBlitztunierUpdate spielBlitztunierUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            PunkteSpieler1 = 1,
            PunkteSpieler2 = -1
        };

        //Act
        var result = SpielBlitztunierUpdateValidator.Validate(spielBlitztunierUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("PunkteSpieler2"));
    }
}