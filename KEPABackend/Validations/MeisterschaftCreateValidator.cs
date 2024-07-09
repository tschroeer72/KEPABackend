using FluentValidation;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von Mitgliedern
/// </summary>
public class MeisterschaftCreateValidator :AbstractValidator<MeisterschaftCreate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftCreateValidator()
    {
        RuleFor(meisterschaft => meisterschaft.Bezeichnung).MaximumLength(100);
        
        //RuleFor(meisterschaft => meisterschaft.Ende).GreaterThanOrEqualTo(gt => gt.Beginn);
    }
}


