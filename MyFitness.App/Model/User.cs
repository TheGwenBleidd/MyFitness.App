using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.App.Model
{
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
            
            #region Check
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty enter again", nameof(name));
            }

            if(age == 0) 
            {
                throw new ArgumentException("Age cannot be 0 , enter again", nameof(age));
            }

            if(gender == null) 
            {
                throw new ArgumentNullException("Gender cannot be null, enter again", nameof(gender));
            }

            if(birthday < DateTime.Parse("01.01.1910") && birthday >= DateTime.Now ) 
            {
                throw new ArgumentException("Birthday cannot be empty , enter again", nameof(birthday));
            }

            if(weight <= 0) 
            {
                throw new ArgumentException("Weight cannot be 0 , enter again" ,nameof(weight));
            }

            if(height <= 0) 
            {
                throw new ArgumentException("Height cannot be 0 , enter again", nameof(height));
            }
            #endregion
            
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
