namespace lesson
{
    class Game
    {
        private const int _row = 3;                                              //поля
        private const int _col = 3;                                              //колонки
        private char[,] _field = new char[_row, _col];                           //массив игрового поля
        private char _id;                                                        //переменная, которая облегчит проверку на сответствие
        public void GameFieldInitialization(char a, ref int line, ref int col)   //метод инициализации игрового поля
        {
            if (line <= 3 && line > 0 && col <= 3 && col > 0)                    //проверка что бы не выйти за пределы массива
                if (a == 'x' || a == 'o')
                    _field[line - 1, col - 1] = a;                               //инициализируем массив переменной a, если условия соответствуют
                else Console.WriteLine("вы ввели неправельный символ, должен быть либо x либо o");
            else Console.WriteLine("вы вышлт за пределы игрового поля");

            _id = a;                                                             //это облегчит проверку на сответствие
        }
        public void Gamev(char a, int b)                                         //метод инициализации ячейки игрового поля от 1 до 9
        {

        }
        public void ZeroFiledInitialization()                                    //заполнить массив пустыми значениями, что бы игровое поле не съезжало
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    _field[i, j] = ' ';
                }
            }
        }
        public void Show()                                                       //метод выводит на экран игровое поле
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                for (int j = 0; j < _field.GetLength(1); j++)
                {
                    Console.Write(_field[i, j]);
                }
                Console.WriteLine();
            }
        }
        public void Matches()                                                    //метод который ищет совпадения на игровом поле
        {
            for (int i = 0; i < _field.GetLength(0); i++)
            {
                if (_field[i, 0] == _id && _field[i, 1] == _id && _field[i, 2] == _id)  //проверка по горизонтале
                {
                    Console.WriteLine($"выиграл: {_id}");
                    break;
                }
                else if (_field[0, i] == _id && _field[1, i] == _id && _field[2, i] == _id) //проверка по вертикале
                {
                    Console.WriteLine($"выиграл: {_id}");
                    break;
                }
            }
            if (_field[0, 0] == _id && _field[1, 1] == _id && _field[2, 2] == _id || _field[0, 2] == _id && _field[1, 1] == _id && _field[2, 0] == _id)
            {
                Console.WriteLine($"выиграл: {_id}");
            }
        }
    }
    class Program
    {
        static void Main()
        {

            Game game = new Game();
            game.ZeroFiledInitialization();

            while (true)
            {
                Console.WriteLine("Введите крестик или нолик, а затем ппозицию (линии и столбы от 1 до 3)");
                int line, col;
                int.TryParse(Console.ReadLine(), out line);
                int.TryParse(Console.ReadLine(), out col);
                char a = Convert.ToChar(Console.ReadLine());
                game.GameFieldInitialization(a, ref line, ref col);
                game.Show();
                game.Matches();
            }
        }
    }
}