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

        
        public int Age 
        {
            get
            {
                // функция которая вычисляет дату рождения автоматически
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - BirthDay.Year;
                if (BirthDay > nowDate.AddYears(-age)) age--;
                return age;
            }
            set{ }
        }
        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDay { get; set; }
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
        

        public User(string name)
        {
            Name = name;
        }
        public User(string name,
                    Gender gender,
                    DateTime birthday,
                    decimal weight,
                    int height)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name cannot be empty");
            }

            

            if(gender == null)
            {
                throw new ArgumentNullException("Gender cannot be empty");
            }

            if(birthday > DateTime.Parse("01.01.1900") && birthday == DateTime.Now)
            {
                throw new ArgumentException("Datetime is wrong , enter again");
            }

            if(weight == 0)
            {
                throw new ArgumentException("Weight cannot be 0 ");
            }

            if(height == 0)
            {
                throw new ArgumentException("Height cannot be 0 ");
            }

            Name = name;
            
            Gender = gender;
            BirthDay = birthday;
            Weight = weight;
            Height = height;
        }

        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
