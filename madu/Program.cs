using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace C_alused.madu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Устанавливаем  кодировку и размер окна
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(110, 25);
            Console.SetBufferSize(110, 25);

            while (true)
            {
                Console.Clear(); // Полностью очищаем экран
                ShowStartMenu(); // Показываем стартовое меню
                Console.Clear(); // Снова очищаем, чтобы начать игру

                int finalScore = StartGame(); // Запускаем игру

                Console.Clear(); // Чистим всё перед показом окончания игры
                ShowGameOverScreen(); // Показываем надпись "Game Over"
                Thread.Sleep(2000); // Пауза 2 секунды, чтобы игрок увидел надпись

                AskPlayerNameAndSaveResult(finalScore); // Спрашиваем имя и сохраняем результат
            }
        }

        static void ShowStartMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;

            int centerX = Console.WindowWidth / 2;
            int centerY = Console.WindowHeight / 2 - 4;

            // Массив с текстом стартового меню
            string[] lines = new string[]
            {
                "╔══════════════════════╗",
                "║                      ║",
                "║    Добро пожаловать   ║",
                "║          в             ║",
                "║        SNAKE!         ║",
                "║                      ║",
                "╚══════════════════════╝"
            };

            // Печатаем меню в центре
            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(centerX - 10, centerY + i);
                Console.Write(lines[i]);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(centerX - 14, centerY + 8);
            Console.Write("Нажмите ENTER чтобы начать");
            Console.ResetColor();

            // Ждём нажатия Enter
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

        static int StartGame()
        {
            Console.Clear();

            Walls walls = new Walls(80, 25); // Создаём стены
            walls.Draw(); // Рисуем стены

            Point p = new Point(4, 5, '▣'); // Начальная точка змейки
            Snake snake = new Snake(p, 4, Direction.RIGHT); // Создаём змейку
            snake.Draw(); // Рисуем змейку

            FoodCreator foodCreator = new FoodCreator(80, 25, '✿'); // Создаём еду
            Point food = foodCreator.CreateFood();
            food.Draw(); // Рисуем еду

            // Создаём всё необходимое для игры
            Score score = new Score();
            SpeedManager speedManager = new SpeedManager();
            LifeManager lifeManager = new LifeManager();
            Level level = new Level();

            List<Bonus> bonuses = new List<Bonus>(); // Список бонусов
            Random bonusRandom = new Random();
            DateTime lastBonusTime = DateTime.Now;

            while (true)
            {
                // Проверяем если змейка ударилась
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    lifeManager.LoseLife(); // Теряем жизнь
                    Console.Beep(300, 400); // Грустный звук

                    if (lifeManager.Lives == 0)
                        break; // Если жизней нет, конец игры
                    else
                    {
                        foreach (var point in snake.GetPoints())
                            point.Clear(); // Очищаем старую змейку

                        snake = new Snake(new Point(4, 5, '▣'), 4, Direction.RIGHT); // Новая змейка
                        snake.Draw();
                    }
                }

                // Если съели еду
                if (snake.Eat(food))
                {
                    Console.Beep(800, 100); // Радостный звук
                    food = foodCreator.CreateFood();
                    food.Draw();
                    score.AddPoint();
                    level.UpdateLevel(score.Points);

                    // Каждые 5 очков добавляем преграду
                    if (score.Points % 5 == 0)
                        walls.AddObstacle(80, 25);

                    walls.Draw();
                    snake.Draw();
                    food.Draw();
                }
                else
                {
                    snake.Move(); // Иначе просто двигаемся
                }

                // Появление бонусов каждые 10 секунд
                if (bonuses.Count == 0 && (DateTime.Now - lastBonusTime).TotalSeconds > 10)
                {
                    int chance = bonusRandom.Next(0, 2);
                    if (chance == 0)
                    {
                        BonusType type = (BonusType)bonusRandom.Next(0, 4);
                        Point bonusPoint = foodCreator.CreateFood();
                        Bonus bonus = new Bonus(bonusPoint, type);
                        bonuses.Add(bonus);

                        Console.SetCursorPosition(bonusPoint.x, bonusPoint.y);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(GetBonusSymbol(type));
                        Console.ResetColor();

                        lastBonusTime = DateTime.Now;
                    }
                }

                // Если змейка съела бонус
                for (int i = 0; i < bonuses.Count; i++)
                {
                    if (snake.GetNextPoint().IsHit(bonuses[i].Point))
                    {
                        ApplyBonus(bonuses[i], snake, speedManager, lifeManager);
                        bonuses.RemoveAt(i);
                        break;
                    }
                }

                // Убираем старые бонусы
                for (int i = 0; i < bonuses.Count; i++)
                {
                    if ((DateTime.Now - bonuses[i].SpawnTime).TotalSeconds > 10)
                    {
                        Console.SetCursorPosition(bonuses[i].Point.x, bonuses[i].Point.y);
                        Console.Write(' ');
                        bonuses.RemoveAt(i);
                        break;
                    }
                }

                Thread.Sleep(speedManager.GetCurrentSpeed(score.Points)); // Ждём перед следующим шагом

                // Обработка нажатий клавиш
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }

            Console.Beep(200, 800); // Грустный звук проигрыша
            return score.Points; // Возвращаем очки
        }

        static void ApplyBonus(Bonus bonus, Snake snake, SpeedManager speedManager, LifeManager lifeManager)
        {
            Console.Beep(1000, 150); // Звук при бонусе
            switch (bonus.Type)
            {
                case BonusType.Bomb:
                    snake.Decrease(2); // Уменьшаем змейку
                    break;
                case BonusType.Heart:
                    lifeManager.AddLife(); // Плюс жизнь
                    break;
                case BonusType.Slow:
                    speedManager.DecreaseSpeed(); // Замедляем скорость
                    break;
                case BonusType.Lightning:
                    speedManager.IncreaseSpeed(); // Ускоряем
                    break;
            }
        }
        // Функция возвращает символ, который соответствует типу бонуса
        static char GetBonusSymbol(BonusType type)
        {
            // Символы для разных бонусов
            return type switch
            {
                BonusType.Bomb => 'B',
                BonusType.Heart => '♥',
                BonusType.Slow => '*',
                BonusType.Lightning => '⚡',
                _ => '?',
            };
        }

        static void ShowGameOverScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            int centerX = Console.WindowWidth / 2 - 10;
            int centerY = Console.WindowHeight / 2 - 4;

            string[] lines =
            {
    "  ██████   █████  ███    ███ ███████ ",
    " ██       ██   ██ ████  ████ ██      ",
    " ██   ███ ███████ ██ ████ ██ █████   ",
    " ██    ██ ██   ██ ██  ██  ██ ██      ",
    "  ██████  ██   ██ ██      ██ ███████ ",
    "",
    "  ██████  ██    ██ ███████ ██████  ",
    " ██    ██ ██    ██ ██      ██   ██ ",
    " ██    ██ ██    ██ █████   ██████  ",
    " ██    ██ ██    ██ ██      ██   ██ ",
    "  ██████   ██████  ███████ ██   ██ ",
};  

            for (int i = 0; i < lines.Length; i++)
            {
                Console.SetCursorPosition(centerX, centerY + i);
                Console.WriteLine(lines[i]);
            }

            Console.ResetColor();
        }
        // Функция спрашивает имя игрока и сохраняет его результат
        static void AskPlayerNameAndSaveResult(int score)
        {
            Console.SetCursorPosition(0, 22);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Введите ваше имя: ");
            Console.ResetColor();
            string playerName = Console.ReadLine();

            GameResult gameResult = new GameResult();
            gameResult.SaveResult(playerName, score);

            Console.Clear();
            gameResult.ShowResults();

            Console.WriteLine("\nНажмите любую клавишу для новой игры...");
            Console.ReadKey(true);
        }
    }
}
