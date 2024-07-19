using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse 
/// </summary>
public class SpielSargkegelnUpdateValidator : AbstractValidator<SpielSargkegelnUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielSargkegelnUpdateValidator()
    {
        RuleFor(spiel => spiel.Platzierung).GreaterThan(0);
    }
}


