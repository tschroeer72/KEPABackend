using KEPABackend.DTOs.Input;
using KEPABackend.DTOs.Output;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Services;
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
    public async Task GetAllErgebnisseNeunerRatten_Success()
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
        spielergebnisseDBMock.Setup(mock => mock.GetAllErgebnisseNeunerRattenAsync(-1)).ReturnsAsync(lstNeunerRatten);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetAllErgebnisseNeunerRattenAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetAllErgebnisseNeunerRattenAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }

    [Fact]
    public async Task GetAllErgebnisse6TageRennen_Success()
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
        spielergebnisseDBMock.Setup(mock => mock.GetAllErgebnisse6TageRennenAsync(-1)).ReturnsAsync(lst6TR);
        var spielergebnisseService = new SpielergebnisseService(spielergebnisseDBMock.Object);

        //Act
        var result = await spielergebnisseService.GetAllErgebnisse6TageRennenAsync();

        //Assert
        spielergebnisseDBMock.Verify(mock => mock.GetAllErgebnisse6TageRennenAsync(It.IsAny<int>()), Times.Once);
        Assert.Equal(2, result.Count);
    }
}
