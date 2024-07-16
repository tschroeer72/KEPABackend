using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class NeunerRattenUpdateValidationTests
{
    private NeunerRattenUpdateValidator NeunerRattenUpdateValidator { get; } = new NeunerRattenUpdateValidator();

    [Fact]
    public void NeunerRattenUpdate_Passes_Validation()
    {
        //Arrange
        var neunerRattenUpdate = new NeunerRattenUpdate()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 1,
            Ratten = 1
        };

        //Act
        var result = NeunerRattenUpdateValidator.Validate(neunerRattenUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Neuner_Less_Than_0()
    {
        //Arrange
        var neunerRattenUpdate = new NeunerRattenUpdate()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = -1,
            Ratten = 1
        };

        //Act
        var result = NeunerRattenUpdateValidator.Validate(neunerRattenUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Neuner"));
    }

    [Fact]
    public void Validation_Error_For_Ratten_Less_Than_0()
    {
        //Arrange
        var neunerRattenUpdate = new NeunerRattenUpdate()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 1,
            Ratten = -1
        };

        //Act
        var result = NeunerRattenUpdateValidator.Validate(neunerRattenUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Ratten"));
    }
}