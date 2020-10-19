using System;
using Xunit;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebapplikasjonerOppgave1.Controllers;
using WebapplikasjonerOppgave1.DAL;
using WebapplikasjonerOppgave1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace test5
{
    public class test5
    {
        private const string _loggetInn = "loggetInn";
        private const string _ikkeLoggetInn = "";

        private readonly Mock<IBussBestillingRepository> mockRep = new Mock<IBussBestillingRepository>();
        private readonly Mock<ILogger<BestillingController>> mockLog = new Mock<ILogger<BestillingController>>();

        private readonly Mock<HttpContext> mockHttpContext = new Mock<HttpContext>();
        private readonly MockHttpSession mockSession = new MockHttpSession();


        /*
        Task<List<Stasjon>> HentAlleStasjoner(); -> Trenger ikke test? Oppgave 1
        Task<List<Turer>> HentAlleTurer();      -> Trenger ikke test? Oppgave 1
        Task<List<Stasjon>> HentEndeStasjoner(string startStasjonsNavn); -> Trenger ikke test? Oppgave 1
        Task<bool> Lagre(BussBestilling innBussBestilling); -> Trenger ikke test? Oppgave 1
        Task<bool> OpprettTur(Tur innTur);  -> Laget tester
        Task<bool> EndreTur(Tur endreTur);  -> Laget tester
        Task<bool> SlettTur(int TurId);     -> Laget tester
        Task<bool> LoggInn(Bruker bruker);  -> Laget tester
        */
        
        
        [Fact]
        public async Task HentAlleStasjoner()
        {
            // Arrange
            var stasjon1 = new Stasjon
            {
                SId = 1,
                StasjonsNavn = "Oslo",
            };
            var stasjon2 = new Stasjon
            {
                SId = 2,
                StasjonsNavn = "Bergen"
            };
            var stasjon3 = new Stasjon
            {
                SId = 3,
                StasjonsNavn = "Tromsø"
            };

            var stasjonsListe = new List<Stasjon>();
            stasjonsListe.Add(stasjon1);
            stasjonsListe.Add(stasjon2);
            stasjonsListe.Add(stasjon3);

            mockRep.Setup(s => s.HentAlleStasjoner()).ReturnsAsync(stasjonsListe);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);
            var resultat = await bestillingController.HentAlleStasjoner();
            Assert.Equal<List<Stasjon>>(stasjonsListe, resultat);
        }

        [Fact]
        public async Task HentAlleStasjonerTom()
        {
            //var stasjonsListe = new List<Stasjon>();

            mockRep.Setup(s => s.HentAlleStasjoner()).ReturnsAsync(()=>null);
            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);
            var resultat = await bestillingController.HentAlleStasjoner();
            Assert.Null(resultat);
        }

        /*

        [Fact]
        public async Task HentAlleTurerLoggetInnOK()
        {
            // Arrange
            var tur1 = new Tur
            {
                TurId = 1,
                StartStasjon = "Oslo",
                EndeStasjon = "Trondheim",
                Dato = "24/12/2020",
                Tid = "13:00",
                BarnePris = 50,
                VoksenPris = 100
            };

            var tur2 = new Tur
            {
                TurId = 2,
                StartStasjon = "Trondheim",
                EndeStasjon = "Bodø",
                Dato = "25/12/2020",
                Tid = "12:00",
                BarnePris = 200,
                VoksenPris = 500
            };

            var tur3 = new Tur
            {
                TurId = 3,
                StartStasjon = "Oslo",
                EndeStasjon = "Bodø",
                Dato = "26/12/2020",
                Tid = "10:00",
                BarnePris = 100,
                VoksenPris = 200
            };



            var turListe = new List<Tur>();
            turListe.Add(tur1);
            turListe.Add(tur2);
            turListe.Add(tur3);

            mockRep.Setup(k => k.HentAlleTurer()).ReturnsAsync(turListe);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.HentAlleTurer() as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal<List<Tur>>((List<Tur>)resultat.Value, turListe);
        }

        [Fact]
        public async Task HentAlleTurerIkkeLoggetInn()
        {
            // Arrange

            //var tomListe = new List<Tur>();

            mockRep.Setup(k => k.HentAlleTurer()).ReturnsAsync(It.IsAny<List<Tur>>());

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.HentAlleTurer() as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }*/



        [Fact]
        public async Task OpprettTurLoggetInnOK()
        {
            // Arrange
            mockRep.Setup(k => k.OpprettTur(It.IsAny<Tur>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.OpprettTur(It.IsAny<Tur>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Tur registrert", resultat.Value);
        }

        [Fact]
        public async Task OpprettTurLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(k => k.OpprettTur(It.IsAny<Tur>())).ReturnsAsync(false);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.OpprettTur(It.IsAny<Tur>()) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Turen ble ikke registrert", resultat.Value);
        }

        [Fact]
        public async Task OpprettTurLoggetInnFeilModel()
        {
            var tur1 = new Tur
            {
                TurId = 1,
                StartStasjon = "",
                EndeStasjon = "Trondheim",
                Dato = "24/12/2020",
                Tid = "13:00",
                BarnePris = 50,
                VoksenPris = 100
            };

            mockRep.Setup(k => k.OpprettTur(tur1)).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            bestillingController.ModelState.AddModelError("Startstasjon", "Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.OpprettTur(tur1) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }

        [Fact]
        public async Task OpprettTurIkkeLoggetInn()
        {
            mockRep.Setup(k => k.OpprettTur(It.IsAny<Tur>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.OpprettTur(It.IsAny<Tur>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task SlettTurLoggetInnOK()
        {
            // Arrange

            mockRep.Setup(k => k.SlettTur(It.IsAny<int>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.SlettTur(It.IsAny<int>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Tur slettet", resultat.Value);
        }

        [Fact]
        public async Task SlettTurLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(k => k.SlettTur(It.IsAny<int>())).ReturnsAsync(false);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.SlettTur(It.IsAny<int>()) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Tur ble ikke slettet", resultat.Value);
        }

        [Fact]
        public async Task SletteTurIkkeLoggetInn()
        {
            mockRep.Setup(k => k.SlettTur(It.IsAny<int>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.SlettTur(It.IsAny<int>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }


        [Fact]
        public async Task EndreTurLoggetInnOK()
        {
            // Arrange

            mockRep.Setup(k => k.EndreTur(It.IsAny<Tur>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.EndreTur(It.IsAny<Tur>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.Equal("Tur registrert", resultat.Value);
        }

        [Fact]
        public async Task EndreLoggetInnIkkeOK()
        {
            // Arrange

            mockRep.Setup(k => k.EndreTur(It.IsAny<Tur>())).ReturnsAsync(false);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.EndreTur(It.IsAny<Tur>()) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Tur ble ikke registrert", resultat.Value);
        }

        [Fact]
        public async Task EndreLoggetInnFeilModel()
        {

            var tur1 = new Tur
            {
                TurId = 1,
                StartStasjon = "",
                EndeStasjon = "Trondheim",
                Dato = "24/12/2020",
                Tid = "13:00",
                BarnePris = 50,
                VoksenPris = 100
            };

            mockRep.Setup(k => k.EndreTur(tur1)).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            bestillingController.ModelState.AddModelError("Startstasjon", "Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.EndreTur(tur1) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }

        [Fact]
        public async Task EndreIkkeLoggetInn()
        {
            mockRep.Setup(k => k.EndreTur(It.IsAny<Tur>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.EndreTur(It.IsAny<Tur>()) as UnauthorizedObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.Unauthorized, resultat.StatusCode);
            Assert.Equal("Ikke logget inn", resultat.Value);
        }

        [Fact]
        public async Task LoggInnOK()
        {
            mockRep.Setup(k => k.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.LoggInn(It.IsAny<Bruker>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.True((bool)resultat.Value);
        }

        [Fact]
        public async Task LoggInnFeilPassordEllerBruker()
        {
            mockRep.Setup(k => k.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(false);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockSession[_loggetInn] = _ikkeLoggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.LoggInn(It.IsAny<Bruker>()) as OkObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.OK, resultat.StatusCode);
            Assert.False((bool)resultat.Value);
        }

        [Fact]
        public async Task LoggInnInputFeil()
        {
            mockRep.Setup(k => k.LoggInn(It.IsAny<Bruker>())).ReturnsAsync(true);

            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            bestillingController.ModelState.AddModelError("Brukernavn", "Feil i inputvalidering på server");

            mockSession[_loggetInn] = _loggetInn;
            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            var resultat = await bestillingController.LoggInn(It.IsAny<Bruker>()) as BadRequestObjectResult;

            // Assert 
            Assert.Equal((int)HttpStatusCode.BadRequest, resultat.StatusCode);
            Assert.Equal("Feil i inputvalidering på server", resultat.Value);
        }


        [Fact]
        public async Task LagreOK()
        {


            var innBussbestilling = new BussBestilling
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Telefonnummer = "99345672",
                Epost = "PeHansen@oslomet.no",
                Kortnummer = "1234567890123456",
                AntallBarn = 2,
                AntallVoksne = 3,
                Dato = "12/12/2020",
                Tid = "09:00",
                BarnePris = 50,
                VoksenPris = 100,
                StartStasjon = "Bergen"

            };


            mockRep.Setup(k => k.Lagre(innBussbestilling)).ReturnsAsync(true);
            var bestillingController = new BestillingController(mockRep.Object);
            bool resultat = await bestillingController.Lagre(innBussbestilling);
            Assert.True(resultat);
        }



        [Fact]
        public async Task LagreIkkeOK()
        {
            var innBussbestilling = new BussBestilling
            {
                Id = 1,
                Fornavn = "Per",
                Etternavn = "Hansen",
                Telefonnummer = "99345672",
                Epost = "PeHansen@oslomet.no",
                Kortnummer = "1234567890123456",
                AntallBarn = 2,
                AntallVoksne = 3,
                Dato = "12/12/2020",
                Tid = "09:00",
                BarnePris = 50,
                VoksenPris = 100,
                StartStasjon = "Bergen"


            };

            mockRep.Setup(k => k.Lagre(innBussbestilling)).ReturnsAsync(false);
            var kundeController = new BestillingController(mockRep.Object);
            bool resultat = await bestillingController.Lagre(innBussbestilling);
            Assert.False(resultat);
        }


        /*
        [Fact]
        public void LoggUt()
        {
            var bestillingController = new BestillingController(mockRep.Object, mockLog.Object);

            mockHttpContext.Setup(s => s.Session).Returns(mockSession);
            mockSession[_loggetInn] = _loggetInn;
            bestillingController.ControllerContext.HttpContext = mockHttpContext.Object;

            // Act
            bestillingController.LoggUt();

            // Assert
            Assert.Equal(_ikkeLoggetInn, mockSession[_loggetInn]);
        }*/
    }
}
