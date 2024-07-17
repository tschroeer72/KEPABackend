using FluentValidation;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von einer Paarung fürs Blitztunier
/// </summary>
public class SpielMeisterschaftUpdateValidator : AbstractValidator<SpielMeisterschaftUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielMeisterschaftUpdateValidator()
    {
        RuleFor(spiel => spiel.HolzSpieler1).GreaterThanOrEqualTo(0);
        RuleFor(spiel => spiel.HolzSpieler2).GreaterThanOrEqualTo(0);
    }
}


