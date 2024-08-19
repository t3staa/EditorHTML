    public static class Menu
    {
        public static void Show()
        {
            Console.Clear(); 
            Console.BackgroundColor = ConsoleColor.Blue; // Muda a cor do fundo 
            Console.ForegroundColor = ConsoleColor.Black; // Muda a cor da fonte

            DrawScreen();
            WriteOptions();

            var option = short.Parse(Console.ReadLine()!);
            HandleMenuOption(option);
        }

        public static void MenuColumns()
        {
            Console.Write("+");
            for(int i = 0; i <= 30; i++)
                Console.Write("-");

            Console.Write("+");
            Console.Write(Environment.NewLine); // Outra opção: Console.Write("\n");
        }

        public static void MenuLines()
        {
            for(int lines = 0; lines <= 10; lines++)
            {
                Console.Write("|");
                for(int i = 0; i <= 30; i++)
                    Console.Write(" ");

                Console.Write("|");
                Console.Write("\n");
            }
        }

        public static void DrawScreen()
        {
            MenuColumns();
            MenuLines();
            MenuColumns();
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3, 2);
            Console.WriteLine("Editor HTML");
            Console.SetCursorPosition(3, 3);
            Console.WriteLine("===========");
            Console.SetCursorPosition(3, 4);
            Console.WriteLine("Selecione uma opção abaixo");
            Console.SetCursorPosition(3, 6);
            Console.WriteLine("1 - Novo arquivo");
            Console.SetCursorPosition(3, 7);
            Console.WriteLine("2 - Abrir");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("3 - Sair");
            Console.SetCursorPosition(3, 10);
            Console.Write("Opção: ");

        }

        public static void HandleMenuOption(short option)
        {
            switch(option)
            {
                case 1: Console.WriteLine("Editor"); break;
                case 2: Console.WriteLine("View"); break;
                case 0: 
                {
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                }
                default: Show(); break;
            }
        }
    }
