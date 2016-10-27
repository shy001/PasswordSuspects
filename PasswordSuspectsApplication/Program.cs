using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordDeterminationLogic;

namespace PasswordSuspectsApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string t = new PasswordDetermination().ReadInputFile("password.txt");
        }
    }
}
