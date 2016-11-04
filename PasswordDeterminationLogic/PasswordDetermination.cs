using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using PasswordDeterminationLogic;

namespace PasswordDeterminationLogic
{
    public class PasswordDetermination
    {
        private int _passwordLength = 0;
        private int _numberOfKnownSubstrings = 0;
        private int _characterPossibilities = 26;
        private bool checkDigitResult = false;
        
        private List<string> knownSubstrings;
        public string ReadInputFile(string fileName)
        {
            string filePath = @"C:\mytest\"+fileName;
            string validationOfFile = new ReadFileRule().ValidateFile(filePath);

            if (string.IsNullOrEmpty(validationOfFile))
            {
                double result = 0;
                string line;
                int countCases = 1;

                System.IO.StreamReader file =  new System.IO.StreamReader(filePath);
                while ((line = file.ReadLine()) != null)
                {
                    checkDigitResult = new ReadFileRule().IsDigitsOnly(line);
                    //check if line has digits --> this will indicate length & no of known substrings
                    if (checkDigitResult)
                    {
                        if (knownSubstrings == null || knownSubstrings.Any())
                        {
                            if (knownSubstrings == null)
                                knownSubstrings = new List<string>();
                            else
                            {
                                ManipulateSubstrings();
                                knownSubstrings = new List<string>();
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
                        knownSubstrings.Add(line);
                        //Console.WriteLine(line);
                    }
                }
                Console.ReadLine();
            }
            return validationOfFile;
        }
        

        private string ReadLineOneOfFile(string passwordHints)
        {
            checkDigitResult = new ReadFileRule().IsDigitsOnly(passwordHints);
            if (!checkDigitResult)
                return "False";
            int spaceInPasswordHints = passwordHints.IndexOf(' ');
            _passwordLength = Convert.ToInt32(passwordHints.Substring(0, spaceInPasswordHints));
            _numberOfKnownSubstrings = Convert.ToInt32(passwordHints.Substring(spaceInPasswordHints));
            return null;
        }

        //private bool IsDigitsOnly(string str)
        //{
        //    foreach (char c in str)
        //    {
        //        if ((c < '0' || c > '9') && (c != ' '))
        //            return false;
        //    }

        //    return true;
        //}

        public double FindPowerOf(int powerOf, int baseValue)
        {
            return Math.Pow(baseValue, powerOf);
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
            List<string> shuffled = knownSubstrings.OrderBy(a => Guid.NewGuid()).ToList();
            for (int i = 0; i < knownSubstrings.Count(); i++)
            {                
                //Console.WriteLine(knownSubstrings.OrderBy(s => Guid.NewGuid()).ToList());//.ForEach(s => s.));
                foreach (var s in shuffled.OrderBy(a => Guid.NewGuid()))
                {
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }

    }
}
