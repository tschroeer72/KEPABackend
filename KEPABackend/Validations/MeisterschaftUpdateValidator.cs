using FluentValidation;
using KEPABackend.DTOs.Input;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von Mitgliedern
/// </summary>
public class MeisterschaftUpdateValidator : AbstractValidator<MeisterschaftUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public MeisterschaftUpdateValidator()
    {
        RuleFor(meisterschaft => meisterschaft.Bezeichnung).NotEmpty().MaximumLength(100);
        RuleFor(meisterschaft => meisterschaft.MeisterschaftstypID).NotNull().GreaterThan(0);
        RuleFor(meisterschaft => meisterschaft.Ende).GreaterThanOrEqualTo(gt => gt.Beginn).When(w => w.Ende.HasValue);
    }
}


