using KEPABackend.DTOs.Input;
using KEPABackend.Enums;
using FluentValidation;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class SpielKombiMeisterschaftCreateValidationTests
{
    private SpielKombimeisterschaftCreateValidator SpielKombimeisterschaftCreate { get; } = new SpielKombimeisterschaftCreateValidator();

    [Fact]
    public void SpielKombimeisterschaft_Create_Passes_Validation()
    {
        //Arrange
        var spielKombimeisterschaftCreate = new SpielKombimeisterschaftCreate()
        {
            SpieltagID = 1,
            SpielerID1 = 1,
            SpielerID2 = 1,
            HinR�ckrunde = HinR�ckrunde.Hinrunde
        }; 

        //Act
        var result = SpielKombimeisterschaftCreate.Validate(spielKombimeisterschaftCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    //[Fact]
    //public void Validation_Error_For_HinR�ckrunde_SpielKombimeisterschaftCreate()
    //{
    //    //Arrange
    //    var spielKombimeisterschaftCreate = new SpielKombimeisterschaftCreate()
    //    {
    //        SpieltagID = 1,
    //        SpielerID1 = 1,
    //        SpielerID2 = 1,
    //        HinR�ckrunde = -1
    //    };

    //    //Act
    //    var result = SpielKombimeisterschaftCreate.Validate(spielKombimeisterschaftCreate);

    //    //Assert
    //    Assert.False(result.IsValid);
    //    Assert.Single(result.Errors);
    //    Assert.Contains(result.Errors, err => err.ErrorCode.Equals("IsInEnumValidator") && err.PropertyName.Equals("HinR�ckrunde"));
    //}
}