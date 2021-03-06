﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Localization;
using Radzen;
using WotBlitzStatisticsPro.Blazor.Messages;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Pages;

namespace WotBlitzStatisticsPro.Blazor.Services
{
    public class SearchDialogService: ISearchDialogService, INotificationHandler<OpenSearchDialogMessage>
    {

        private readonly DialogService _dialogService;
        private readonly IStringLocalizer<App> _localizer;

        public SearchDialogService(
            DialogService dialogService,
            IStringLocalizer<App> localizer)
        {
            _dialogService = dialogService;
            _localizer = localizer;
        }


        public async Task OpenSearchDialog(DialogType type)
        {
            await _dialogService.OpenAsync<SearchDialog>(type == DialogType.FindPlayer ? _localizer.GetString("Search player") : _localizer.GetString("Search clan"),
                new Dictionary<string, object>() { { "DialogType", type } },
                new DialogOptions() { Width = "300px", Height = "530px" });
        }

        public Task Handle(OpenSearchDialogMessage notification, CancellationToken cancellationToken)
        {
            return OpenSearchDialog(notification.Type);
        }
    }
}