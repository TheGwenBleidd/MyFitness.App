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
    public class UserController : BaseController
    {
        private const string USERS_FILE_NAME = "users.dat";

        /// <summary>
        /// Всех юзеров сохранеям в списке.
        /// </summary>
        public List<User> Users { get;}

        /// <summary>
        /// Флаг для обозначения пользователь новый или уже есть в системе.
        /// </summary>
        public bool IsNewUser { get;} = false;

        /// <summary>
        /// Активный пользователь , это нужно для того чтобы если юзер уже есть в системе то к нему присоединяемся , а если в списке нет то тогда создаем нового.
        /// </summary>
        public User CurrentUser {get;}

        public UserController(string userName)
        {
            
            if (userName == null)
            {
                throw new ArgumentNullException("Name cannot be null, enter again", nameof(userName));
            }

            /// <summary>
            /// В список добавлеяем всеx сериализованных пользователей.
            /// </summary>
            Users = GetUsers();

            /// <summary>
            /// Здесь ишем пользователя если его нет в списке то создается новый пользователь.
            /// </summary>лей
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
            
        }


        public void SetNewUserData( string gender , DateTime birthday ,decimal weight = 1  , int height = 1)
        {
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new ArgumentNullException("Gender is empty , enter again");
            }

            if(birthday > DateTime.Parse("01.01.1900") && birthday == DateTime.Now)
            {
                throw new ArgumentException("Birthdate is wrong , enter again");
            }

            CurrentUser.Gender = new Gender(gender);
            CurrentUser.BirthDay = birthday;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        /// <summary>
        /// Метод который сэйвит юзеров в отдельный файл.
        /// </summary>
        /// <returns>void</returns>
        public void Save()
        {
            base.Save(USERS_FILE_NAME, Users);
        }

        /// <summary>
        /// Метод который позволяет получать список пользователей.
        /// </summary>
        /// <returns>User</returns>
        private List<User> GetUsers()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }
    }
}
