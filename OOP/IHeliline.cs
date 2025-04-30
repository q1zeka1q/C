using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_alused.OOP
{
    public interface IHeliline
    {
        void TeeHääl();
    }
    public class Kass : IHeliline
    {
        public void TeeHääl()
        {
            Console.WriteLine("Mjäu!");
        }
    }
}
