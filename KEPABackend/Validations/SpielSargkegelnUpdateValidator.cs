using FluentValidation;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

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


