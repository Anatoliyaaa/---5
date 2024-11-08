using NUnit.Framework;
using System;

namespace TestLab4
{
    // Класс риска с его вероятностью и влиянием.
    public class Risk
    {
        public string Name { get; set; }
        public double Probability { get; set; } // Вероятность
        public double Impact { get; set; } //Влияние
        public string Comment { get; set; } //Влияние


        public Risk(string name, double probability, double impact, string comment)
        {
            Name = name;
            Probability = probability;
            Impact = impact;
            Comment = comment;
        }
    }

    public class RiskManager // Менеджер рисков
    {
        public string CalculateRiskLevel(Risk risk)
        {
            if (risk.Probability > 0.7 && risk.Impact > 0.7)
                return "Критический";
            if (risk.Probability > 0.5 || risk.Impact > 0.5)
                return "Высокий";
            return "Средний";
        }
    }
}