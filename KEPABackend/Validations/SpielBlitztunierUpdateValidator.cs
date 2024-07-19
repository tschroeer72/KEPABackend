using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von einer Paarung fürs Blitztunier
/// </summary>
public class SpielBlitztunierUpdateValidator : AbstractValidator<SpielBlitztunierUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielBlitztunierUpdateValidator()
    {
        RuleFor(spiel => spiel.PunkteSpieler1).GreaterThanOrEqualTo(0);
        RuleFor(spiel => spiel.PunkteSpieler2).GreaterThanOrEqualTo(0);
    }
}


