using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFitness.App.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        public DateTime Moment { get;}
        /// <summary>
        /// !В словаре не опцианально использовать значимый тип 
        /// </summary>
        public  Dictionary<Food,double> Foods { get; }

        public User User { get;}

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User cannot be null", nameof(user));
            Moment = DateTime.Now;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            //Ищем такой продукт
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food));

            //Если его нет то добавляем
            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }

    }
}
