using KEPABackend.DTOs.Post;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class Spiel6TageRennenUpdateValidationTests
{
    private Spiel6TageRennenUpdateValidator Spiel6TageRennenUpdateValidator { get; } = new Spiel6TageRennenUpdateValidator();

    [Fact]
    public void Spiel6TageRennenUpdate_Passes_Validation()
    {
        //Arrange
        Spiel6TageRennenUpdate spiel6TageRennenUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Runden = 1,
            Punkte = 1
        };

        //Act
        var result = Spiel6TageRennenUpdateValidator.Validate(spiel6TageRennenUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0()
    {
        //Arrange
        Spiel6TageRennenUpdate spiel6TageRennenUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Runden = 1,
            Punkte = -1
        };

        //Act
        var result = Spiel6TageRennenUpdateValidator.Validate(spiel6TageRennenUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Punkte"));
    }
}