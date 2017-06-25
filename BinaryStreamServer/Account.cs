using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryStreamServer
{
    public class Account
    {
        public Account(string username, decimal sum, int period)
        {
            this.Id = Guid.NewGuid().ToString(); // генерируем номер счета
            this.Name = username;
            this.Sum = sum;
            this.Procent = period > 6 ? 10 : 1; // если период вклада больше 6 месяцев, то 10%
        }
        public string Id { get; private set; } // id - номер счета
        public string Name { get; private set; } // имя владельца
        public decimal Sum { get; private set; } // сумма
        public int Procent { get; private set; } // процент вклада
    }
}
