using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WotBlitzStatisticsPro.Blazor.GraphQl;
using WotBlitzStatisticsPro.Blazor.Model;
using WotBlitzStatisticsPro.Blazor.Services;

namespace WotBlitzStatisticsPro.Blazor.Pages
{
    public class PlayerInfoTanksTreeBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<ITank> TanksList { get; set; }

        [Inject]
        public IStringLocalizer<App> Localize { get; set; }

        [Inject]
        public IMediator Mediator { get; set; }

        [Inject]
        public IMediaQueriesService MediaQueriesService { get; set; }

        [Inject]
        public ISvgHelper SvgHelper { get; set; }

        public int FrameHeigth { get; set; }

        public int CardWidth { get; } = 200;
        public int CardHeigth { get; } = 120;

        //[Obsolete("Just temporary. In the future, add this into tankTree DTO")]
        //public ElementDimensions[] BattlesTextSize { get; set; }

        public string FrameStyle
        {
            get
            {
                return $"min-height: {FrameHeigth}px; overflow-y: auto; overflow-x: auto;";
            }
        }

        protected async override Task OnInitializedAsync()
        {
            //var screenWidth = await MediaQueriesService.WindowWidth();
            var screenHeight = await MediaQueriesService.WindowHeight();

            //FrameWidth = Convert.ToInt32(((decimal)screenWidth) * 0.94m);
            FrameHeigth = screenHeight - 390;
            // TODO: This is temporary
            //var dd = new List<ElementDimensions>();
            //var tt = TanksList.ToArray();
            //for (int i = 0; i < 3; i++)
            //{
            //    var d = await SvgHelper.CalculateTextBlockSizeAsync(tt[i].Battles.ToString("N0"), "Segoe UI", 12);
            //    dd.Add(d);
            //}
            //BattlesTextSize = dd.ToArray();
            //---

        }

        public int GetTextWidth(string text, string fontFace, int fontSize)
        {
            return SvgHelper.CalculateTextBlockSize(text, fontFace, fontSize).Width;
        }
    }
}
