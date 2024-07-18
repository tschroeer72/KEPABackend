using KEPABackend.DTOs.Post;
using KEPABackend.Validations;
using KEPABackend.Enums;
using FluentValidation;

namespace KEPABackendUnitTests.Validation;

public class SpielKombimeisterschaftUpdateValidationTests
{
    private SpielKombimeisterschaftUpdateValidator SpielKombimeisterschaftUpdateValidator { get; } = new SpielKombimeisterschaftUpdateValidator();

    [Fact]
    public void SpielKombimeisterschaftUpdate_Passes_Validation()
    {
        //Arrange
        SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Spieler1Punkte3bis8 = 1,
            Spieler1Punkte5Kugeln = 1,
            Spieler2Punkte3bis8 = 1,
            Spieler2Punkte5Kugeln = 1,
            HinRückrunde = HinRückrunde.Hinrunde
        };

        //Act
        var result = SpielKombimeisterschaftUpdateValidator.Validate(spielKombimeisterschaftUpdate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_Spieler1Punkte3bis8()
    {
        //Arrange
        SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Spieler1Punkte3bis8 = -1,
            Spieler1Punkte5Kugeln = 1,
            Spieler2Punkte3bis8 = 1,
            Spieler2Punkte5Kugeln = 1,
            HinRückrunde = HinRückrunde.Hinrunde
        };

        //Act
        var result = SpielKombimeisterschaftUpdateValidator.Validate(spielKombimeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Spieler1Punkte3bis8"));
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_Spieler1Punkte5Kugeln()
    {
        //Arrange
        SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Spieler1Punkte3bis8 = 1,
            Spieler1Punkte5Kugeln = -1,
            Spieler2Punkte3bis8 = 1,
            Spieler2Punkte5Kugeln = 1,
            HinRückrunde = HinRückrunde.Hinrunde
        };

        //Act
        var result = SpielKombimeisterschaftUpdateValidator.Validate(spielKombimeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Spieler1Punkte5Kugeln"));
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_Spieler2Punkte3bis8()
    {
        //Arrange
        SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Spieler1Punkte3bis8 = 1,
            Spieler1Punkte5Kugeln = 1,
            Spieler2Punkte3bis8 = -1,
            Spieler2Punkte5Kugeln = 1,
            HinRückrunde = HinRückrunde.Hinrunde
        };

        //Act
        var result = SpielKombimeisterschaftUpdateValidator.Validate(spielKombimeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Spieler2Punkte3bis8"));
    }

    [Fact]
    public void Validation_Error_For_Punkte_Less_Than_0_Spieler2Punkte5Kugeln()
    {
        //Arrange
        SpielKombimeisterschaftUpdate spielKombimeisterschaftUpdate = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            Spieler1Punkte3bis8 = 1,
            Spieler1Punkte5Kugeln = 1,
            Spieler2Punkte3bis8 = 1,
            Spieler2Punkte5Kugeln = -1,
            HinRückrunde = HinRückrunde.Hinrunde
        };

        //Act
        var result = SpielKombimeisterschaftUpdateValidator.Validate(spielKombimeisterschaftUpdate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("GreaterThanOrEqualValidator") && err.PropertyName.Equals("Spieler2Punkte5Kugeln"));
    }
}