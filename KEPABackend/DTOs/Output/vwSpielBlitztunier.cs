﻿using KEPABackend.Enums;

namespace KEPABackend.DTOs.Output;

/// <summary>
/// DTO Get vwSpielBlitztunier
/// </summary>
public record vwSpielBlitztunier
{
    /// <summary>
    /// ID der Entität
    /// </summary>
    public int SpielBlitztunierID { get; set; }

    /// <summary>
    /// MeisterschaftsID
    /// </summary>
    public int MeisterschaftsID { get; set; }

    /// <summary>
    /// SpieltagID
    /// </summary>
    public int SpieltagID { get; set; }

    /// <summary>
    /// Spieltag
    /// </summary>
    public DateTime Spieltag { get; set; }

    /// <summary>
    /// Spieler1ID
    /// </summary>
    public int Spieler1ID { get; set; }

    /// <summary>
    /// Vorname Spieler 1
    /// </summary>
    public string Spieler1Vorname { get; set; } = default!;

    /// <summary>
    /// Nachname Spieler 1
    /// </summary>
    public string Spieler1Nachname { get; set; } = default!;

    /// <summary>
    /// Spitzname Spieler 1
    /// </summary>
    public string Spieler1Spitzname { get; set; } = default!;

    /// <summary>
    /// Spieler2ID
    /// </summary>
    public int Spieler2ID { get; set; }

    /// <summary>
    /// Vorname Spieler 2
    /// </summary>
    public string Spieler2Vorname { get; set; } = default!;

    /// <summary>
    /// Nachname Spieler 2
    /// </summary>
    public string Spieler2Nachname { get; set; } = default!;

    /// <summary>
    /// Spitzname Spieler 2
    /// </summary>
    public string Spieler2Spitzname { get; set; } = default!;

    /// <summary>
    /// Punkte Spieler 1
    /// </summary>
    public int PunkteSpieler1 { get; set; }

    /// <summary>
    /// Punkte Spieler 2
    /// </summary>
    public int PunkteSpieler2 { get; set; }

    /// <summary>
    /// Hin-/Rückrunde
    /// </summary>
    public HinRückrunde HinRückrunde { get; set; }
}
