﻿using System.ComponentModel.DataAnnotations;

namespace KEPABackend.DTOs.Post;

/// <summary>
/// DTO Post SpielBlitztunierUpdate 
/// </summary>
public record SpielBlitztunierUpdate
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    [Required] 
    public int ID { get; set; } = default!;

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

    /// <summary>
    /// Runden
    /// </summary>
    [Required] 
    public int PunkteSpieler1 { get; set; }

    /// <summary>
    /// Punkte
    /// </summary>
    [Required] 
    public int PunkteSpieler2 { get; set; }
}