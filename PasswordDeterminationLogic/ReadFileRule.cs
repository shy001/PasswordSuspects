using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordDeterminationLogic
{
    public class ReadFileRule : IFileRule
    {
        public string ValidateFile(string filePath)
        {            
            string _fileContents = "";
            if (File.Exists(filePath))
            {
                StreamReader passwordInputFile = new StreamReader(filePath);
                if (passwordInputFile.EndOfStream)
                    return "Empty File";
                _fileContents = passwordInputFile.ReadToEnd();
                if (!_fileContents.Contains("0 0"))
                    return "Does not contain '0 0'";
            }
            else
            {
                return "File does not Exist";
            }
            return null;
        }

        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && (c != ' '))
                    return false;
            }

            return true;
        }
    }
}
