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
            Console.WriteLine("Welcome , this is MyFitnessApp");
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
          
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Enter your gender , please");
                var gender = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(gender))
                {
                    throw new ArgumentException("Enter your gender again");
                }
                DateTime birthday = DateTimeParse();
                decimal weight = DecimalParse();
                int height = IntParse();

                userController.SetNewUserData(gender, birthday, weight, height);
            }


            Console.WriteLine(userController.CurrentUser );
            Console.ReadLine();
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

        private static decimal DecimalParse()
        {
            decimal weight;
            while (true)
            {
                Console.WriteLine("Enter your weight , please");
                if (decimal.TryParse(Console.ReadLine(), out weight))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Error , enter your weight again");
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
