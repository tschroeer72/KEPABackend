﻿using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post MeisterschaftCreate
/// </summary>
public record MeisterschaftCreate
{
    /// <summary>
    /// Bezeichnung
    /// </summary>
    [Required]
    [MaxLength(100)]
    public string Bezeichnung { get; set; } = default!;

    /// <summary>
    /// Beginn
    /// </summary>
    [Required]
    public DateTime Beginn { get; set; } = default!;

    /// <summary>
    /// Ende
    /// </summary>
    public DateTime? Ende { get; set; }


    /// <summary>
    /// MeisterschaftstypID
    /// </summary>
    [Required]
    public int MeisterschaftstypID { get; set; }

    /// <summary>
    /// Bemerkungen
    /// </summary>
    public string? Bemerkungen { get; set; }
}
