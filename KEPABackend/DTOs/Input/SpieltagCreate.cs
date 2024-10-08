﻿using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post SpieltagCreate
/// </summary>
public record SpieltagCreate
{
    /// <summary>
    /// MeisterschaftsID
    /// </summary>
    [Required]
    public int MeisterschaftsID { get; set; } = default!;

    /// <summary>
    /// Spieltag
    /// </summary>
    [Required]
    public DateTime Spieltag { get; set; } = default!;
}
