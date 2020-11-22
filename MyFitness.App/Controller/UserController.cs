using MyFitness.App.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.App.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public  class UserController
    {
        public User User { get; set; }

        public UserController(string userName , int age ,string genderName , DateTime birthDay , decimal weight , int height )
        {
            #region Checking
            if(userName == null)
            {
                throw new ArgumentNullException("Name cannot be null, enter again", nameof(userName));
            }

            if (age == 0)
            {
                throw new ArgumentException("Age cannot be 0 , enter again", nameof(age));
            }

            if (genderName == null)
            {
                throw new ArgumentNullException("Gender cannot be null, enter again", nameof(genderName));
            }

            if (birthDay < DateTime.Parse("01.01.1910") && birthDay >= DateTime.Now)
            {
                throw new ArgumentException("Birthday cannot be empty , enter again", nameof(birthDay));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Weight cannot be 0 , enter again", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height cannot be 0 , enter again", nameof(height));
            }
            #endregion 

            var gender = new Gender(genderName);
            User = new User(userName , age , gender , birthDay , weight , height );
        
        }
        /// <summary>
        /// Метод который сэйвит юзеров в отдельный файл.
        /// </summary>
        /// <returns></returns>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }


        /// <summary>
        /// Метод который позволяет получать данные об пользователе.
        /// </summary>
        /// <returns></returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                 return formatter.Deserialize(fs) as User;  
            }
        }
    }
}
