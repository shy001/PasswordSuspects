using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordDeterminationLogic
{
    public interface IFileRule
    {
        string ValidateFile(string filePath);
    }
}
