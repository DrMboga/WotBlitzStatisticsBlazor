using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.OperationContext;
using WotBlitzStatisticsPro.Logic.AccountInformationPipeline.Operations;

namespace WotBlitzStatisticsPro.Tests.OperationStepsTests
{
    [TestFixture]
    public class CalculateStatisticsOperationTest : OperationsStepsTestBase
    {
        private CalculateStatisticsOperation _operation;
        private AccountInformationPipelineContextData _contextData;

        private Dictionary<long, double> _expectedTankWn7 = new Dictionary<long, double>();

        [SetUp]
        public void Init()
        {
            InitDataAccessors();
            _operation = new CalculateStatisticsOperation(
                DictionariesDataAccessorMock.Object);

            _contextData = new AccountInformationPipelineContextData();
            FillAccountAndTanks(_contextData);
            FillExpectedTanksWn7();
        }

        [Test]
        public async Task ShouldCalculateAppropriateWn7()
        {
            var context = new OperationContext(new AccountRequest(AccountId, Realm, Language));
            context.AddOrReplace(_contextData);

            await _operation.Invoke(context, null);

            _contextData.AccountInfoHistory.AvgTier.Should().Be(7.191034482758621);
            _contextData.AccountInfoHistory.Wn7.Should().Be(1543.801045341129);

            foreach (var tankInfoHistory in _contextData.TanksHistory)
            {
                tankInfoHistory.Value.Wn7.Should().Be(_expectedTankWn7[tankInfoHistory.Key]);
            }
        }

        private void FillExpectedTanksWn7()
        {
            _expectedTankWn7[19969] = 1257.4742368961442;
            _expectedTankWn7[20753] = 1479.2527009056878;
            _expectedTankWn7[10513] = 1335.8315220064917;
            _expectedTankWn7[3633] = 1403.2080206940577;
            _expectedTankWn7[13889] = 1177.919584692924;
            _expectedTankWn7[13857] = 1207.3914817088403;
            _expectedTankWn7[20481] = 1460.9096229341453;
            _expectedTankWn7[49] = 885.334648079322;
            _expectedTankWn7[19745] = 1700.0115007383338;
            _expectedTankWn7[64801] = 1409.8375351552086;
            _expectedTankWn7[64065] = 912.5457720282066;
            _expectedTankWn7[62737] = 1099.9442609677085;
            _expectedTankWn7[5169] = 1416.8311555651755;
            _expectedTankWn7[2945] = 1321.936828442301;
            _expectedTankWn7[10769] = 1756.366095722626;
            _expectedTankWn7[21505] = 1565.0365241922777;
            _expectedTankWn7[21281] = 1461.271098453194;
            _expectedTankWn7[10001] = 1463.3184701109435;
            _expectedTankWn7[54801] = 1246.395740646064;
            _expectedTankWn7[20497] = 1562.1797289054657;
            _expectedTankWn7[53585] = 746.9852997700226;
            _expectedTankWn7[54273] = 1019.264695205361;
            _expectedTankWn7[11809] = 1642.7563200629793;
            _expectedTankWn7[11553] = 1468.2884517294874;
            _expectedTankWn7[593] = 1524.7647933910516;
            _expectedTankWn7[20049] = 1275.0884403134874;
            _expectedTankWn7[4657] = 1141.4241226196734;
            _expectedTankWn7[3121] = 1447.5927743745033;
            _expectedTankWn7[4401] = 1431.7424068930866;
            _expectedTankWn7[6705] = 2654.9969533215035;
            _expectedTankWn7[2353] = 405.5242752732695;
            _expectedTankWn7[801] = 1577.6468279052697;
            _expectedTankWn7[11025] = 1221.8557090421527;
            _expectedTankWn7[5969] = 1213.2503461803756;
            _expectedTankWn7[2321] = 1949.3224359646974;
            _expectedTankWn7[8737] = 1430.2853250772769;
            _expectedTankWn7[4689] = 1365.861303635861;
            _expectedTankWn7[8209] = 1662.393693050904;
            _expectedTankWn7[5457] = 1797.503246016517;
            _expectedTankWn7[14097] = 1415.1205566865408;
            _expectedTankWn7[3857] = 1627.3465992059669;
            _expectedTankWn7[1553] = 2134.873378307472;
            _expectedTankWn7[9249] = 1665.6473444423157;
            _expectedTankWn7[11073] = 1487.9155359028216;
            _expectedTankWn7[8049] = 1588.7625100792534;
            _expectedTankWn7[5393] = 1241.71798249068;
            _expectedTankWn7[11793] = 1395.8406668374128;
            _expectedTankWn7[8225] = 1458.9935784877462;
            _expectedTankWn7[7185] = 1709.6660423373212;
            _expectedTankWn7[12097] = 1239.1089692851986;
            _expectedTankWn7[4993] = 2425.6513987658413;
            _expectedTankWn7[7201] = 1838.404800235748;
            _expectedTankWn7[10817] = 1654.6653276053528;
            _expectedTankWn7[17] = 1793.0082687642428;
            _expectedTankWn7[3361] = 2183.2365308582357;
            _expectedTankWn7[2897] = 1554.0943507190375;
            _expectedTankWn7[1041] = 1567.0343944089416;
            _expectedTankWn7[1105] = 1439.193190859959;
            _expectedTankWn7[2129] = 1658.7338405959958;
            _expectedTankWn7[11585] = 1635.061287799197;
            _expectedTankWn7[6945] = 1619.0991034642295;
            _expectedTankWn7[17425] = 1346.4376859449808;
            _expectedTankWn7[1809] = 1231.1825055791373;
            _expectedTankWn7[10049] = 1647.018567383955;
            _expectedTankWn7[5409] = 1695.498436870833;
            _expectedTankWn7[10273] = 1743.2180387821902;
            _expectedTankWn7[849] = 1505.687700381712;
            _expectedTankWn7[9793] = 1230.054134651656;
            _expectedTankWn7[5153] = 2661.6632312029014;
            _expectedTankWn7[4369] = 3524.7012391482517;
            _expectedTankWn7[7505] = 2735.2066182490653;
            _expectedTankWn7[321] = 2764.189396366907;
            _expectedTankWn7[7761] = 2428.8114326139516;
            _expectedTankWn7[785] = 2551.3754316824043;
            _expectedTankWn7[289] = 1660.4991870311142;
            _expectedTankWn7[5953] = 2217.300182210282;
            _expectedTankWn7[2065] = 1757.5480391121407;
            _expectedTankWn7[6993] = 1964.5792598993119;
            _expectedTankWn7[15937] = 2216.3984069010785;
            _expectedTankWn7[1825] = 1886.6548546700287;
        }
    }
}