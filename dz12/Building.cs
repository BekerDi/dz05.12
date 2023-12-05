using System;
namespace bank
{
    // Используем наш атрибут для класса Building
    [DeveloperInfo("Диана", "КФУ")]

    public class Building

    {
        private static int _lastBuildingNumber = 0;
        private readonly int _buildingNumber;
        private double _height;
        private int _floors;
        private int _apartments;
        private int _entrances;

        public Building()
        {
            _buildingNumber = ++_lastBuildingNumber;
        }

        // Уникальный номер здания доступен только для чтения
        public int BuildingNumber => _buildingNumber;

        // Свойство для высоты здания
        public double Height
        {
            get { return _height; }
            set { _height = value; }
        }

        // Свойство для количества этажей
        public int Floors
        {
            get { return _floors; }
            set { _floors = value; }
        }

        // Свойство для количества отделов
        public int Apartments
        {
            get { return _apartments; }
            set { _apartments = value; }
        }

        // Свойство для количества подъездов
        public int Entrances
        {
            get { return _entrances; }
            set { _entrances = value; }
        }

        // Свойства 
        public double FloorHeight => _floors > 0 ? _height / _floors : 0;
        public int ApartmentsPerEntrance => _entrances > 0 ? _apartments / _entrances : 0;
        public int ApartmentsPerFloor => _floors > 0 ? _apartments / _floors : 0;



        public int Number { get; set; }
        public string Name { get; set; }

        public Building(int number, string name)
        {
            this.Number = number;
            this.Name = name;
        }

        // Метод вывода информации о здании
        public void PrintBuildingInfo()
        {
            Console.WriteLine($"Номер здания: {BuildingNumber}");
            Console.WriteLine($"Высота: {Height}");
            Console.WriteLine($"Кол-во этажей: {Floors}");
            Console.WriteLine($"Количество квартир: {Apartments}");
            Console.WriteLine($"Количество подъездов: {Entrances}");

            Console.WriteLine($"Высота этажа: {FloorHeight}");
            Console.WriteLine($"Квартир в подъезде: {ApartmentsPerEntrance}");
            Console.WriteLine($"Квартир на этаже: {ApartmentsPerFloor}");
        }
    }
}