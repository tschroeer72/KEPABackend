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
        Assert.Equal(2, result.Count);
    }
}
