using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;


namespace PasswordDeterminationLogic
{
    public class PasswordDetermination
    {
        private int _passwordLength = 0;
        private int _numberOfKnownSubstrings = 0;
        private int _characterPossibilities = 26;
        private string _fileContents = null;
        
        private List<string> substrings;
        public string ReadInputFile(string fileName)
        {
            string filePath = @"C:\mytest\"+fileName;
            string validationOfFile = ValidateFile(filePath);

            double result = 0;
            string line;
            int countCases = 1;
            if (string.IsNullOrEmpty(validationOfFile))
            {
                System.IO.StreamReader file =  new System.IO.StreamReader(@"c:\mytest\"+fileName);
                while ((line = file.ReadLine()) != null)
                {   
                    
                    //check if line has digits --> this will indicate length & no of known substrings
                    if (IsDigitsOnly(line))
                    {
                        if (substrings == null || substrings.Any())
                        {
                            if (substrings == null)
                                substrings = new List<string>();
                            else
                            {
                                ManipulateSubstrings();
                                substrings = new List<string>();
                            }
                        }
                        //end of file
                        if (line.Equals("0 0"))
                            break;
                        Console.Write("Case " + countCases + ": ");
                        ReadLineOneOfFile(line);
                        if (_numberOfKnownSubstrings == 0)
                        {
                            result = FindPowerOf(_passwordLength, _characterPossibilities);
                        }
                        else
                        {
                            result = ManageCombinations(_passwordLength, _numberOfKnownSubstrings);
                        }
                        Console.WriteLine(result + " suspects");
                        countCases++;
                    }
                    else
                    {
                        substrings.Add(line);
                        //Console.WriteLine(line);
                    }
                }
                Console.ReadLine();
            }
            return validationOfFile;
        }
        
        public string ValidateFile(string filePath)
        {
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

        private string ReadLineOneOfFile(string passwordHints)
        {
            if (!IsDigitsOnly(passwordHints))
                return "False";
            int spaceInPasswordHints = passwordHints.IndexOf(' ');
            _passwordLength = Convert.ToInt32(passwordHints.Substring(0, spaceInPasswordHints));
            _numberOfKnownSubstrings = Convert.ToInt32(passwordHints.Substring(spaceInPasswordHints));
            return null;
        }

        private bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if ((c < '0' || c > '9') && (c != ' '))
                    return false;
            }

            return true;
        }

        public double FindPowerOf(int lengthOfString, int noOfOptions)
        {
            return Math.Pow(noOfOptions, lengthOfString);
        }

        public int ManageCombinations(int lengthOfString, int noOfOptions)
        {
            int countNumberOfPossiblePasswords = 0;
            if (lengthOfString % noOfOptions == 0)
            {
                return noOfOptions;
            }
            return -1;
        }

        public void ManipulateSubstrings()
        {
            List<string> shuffled = substrings.OrderBy(a => Guid.NewGuid()).ToList();
            for (int i = 0; i < substrings.Count(); i++)
            {
                
                //Console.WriteLine(substrings.OrderBy(s => Guid.NewGuid()).ToList());//.ForEach(s => s.));
                foreach (var s in shuffled.OrderBy(a => Guid.NewGuid()))
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }

    }
}
