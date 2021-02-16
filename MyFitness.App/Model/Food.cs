using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.App.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Food Name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Протеин(белки) на 100г
        /// </summary>
        public decimal Proteins { get; }
        /// <summary>
        /// Жиры на 100г
        /// </summary>
        public decimal Fats { get; }
        /// <summary>
        /// Углеводы на 100г
        /// </summary>
        public decimal Carbohydrates { get; set; }
        /// <summary>
        /// Калории 100г
        /// </summary>
        public decimal Calories { get; set; }
        /// <summary>
        /// Чекаем все входные данные
        /// и делим их сразу на 100 
        /// и создаем еще один конструктор который будет ставить значение по умолчанию
        /// </summary>
        /// <param name="name"></param>
        /// <param name="calories"></param>
        /// <param name="proteins"></param>
        /// <param name="fats"></param>
        /// <param name="carbohydrates"></param>
        public Food(string name, decimal calories ,decimal proteins , decimal fats , decimal carbohydrates)
        {
            Name = name ?? throw new ArgumentException("Name of food cannot be null");
            
            if(calories <= 0)
            {
                throw new ArgumentException("Calories cannot be 0");
            }
            if(proteins <= 0)
            {
                throw new ArgumentException("Proteins cannot be 0");
            }
            if(fats <= 0)
            {
                throw new ArgumentException("Fats cannot be 0");
            }
            if(carbohydrates <= 0)
            {
                throw new ArgumentException("Carbohydrates cannot be 0");
            }

            Calories = calories / 100.0M;
            Proteins = proteins / 100.0M;
            Fats = fats / 100.0M;
            Carbohydrates = carbohydrates / 100.0M;
        }

        public Food(string name) : this(name , 0 , 0, 0, 0) { }
        /// <summary>
        /// Переопределяем ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
