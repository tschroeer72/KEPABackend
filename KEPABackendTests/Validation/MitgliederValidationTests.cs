using FluentValidation;
using KEPABackend.DTOs;
using KEPABackend.Modell;
using KEPABackend.Validations;

namespace KEPABackendUnitTests.Validation;

public class MitgliederValidationTests
{
    private DateTime dtMitgliedSeit = Convert.ToDateTime("2024-01-01 09:00:00");

    private MitgliederCreateValidator MitgliederCreateValidator { get; } = new MitgliederCreateValidator();

    [Fact]
    public void Mitglied_Create_Passes_Validation()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", dtMitgliedSeit);

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.True(result.IsValid);
    }

    [Fact]
    public void Validation_Error_For_Empty_Vorname()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate(string.Empty, "Test", "Test", dtMitgliedSeit);

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Vorname"));
    }

    [Fact]
    public void Validation_Error_For_Empty_Nachname()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate("Test", string.Empty, "Test", dtMitgliedSeit);

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("NotEmptyValidator") && err.PropertyName.Equals("Nachname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Vorname()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate("TestTestTestTestTestTestTestTestTestTestTestTestTest", "Test", "Test", dtMitgliedSeit);

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Vorname"));
    }

    [Fact]
    public void Validation_Error_For_Too_Long_Nachname()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate("Test", "TestTestTestTestTestTestTestTestTestTestTestTestTest", "Test", dtMitgliedSeit);

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("MaximumLengthValidator") && err.PropertyName.Equals("Nachname"));
    }

    [Fact]
    public void Validation_Error_For_MitgliedSeit_In_Future()
    {
        //Arrange
        var mitgliedCreate = new MitgliedCreate("Test", "Test", "Test", DateTime.Now.AddDays(1));

        //Act
        var result = MitgliederCreateValidator.Validate(mitgliedCreate);

        //Assert
        Assert.False(result.IsValid);
        Assert.Single(result.Errors);
        Assert.Contains(result.Errors, err => err.ErrorCode.Equals("LessThanOrEqualValidator") && err.PropertyName.Equals("MitgliedSeit"));
    }
}