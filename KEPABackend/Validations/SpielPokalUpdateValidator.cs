using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse 
/// </summary>
public class SpielPokalUpdateValidator : AbstractValidator<SpielPokalUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielPokalUpdateValidator()
    {
        RuleFor(spiel => spiel.Platzierung).GreaterThan(0);
    }
}


