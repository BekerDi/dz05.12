using System.Collections.Generic;
using System.IO;
using System;
using bank;
using System.Collections;



namespace bank
{

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Сберегательный", 1000000);
            BankAccount account2 = new BankAccount("Основной", 57500);

            Console.WriteLine("Информация о счете 1:");
            account1.DisplayAccountDetails();

            Console.WriteLine();

            Console.WriteLine("Информация о счете 2:");
            account2.DisplayAccountDetails();

            Console.WriteLine();

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Положить на сберегательный счет");
            Console.WriteLine("2. Снять со сберегательного счета");
            Console.WriteLine("3. Положить на основной счет");
            Console.WriteLine("4. Снять с основного счета");
            int choice = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите сумму:");
            decimal amount = decimal.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    account1.Deposit(amount);
                    Console.WriteLine("Обновленная информация о сберегательном счете:");
                    account1.DisplayAccountDetails();
                    break;
                case 2:
                    account1.Withdraw(amount);
                    Console.WriteLine("Обновленная информация о сберегательном счете:");
                    account1.DisplayAccountDetails();
                    break;
                case 3:
                    account2.Deposit(amount);
                    Console.WriteLine("Обновленная информация об основном счете:");
                    account2.DisplayAccountDetails();
                    break;
                case 4:
                    account2.Withdraw(amount);
                    Console.WriteLine("Обновленная информация о счете:");
                    account2.DisplayAccountDetails();
                    break;
                default:
                    Console.WriteLine("Некорректный выбор операции.");
                    break;

            }
            Hashtable bankAccounts = new Hashtable();
            BankAccountCreator creator = new BankAccountCreator(bankAccounts);
            creator.CreateAccount();
            creator.CreateAccount();
            int accountNum = creator.CreateAccount();
            creator.DeleteAccount(accountNum);





            Console.ReadKey();



            Building building1 = new Building
            {
                Height = 50,
                Floors = 10,
                Apartments = 40,
                Entrances = 4
            };


            Building building2 = new Building
            {
                Height = 100,
                Floors = 20,
                Apartments = 80,
                Entrances = 8
            };


            building1.PrintBuildingInfo();
            Console.WriteLine();


            building2.PrintBuildingInfo();
            BuildingIndex buildings = new BuildingIndex(10);


            for (int i = 0; i < 10; i++)
            {
                buildings[i + 1].Height = 10 * (i + 1);
                buildings[i + 1].Floors = i + 1;
                buildings[i + 1].Apartments = (i + 1) * 7;
                buildings[i + 1].Entrances = (i + 1) % 2 + 1;
            }


            Building building5 = buildings[5];
            if (building5 != null)
            {
                building5.PrintBuildingInfo();
            }
            else
            {
                Console.WriteLine("Здание с таким номером не найдено.");
            }
            Type buildingType = typeof(Building);
            object[] attrs = buildingType.GetCustomAttributes(typeof(DeveloperInfoAttribute), false);

            if (attrs.Length > 0)
            {
                DeveloperInfoAttribute devInfo = (DeveloperInfoAttribute)attrs[0];
                Console.WriteLine("Программа разработана {0} из {1}", devInfo.DeveloperName, devInfo.OrganizationName);
            }
            Console.ReadKey();

        }

    }
}


