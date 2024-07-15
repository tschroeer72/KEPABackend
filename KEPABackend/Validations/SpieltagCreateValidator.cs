using FluentValidation;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von Mitgliedern
/// </summary>
public class SpieltagCreateValidator : AbstractValidator<SpieltagCreate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpieltagCreateValidator()
    {
        RuleFor(spieltag => spieltag.Spieltag).GreaterThan(new DateTime(1, 1, 1, 0, 0, 0));
        
    }
}


