namespace TestLab4;

public class Tests
{
 [TestFixture]
    public class RiskManagerTests
    {
        private RiskManager _riskManager;

        [SetUp]
        public void SetUp()
        {
            _riskManager = new RiskManager();
        }

        // Тесты по принципу черного ящика
        [Test]
        public void CalculateRiskLevel_WhenProbabilityAndImpactAreHigh_ReturnsCritical()
        {
            var risk = new Risk("Технические сложности", 0.8, 0.9);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Критический", result);
        }

        [Test]
        public void CalculateRiskLevel_WhenProbabilityIsMediumAndImpactIsHigh_ReturnsHigh()
        {
            var risk = new Risk("Недостаток ресурсов", 0.6, 0.8);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Высокий", result);
        }

        [Test]
        public void CalculateRiskLevel_WhenProbabilityAndImpactAreMedium_ReturnsMedium()
        {
            var risk = new Risk("Проблемы с тестированием", 0.4, 0.4);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Средний", result);
        }

        // Тесты по принципу белого ящика
        [Test]
        public void CalculateRiskLevel_WhenProbabilityIsAboveThresholdButImpactIsLow_ReturnsHigh()
        {
            var risk = new Risk("Уход ключевых сотрудников", 0.6, 0.4);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Высокий", result);
        }

        [Test]
        public void CalculateRiskLevel_WhenImpactIsAboveThresholdButProbabilityIsLow_ReturnsHigh()
        {
            var risk = new Risk("Нарушение бюджета", 0.4, 0.6);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Высокий", result);
        }

        [Test]
        public void CalculateRiskLevel_WhenProbabilityAndImpactAreBelowThreshold_ReturnsMedium()
        {
            var risk = new Risk("Конфликты в команде", 0.3, 0.3);
            var result = _riskManager.CalculateRiskLevel(risk);

            Assert.AreEqual("Средний", result);
        }
    }
}


