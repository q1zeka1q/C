using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.madu
{    
    // Класс GameResult — отвечает за сохранение и показ результатов игры
    class GameResult
    {
        private string filePath = "C:\\Users\\Admin\\Desktop\\visual studio работы\\C-alused\\madu\\results.txt";
        // Метод SaveResult — сохраняет имя игрока и его очки в файл
        public void SaveResult(string playerName, int score)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true)) // true — чтобы дописывать в файл, а не перезаписывать
            {
                writer.WriteLine($"{playerName}:{score}");
            }
        }
        // Метод ShowResults — показывает все результаты из файла, отсортированные по убыванию очков
        public void ShowResults()
        {
            if (!File.Exists(filePath)) // Проверка: если файла нет, выводим сообщение
            {
                Console.WriteLine("Результатов пока нет!");
                return;
            }

            var lines = File.ReadAllLines(filePath);  // Читаем все строки из файла
            var results = new List<(string playerName, int score)>();// Список для хранения результатов

            foreach (var line in lines)
            {
                var parts = line.Split(':'); // Разделяем имя и очки
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
