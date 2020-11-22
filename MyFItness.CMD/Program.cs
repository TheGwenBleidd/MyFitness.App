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
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name cannot be empty");
            }

            Console.WriteLine("Enter your age");
            int age = Convert.ToInt32(Console.ReadLine());
            if(age == 0)
            {
                throw new ArgumentException("Age cannot be 0 ");
            }

            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();
            if (gender == null)
            {
                throw new ArgumentNullException("User's gender cannot be empty");
            }

            Console.WriteLine("Enter your birthDay ");
            var birthDay = DateTime.Parse(Console.ReadLine());
            if (birthDay < DateTime.Parse("01.01.1910") && birthDay >= DateTime.Now)
            {
                throw new ArgumentException("Birthday cannot be empty , enter again", nameof(birthDay));
            }

            Console.WriteLine("Enter your weight");
            var weight = decimal.Parse(Console.ReadLine());
            if(weight == 0)
            {
                throw new ArgumentException("Weight cannot be 0 ");
            }

            Console.WriteLine("Enter your height");
            var height = int.Parse(Console.ReadLine());
            if(height == 0) 
            {
                throw new ArgumentException("Height cannot be 0 ");
            }

            var userController = new UserController(name, age, gender, birthDay, weight, height);
            userController.Save();
        }
    }
}
