using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Services;
using KEPABackend.Enums;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEPABackendUnitTests.Services;

public class SpielergebnisseServiceTests
{
    [Fact]
    public async Task GetErgebnisseNeunerRatten_Success()
    {
        //Arrange
        var lstNeunerRatten = new List<vwNeunerRatten>()
        {
            new vwNeunerRatten()
            {
                NeunerRattenID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 1,
                Vorname = "Test 1",
                Nachname = "Test 1",
                Spitzname = "Test 1",
                Neuner = 1,
                Ratten = 1
            },
            new vwNeunerRatten()
            {
                NeunerRattenID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 2,
                Vorname = "Test 2",
                Nachname = "Test 2",
                Spitzname = "Test 2",
                Neuner = 1,
                Ratten = 1
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisseNeunerRattenAsync(-1)).ReturnsAsync(lstNeunerRatten);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisseNeunerRattenAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisseNeunerRattenAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnisse6TageRennen_Success()
    {
        //Arrange
        var lst6TR = new List<vwSpiel6TageRennen>()
        {
            new vwSpiel6TageRennen()
            {
                Spiel6TageRennenID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 1,
                Spieler1Vorname = "Test 1",
                Spieler1Nachname = "Test 1",
                Spieler1Spitzname = "Test 1",
                Spieler2ID = 2,
                Spieler2Vorname = "Test 2",
                Spieler2Nachname = "Test 2",
                Spieler2Spitzname = "Test 2",
                Runden = 1,
                Punkte = 1
            },
            new vwSpiel6TageRennen()
            {
                Spiel6TageRennenID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 3,
                Spieler1Vorname = "Test 3",
                Spieler1Nachname = "Test 3",
                Spieler1Spitzname = "Test 3",
                Spieler2ID = 4,
                Spieler2Vorname = "Test 4",
                Spieler2Nachname = "Test 4",
                Spieler2Spitzname = "Test 4",
                Runden = 1,
                Punkte = 1
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisse6TageRennenAsync(-1)).ReturnsAsync(lst6TR);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisse6TageRennenAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisse6TageRennenAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnissePokal_Success()
    {
        //Arrange
        var lstPokal = new List<vwSpielPokal>()
        {
            new vwSpielPokal()
            {
                SpielPokalID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 1,
                Vorname = "Test 1",
                Nachname = "Test 1",
                Spitzname = "Test 1",
                Platzierung = 1,
            },
            new vwSpielPokal()
            {
                SpielPokalID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 2,
                Vorname = "Test 2",
                Nachname = "Test 2",
                Spitzname = "Test 2",
                Platzierung = 2,
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnissePokalAsync(-1)).ReturnsAsync(lstPokal);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnissePokalAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnissePokalAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnisseSargkegeln_Success()
    {
        //Arrange
        var lstSarg = new List<vwSpielSargkegeln>()
        {
            new vwSpielSargkegeln()
            {
                SpielSargkegelnID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 1,
                Vorname = "Test 1",
                Nachname = "Test 1",
                Spitzname = "Test 1",
                Platzierung = 1,
            },
            new vwSpielSargkegeln()
            {
                SpielSargkegelnID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                SpielerID = 2,
                Vorname = "Test 2",
                Nachname = "Test 2",
                Spitzname = "Test 2",
                Platzierung = 2,
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisseSargkegelnAsync(-1)).ReturnsAsync(lstSarg);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisseSargkegelnAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisseSargkegelnAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnisseBlitztunier_Success()
    {
        //Arrange
        var lstBlitz = new List<vwSpielBlitztunier>()
        {
            new vwSpielBlitztunier()
            {
                SpielBlitztunierID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 1,
                Spieler1Vorname = "Test 1",
                Spieler1Nachname = "Test 1",
                Spieler1Spitzname = "Test 1",
                Spieler2ID = 2,
                Spieler2Vorname = "Test 2",
                Spieler2Nachname = "Test 2",
                Spieler2Spitzname = "Test 2",
                PunkteSpieler1 = 1,
                PunkteSpieler2 = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            },
            new vwSpielBlitztunier()
            {
                SpielBlitztunierID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 3,
                Spieler1Vorname = "Test 3",
                Spieler1Nachname = "Test 3",
                Spieler1Spitzname = "Test 3",
                Spieler2ID = 4,
                Spieler2Vorname = "Test 4",
                Spieler2Nachname = "Test 4",
                Spieler2Spitzname = "Test 4",
                PunkteSpieler1 = 1,
                PunkteSpieler2 = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisseBlitztunierAsync(-1)).ReturnsAsync(lstBlitz);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisseBlitztunierAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisseBlitztunierAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnisseMeisterschaft_Success()
    {
        //Arrange
        var lstMeister = new List<vwSpielMeisterschaft>()
        {
            new vwSpielMeisterschaft()
            {
                SpielMeisterschaftID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 1,
                Spieler1Vorname = "Test 1",
                Spieler1Nachname = "Test 1",
                Spieler1Spitzname = "Test 1",
                Spieler2ID = 2,
                Spieler2Vorname = "Test 2",
                Spieler2Nachname = "Test 2",
                Spieler2Spitzname = "Test 2",
                HolzSpieler1 = 1,
                HolzSpieler2 = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            },
            new vwSpielMeisterschaft()
            {
                SpielMeisterschaftID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 3,
                Spieler1Vorname = "Test 3",
                Spieler1Nachname = "Test 3",
                Spieler1Spitzname = "Test 3",
                Spieler2ID = 4,
                Spieler2Vorname = "Test 4",
                Spieler2Nachname = "Test 4",
                Spieler2Spitzname = "Test 4",
                HolzSpieler1 = 1,
                HolzSpieler2 = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisseMeisterschaftAsync(-1)).ReturnsAsync(lstMeister);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisseMeisterschaftAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisseMeisterschaftAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetErgebnisseKombimeisterschaft_Success()
    {
        //Arrange
        var lstKombi = new List<vwSpielKombimeisterschaft>()
        {
            new vwSpielKombimeisterschaft()
            {
                SpielKombimeisterschaftID = 1,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 1,
                Spieler1Vorname = "Test 1",
                Spieler1Nachname = "Test 1",
                Spieler1Spitzname = "Test 1",
                Spieler2ID = 2,
                Spieler2Vorname = "Test 2",
                Spieler2Nachname = "Test 2",
                Spieler2Spitzname = "Test 2",
                Spieler1Punkte3bis8 = 1,
                Spieler1Punkte5Kugeln = 1,
                Spieler2Punkte3bis8 = 1,
                Spieler2Punkte5Kugeln = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            },
            new vwSpielKombimeisterschaft()
            {
                SpielKombimeisterschaftID = 2,
                MeisterschaftsID = 1,
                SpieltagID = 1,
                Spieltag = DateTime.Now,
                Spieler1ID = 3,
                Spieler1Vorname = "Test 3",
                Spieler1Nachname = "Test 3",
                Spieler1Spitzname = "Test 3",
                Spieler2ID = 4,
                Spieler2Vorname = "Test 4",
                Spieler2Nachname = "Test 4",
                Spieler2Spitzname = "Test 4",
                Spieler1Punkte3bis8 = 1,
                Spieler1Punkte5Kugeln = 1,
                Spieler2Punkte3bis8 = 1,
                Spieler2Punkte5Kugeln = 1,
                HinRückrunde = HinRückrunde.Hinrunde
            }
        };
        var spielergebnisseDBMock = new Mock<ISpielergebnisseDBService>();
        spielergebnisseDBMock.Setup(mock => mock.GetErgebnisseKombimeisterschaftAsync(-1)).ReturnsAsync(lstKombi);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetErgebnisseKombimeisterschaftAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetErgebnisseKombimeisterschaftAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }
}
