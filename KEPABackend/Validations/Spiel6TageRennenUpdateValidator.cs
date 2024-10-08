﻿using FluentValidation;
using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;

namespace KEPABackend.Validations;

/// <summary>
/// Validatorklasse für das Anlegen von einer Mannschaft für ein 6-Rage-Rennen
/// </summary>
public class Spiel6TageRennenUpdateValidator : AbstractValidator<Spiel6TageRennenUpdate>
{
    /// <summary>
    /// Constructor
    /// </summary>
    public Spiel6TageRennenUpdateValidator()
    {
        RuleFor(spiel => spiel.Punkte).GreaterThanOrEqualTo(0);
    }
}


