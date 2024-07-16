using FluentValidation;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das updaten von 9ner/Ratten
/// </summary>
public class NeunerRattenUpdateValidator : AbstractValidator<NeunerRattenUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public NeunerRattenUpdateValidator()
    {
        RuleFor(neunerRatten => neunerRatten.Neuner).GreaterThanOrEqualTo(0);
        RuleFor(neunerRatten => neunerRatten.Ratten).GreaterThanOrEqualTo(0);
    }
}


