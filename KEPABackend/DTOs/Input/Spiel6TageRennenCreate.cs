﻿using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Input;

/// <summary>
/// DTO Post Spiel6TageRennenCreate 
/// </summary>
public record Spiel6TageRennenCreate
{
    /// <summary>
    /// SpieltagID
    /// </summary>
    [Required] 
    public int SpieltagID { get; set; }

    /// <summary>
    /// SpielerID1
    /// </summary>
    [Required] 
    public int SpielerID1 { get; set; }

    /// <summary>
    /// SpielerID2
    /// </summary>
    [Required] 
    public int SpielerID2 { get; set; }
}