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
    class UserController
    {
        public User User { get; set; }

        public UserController(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException("User wasn't found", nameof(user));
            }
            User = user;
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
