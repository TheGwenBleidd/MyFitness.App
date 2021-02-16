using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFitness.App.Model;
using MyFitness.App.Controller;

namespace MyFItness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Здесь начинается приложение
            Console.WriteLine("Welcome , this is MyFitnessApp");
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
          
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            ///Создается новый пользователь , если юзер есть в системе то выводится его имя и возраст
            ///А если нет после имени требуется ввести свой пол и т.д
            ///
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender , please");
                var gender = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gender))
                {
                    throw new ArgumentException("Enter your gender again");
                }
                DateTime birthday = DateTimeParse();
                decimal weight = DecimalParse("weight");
                int height = IntParse();
                ///Метод который добавляет новую информацию пользователя
                userController.SetNewUserData(gender, birthday, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What do you want?");
            Console.WriteLine("Button 'E' - enter the ingestion");
            var key = Console.ReadKey();
            Console.WriteLine();

            if(key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.food, foods.weight);
                
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }


            Console.ReadLine();
        }

        private static (Food food, decimal weight) EnterEating()
        {
            Console.WriteLine("Enter the name of product: ");
            var food = Console.ReadLine();

            var calories = DecimalParse("Calories");
            var proteins = DecimalParse("Proteins");
            var fats = DecimalParse("Fats");
            var carbohydrates = DecimalParse("Carbohydrates");


            var weight = DecimalParse("Weight");
            var product = new Food(food, calories, proteins, fats, carbohydrates);

            return (Food: product, Weight: weight);
        }

        private static int IntParse()
        {
            int height;
            while (true)
            {
                Console.WriteLine("Enter your height , please");
                if (int.TryParse(Console.ReadLine(), out height))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error , enter your height again");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            return height;
        }

        private static decimal DecimalParse(string name)
        {
            decimal weight;
            while (true)
            {
                Console.WriteLine($"Enter your {name} , please");
                if (decimal.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Error , enter your {name} again");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            return weight;
        }

        private static DateTime DateTimeParse()
        {
            DateTime birthday;
            while (true)
            {
                Console.WriteLine("Enter your birthday(DD.MM.YYYY), please");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format of birthday , enter again");
                    Console.ReadLine();
                    Console.Clear();
                }
            }

            return birthday;
        }




    }
}
