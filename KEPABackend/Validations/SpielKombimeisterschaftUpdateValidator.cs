using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das SpielKombimeisterschaftUpdate
/// </summary>
public class SpielKombimeisterschaftUpdateValidator : AbstractValidator<SpielKombimeisterschaftUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielKombimeisterschaftUpdateValidator()
    {
        RuleFor(spiel => spiel.Spieler1Punkte3bis8).GreaterThanOrEqualTo(0);
        RuleFor(spiel => spiel.Spieler1Punkte5Kugeln).GreaterThanOrEqualTo(0);
        RuleFor(spiel => spiel.Spieler2Punkte3bis8).GreaterThanOrEqualTo(0);
        RuleFor(spiel => spiel.Spieler2Punkte5Kugeln).GreaterThanOrEqualTo(0);
    }
}


