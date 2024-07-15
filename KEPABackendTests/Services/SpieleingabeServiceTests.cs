﻿using AutoMapper;
using FluentValidation;
using KEPABackend.DBServices;
using KEPABackend.DTOs;
using KEPABackend.DTOs.Get;
using KEPABackend.DTOs.Post;
using KEPABackend.Exceptions;
using KEPABackend.Interfaces.ControllerServices;
using KEPABackend.Interfaces.DBServices;
using KEPABackend.Modell;
using KEPABackend.Services;
using KEPABackend.Validations;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KEPABackendUnitTests.Services;

public class SpieleingabeServiceTests
{
    private IMapper Mapper { get; }
    private SpieltagCreateValidator SpieltagCreateValidator {  get; }

    public SpieleingabeServiceTests()
    {
        Mapper = new MapperConfiguration(cfg => cfg.AddMaps(typeof(DtoEntityMapperProfile))).CreateMapper();
        SpieltagCreateValidator = new SpieltagCreateValidator();
        //ApplicationDbContext dbContext = new();
    }

    [Fact]
    public async Task CreateSpieltag_Success()
    {
        //Arrange
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1,
            Spieltag = DateTime.Now
        };
        
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>())).ReturnsAsync(1);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        meisterschaftDBServiceMock.Setup(mock => mock.GetMeisterschaftByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMeisterschaften());
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        var result = await spieleingabeService.CreateSpieltagAsync(spieltagCreate);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>()), Times.Once);
    }

    [Fact]
    public void MeisterschaftNotFoundException_For_Non_Existing_MeisterschaftsID_by_SpieltagCreate()
    {
        var spieltagCreate = new SpieltagCreate()
        {
            MeisterschaftsID = 1,
            Spieltag = DateTime.Now
        };

        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CreateSpieltagAsync(It.IsAny<TblSpieltag>())).ReturnsAsync(1);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        async Task func() => await spieleingabeService.CreateSpieltagAsync(spieltagCreate);

        //Assert
        Assert.ThrowsAsync<MeisterschaftstypNotFoundException>(func);
    }

    [Fact]
    public async Task CloseSpieltag_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        spieleingabeDBServiceMock.Setup(mock => mock.CloseSpieltagAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.CloseSpieltagAsync(It.IsAny<int>()), Times.Once);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_for_CloseSpieltag()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.CloseSpieltagAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        async Task func() => await spieleingabeService.CloseSpieltagAsync(1);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public async Task GetSpieltagInBearbeitung_Success()
    {
        //Arrange
        var aktuellerSpieltag = new AktuellerSpieltag()
        {
            ID = 1,
            Spieltag = DateTime.Now
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagInBearbeitung()).ReturnsAsync(aktuellerSpieltag);
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        var result = await spieleingabeService.GetSpieltagInBearbeitung();

        //Assert
        Assert.Equal(aktuellerSpieltag.ID, result.ID);
    }

    [Fact]
    public async Task CreateNeunerRatten_Success()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        NeunerRatten neunerRatten = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 0,
            Ratten = 0
        };
        spieleingabeDBServiceMock.Setup(mock => mock.Create9erRattenAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(neunerRatten);
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        var result = await spieleingabeService.Create9erRattenAsync(1, 1);

        //Assert
        spieleingabeDBServiceMock.Verify(mock => mock.Create9erRattenAsync(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        Assert.Equal(neunerRatten.ID, result.ID);
        Assert.Equal(neunerRatten.SpieltagID, result.SpieltagID);
        Assert.Equal(neunerRatten.SpielerID, result.SpielerID);
        Assert.Equal(neunerRatten.Neuner, result.Neuner);
        Assert.Equal(neunerRatten.Ratten, result.Ratten);
    }

    [Fact]
    public void SpieltagNotFoundException_For_Non_Existing_SpieltagID_For_Create9erRatten()
    {
        //Arrange
        NeunerRatten neunerRatten = new()
        {
            ID = 1,
            SpieltagID = 1,
            SpielerID = 1,
            Neuner = 0,
            Ratten = 0
        };
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.Check9erRattenExistingAsync(It.IsAny<int>(), It.IsAny<int>())).ReturnsAsync(1);
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblSpieltag());
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(1, 1);

        //Assert
        Assert.ThrowsAsync<NeunerRattenAlreadyExistsException>(func);
    }

    [Fact]
    public void MitgliedNotFoundException_For_Non_Existing_SpielerID_For_Create9erRatten()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(1, 1);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }

    [Fact]
    public void NeunerRattenAlreadyExistsException_For_Create9erRatten()
    {
        //Arrange
        var spieleingabeDBServiceMock = new Mock<ISpieleingabeDBService>();
        spieleingabeDBServiceMock.Setup(mock => mock.GetSpieltagByIDAsync(It.IsAny<int>()));
        var meisterschaftDBServiceMock = new Mock<IMeisterschaftDBService>();
        var mitgliederDBServiceMock = new Mock<IMitgliederDBService>();
        mitgliederDBServiceMock.Setup(mock => mock.GetMitgliedByIDAsync(It.IsAny<int>())).ReturnsAsync(new TblMitglieder());
        var spieleingabeService = new SpieleingabeService(
            spieleingabeDBServiceMock.Object,
            Mapper,
            meisterschaftDBServiceMock.Object,
            SpieltagCreateValidator,
            mitgliederDBServiceMock.Object);

        //Act
        async Task func() => await spieleingabeService.Create9erRattenAsync(1, 1);

        //Assert
        Assert.ThrowsAsync<SpieltagNotFoundException>(func);
    }
}
