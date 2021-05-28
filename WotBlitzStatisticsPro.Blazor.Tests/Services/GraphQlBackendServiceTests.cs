﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using StrawberryShake;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Tests.Services
{
    public class GraphQlBackendServiceTests
    {
        private Mock<IFindClansQuery> _findClanQueryMock;
        private Mock<IFindPlayersQuery> _findPlayersQueryMock;
        private Mock<IPlayerQuery> _playerQueryMock;
        private WotBlitzStatisticsProClient _generatedClient;
        private Mock<INotificationsService> _notificationServiceMock;
        private GraphQlBackendService _service;

        private readonly GraphQlBackendMockService _mockDataService = new(false);

        private Mock<IFindPlayersResult> _findPlayersResultMock;
        private List<IClientError> _findPlayersErrors;
        private Mock<IOperationResult<IFindPlayersResult>> _findPlayersOperationResultMock;

        private Mock<IFindClansResult> _findClansResultMock;
        private List<IClientError> _findClansErrors;
        private Mock<IOperationResult<IFindClansResult>> _findClansOperationResultMock;

        [SetUp]
        public async Task Init()
        {
            _findClanQueryMock = new();
            _findPlayersQueryMock = new();
            _playerQueryMock = new();

            await SetUpFindClans();
            await SetUpFindPlayers();

            _generatedClient =
                new WotBlitzStatisticsProClient(_findClanQueryMock.Object, _findPlayersQueryMock.Object, _playerQueryMock.Object);

            _notificationServiceMock = new();

            _service = new GraphQlBackendService(_generatedClient, _notificationServiceMock.Object);
        }

        [Test]
        public async Task ShouldCallFindPlayers()
        {
            string expectedSearch = "Foo";
            var expectedRealm = RealmType.Ru;
            _findPlayersOperationResultMock.SetupGet(r => r.Data).Returns(_findPlayersResultMock.Object);

            var players = await _service.FindPlayers(expectedSearch, expectedRealm);

            players.Should().NotBeNull();
            players.Should().NotBeEmpty();
            _findPlayersQueryMock.Verify(q => q.ExecuteAsync(expectedSearch, expectedRealm, It.IsAny<RequestLanguage>(), It.IsAny<CancellationToken>()), Times.Once);
            _notificationServiceMock.Verify(n => n.ReportError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public async Task ShouldNotifyAboutErrorIfFindPlayersFails()
        {
            string expectedSearch = "Foo";
            var expectedRealm = RealmType.Ru;

            AddErrorToResult();

            var players = await _service.FindPlayers(expectedSearch, expectedRealm);

            players.Should().BeNull();
            _findPlayersQueryMock.Verify(q => q.ExecuteAsync(expectedSearch, expectedRealm, It.IsAny<RequestLanguage>(), It.IsAny<CancellationToken>()), Times.Once);
            _notificationServiceMock.Verify(n => n.ReportError(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }


        [Test]
        public async Task ShouldCallFindClans()
        {
            string expectedSearch = "Foo";
            var expectedRealm = RealmType.Ru;
            _findClansOperationResultMock.SetupGet(r => r.Data).Returns(_findClansResultMock.Object);

            var clans = await _service.FindClans(expectedSearch, expectedRealm);

            clans.Should().NotBeNull();
            clans.Should().NotBeEmpty();
            _findClanQueryMock.Verify(q => q.ExecuteAsync(expectedSearch, expectedRealm, It.IsAny<RequestLanguage>(), It.IsAny<CancellationToken>()), Times.Once);
            _notificationServiceMock.Verify(n => n.ReportError(It.IsAny<string>(), It.IsAny<string>()), Times.Never);

        }

        [Test]
        public async Task ShouldNotifyAboutErrorIfFindClansFails()
        {
            string expectedSearch = "Foo";
            var expectedRealm = RealmType.Ru;

            AddErrorToResult();

            var players = await _service.FindClans(expectedSearch, expectedRealm);

            players.Should().BeNull();
            _findClanQueryMock.Verify(q => q.ExecuteAsync(expectedSearch, expectedRealm, It.IsAny<RequestLanguage>(), It.IsAny<CancellationToken>()), Times.Once);
            _notificationServiceMock.Verify(n => n.ReportError(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        private async Task SetUpFindPlayers()
        {
            var players = await _mockDataService.FindPlayers("foo", RealmType.Ru);

            _findPlayersErrors = new List<IClientError>();
            _findPlayersResultMock = new();
            _findPlayersOperationResultMock = new();
            _findPlayersResultMock.SetupGet(r => r.Players).Returns(players);
            _findPlayersOperationResultMock.SetupGet(r => r.Errors).Returns(_findPlayersErrors);

            _findPlayersQueryMock.Setup(q => q.ExecuteAsync(
                    It.IsAny<string>(),
                    It.IsAny<RealmType>(),
                    It.IsAny<RequestLanguage>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(_findPlayersOperationResultMock.Object);
        }

        private async Task SetUpFindClans()
        {
            var clans = await _mockDataService.FindClans("foo", RealmType.Ru);

            _findClansErrors = new List<IClientError>();
            _findClansResultMock = new();
            _findClansOperationResultMock = new();
            _findClansResultMock.SetupGet(r => r.Clans).Returns(clans);
            _findClansOperationResultMock.SetupGet(r => r.Errors).Returns(_findClansErrors);

            _findClanQueryMock.Setup(q => q.ExecuteAsync(
                    It.IsAny<string>(),
                    It.IsAny<RealmType>(),
                    It.IsAny<RequestLanguage>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(_findClansOperationResultMock.Object);
        }

        private void AddErrorToResult()
        {
            string graphQlErrorMessage = "{\"errors\": [{\"extensions\": {\"message\": \"GraphQL error message here\"}}]}";
            var errorDetails = new Dictionary<string, object?> {["error"] = graphQlErrorMessage};
            var error = new Mock<IClientError>();
            error.SetupGet(e => e.Extensions).Returns(errorDetails);
            _findPlayersErrors.Add(error.Object);
            _findClansErrors.Add(error.Object);
        }
    }
}