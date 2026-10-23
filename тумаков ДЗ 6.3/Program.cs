using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков_ДЗ_6._3
{
    class Program
    {
        // Названия месяцев — используются как ключи в Dictionary
        static readonly string[] Months =
        {
        "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
        "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
    };

        static void Main()
        {
            const int MonthCount = 12;
            const int DayCount = 30;
            Random rnd = new Random();

            // 1. Создаём двумерный массив temperature[12, 30] и заполняем случайными значениями
            double[,] temperature = new double[MonthCount, DayCount];
            for (int m = 0; m < MonthCount; m++)
                for (int d = 0; d < DayCount; d++)
                    temperature[m, d] = rnd.Next(-30, 36);   // диапазон от −30 до +35

            // 2. Метод вычисляет средние температуры по месяцам
            double[] monthAverages = GetMonthlyAverages(temperature);

            // 3. Формируем Dictionary: ключ — название месяца, значение — массив температур по дням
            Dictionary<string, double[]> temperatureDict = new Dictionary<string, double[]>();
            for (int m = 0; m < MonthCount; m++)
            {
                double[] days = new double[DayCount];
                for (int d = 0; d < DayCount; d++)
                    days[d] = temperature[m, d];
                temperatureDict[Months[m]] = days;
            }

            // Выводим средние температуры по месяцам (в исходном порядке)
            Console.WriteLine("Средние температуры по месяцам:");
            for (int m = 0; m < MonthCount; m++)
                Console.WriteLine($"  {Months[m],-10}: {monthAverages[m],6:F2} °C");

            // 4. Складываем средние значения в Dictionary (месяц → средняя температура)
            Dictionary<string, double> averageDict = new Dictionary<string, double>();
            for (int m = 0; m < MonthCount; m++)
                averageDict[Months[m]] = monthAverages[m];

            // 5. Сортируем Dictionary по значениям (по возрастанию средней температуры)
            var sortedAverages = averageDict.OrderBy(pair => pair.Value).ToList();

            Console.WriteLine("\nСредние температуры по возрастанию:");
            foreach (var pair in sortedAverages)
                Console.WriteLine($"  {pair.Key,-10}: {pair.Value,6:F2} °C");

            // 6. Средняя температура за год
            double yearAverage = monthAverages.Average();
            Console.WriteLine($"\nСредняя температура за год: {yearAverage:F2} °C");
        }

        // <summary>
        // Вычисляет среднюю температуру для каждого месяца.
        //</summary>
        //<param name="temperature">Двумерный массив [12, 30] значений температур</param>
        // <returns>Массив из 12 средних температур (по одной на месяц)</returns>
        static double[] GetMonthlyAverages(double[,] temperature)
        {
            int months = temperature.GetLength(0);
            int days = temperature.GetLength(1);
            double[] result = new double[months];

            for (int m = 0; m < months; m++)
            {
                double sum = 0;
                for (int d = 0; d < days; d++)
                    sum += temperature[m, d];
                result[m] = sum / days;
            }
            return result;
        }
    }
}
ц34567ш