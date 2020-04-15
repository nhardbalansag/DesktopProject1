using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace building_management_system
{
    class ClassValidations
    {   

        public bool validateStringInput(string inputString, int contentCount)
        {          
            int count_inputString = 0;
            bool returnValue;
            int countInvalid = 0;         
            int nullValue = 0;
            int valid = 0;

            if(inputString == "")
            {
                nullValue++;             
            }           

            if(nullValue > 0)
            {
                returnValue = false;
            }
            else
            {
                char[] invalidCharacter = { '/', '|', '\\', '*', '&', '#', '@', '=', '+', '!', '^', '$', '?', ':', ';' };
                char[] inputValue = inputString.ToCharArray();
                string[] result = new string[1];
                count_inputString = inputString.Length;

                for (int i = 0; i < invalidCharacter.Length; i++)
                {
                    for (int j = 0; j < inputValue.Length; j++)
                    {
                        if (inputValue[j] == invalidCharacter[i])
                        {
                            // the input is invalid
                            countInvalid++;
                        }
                        else
                        {
                            valid++;
                        }

                    }// for loop
                }// end of for loop


                if (countInvalid > 0)
                {
                    returnValue = false;
                }
                else
                {
                    returnValue = true;
                }              
            }
            
            return returnValue;
        }//end of the method

        



    }
}
