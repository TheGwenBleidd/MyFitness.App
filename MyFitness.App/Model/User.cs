using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.App.Model
{
    [Serializable]
    public class User
    {
        /// <summary>
        /// Вводим все нужные данные для модели
        /// </summary>

        #region Properties
        // <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Возраст.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get;}
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDay { get; }
        /// <summary>
        /// Вес.
        /// </summary>
        public decimal Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public int Height { get; set; }
        /// <summary>
        /// Создаем констуктор чтоб выводить данные модели 
        /// </summary>
        #endregion

        
        
        public User(string name,
                    int age,
                    Gender gender,
                    DateTime birthday,
                    decimal weight,
                    int height)
        {
            
            Name = name;
            Age = age;
            Gender = gender;
            BirthDay = birthday;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
