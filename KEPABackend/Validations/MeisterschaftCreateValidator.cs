using FluentValidation;
using KEPABackend.DTOs.Get;
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
        RuleFor(meisterschaft => meisterschaft.Bezeichnung).NotEmpty().MaximumLength(100);
        RuleFor(meisterschaft => meisterschaft.MeisterschaftstypID).NotNull().GreaterThan(0);
        RuleFor(meisterschaft => meisterschaft.Ende).GreaterThanOrEqualTo(gt => gt.Beginn).When(w => w.Ende.HasValue);
    }
}


