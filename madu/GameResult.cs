using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{
    class GameResult
    {
        private string filePath = "C:\\Users\\Admin\\Desktop\\visual studio работы\\C-alused\\madu\\results.txt";

        public void SaveResult(string playerName, int score)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{playerName}:{score}");
            }
        }

        public void ShowResults()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Результатов пока нет!");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            var results = new List<(string playerName, int score)>();

            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    results.Add((parts[0], score));
                }
            }

            // Сортировка по убыванию очков
            results = results.OrderByDescending(r => r.score).ToList();

            Console.Clear();
            Console.WriteLine("Таблица рекордов:");
            Console.WriteLine("----------------------------");
            foreach (var result in results)
            {
                Console.WriteLine($"{result.playerName} - {result.score} очков");
            }
            Console.WriteLine("----------------------------");
        }
    }
}
