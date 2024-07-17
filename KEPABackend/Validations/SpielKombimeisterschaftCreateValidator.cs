using FluentValidation;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von einer Paarung fürs Kombimeisterschaft
/// </summary>
public class SpielKombimeisterschaftCreateValidator : AbstractValidator<SpielKombimeisterschaftCreate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public SpielKombimeisterschaftCreateValidator()
    {
        RuleFor(spiel => spiel.HinRückrunde).IsInEnum();
    }
}


