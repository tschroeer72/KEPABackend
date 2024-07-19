using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

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


