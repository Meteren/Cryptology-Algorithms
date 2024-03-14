using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cryptology_Algorithms
{
    class Vigenere
    {
        int slicingValue;
        string key = "araba";
        List<int> keyToNumbers;
        static char preDeterminedChar = 'a';
        int rowsCnt;
        Dictionary<char, int> charValuePair;
        List<int> inputTextNumberEquilavents = new List<int>();
        private char[,]? HoldCharacters { get; set; }
        public Vigenere()
        {

            keyToNumbers = new List<int>();

            
            charValuePair = new Dictionary<char, int>() {
                { 'a' , 1 },{ 'b',2},{'c', 3},
                { 'ç',4},{'d',5},{'e',6},{'f',7},
                { 'g',8},{'ğ',9},{'h',10},{'ı',11},
                { 'i',12 },{ 'j',13},{'k', 14},
                { 'l',15},{'m',16},{'n',17},{'o',18},
                { 'ö',19},{'p',20},{'r',21},{'s',22},
                { 'ş',23},{'t',24},{'u',25},{'ü',26},
                { 'v',27},{'y',28},{'z',29}};
            
            

           foreach(char c in key)
            {
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if(c == kvp.Key)
                    {
                        keyToNumbers!.Add(kvp.Value);
                    }
                }
            }

            slicingValue = keyToNumbers!.Count;
        }

        private void Slice(string input)
        {
            int count = 0;
            int rowsCount = input.Length / slicingValue;
            

            if (input.Length % slicingValue == 0)
            {

            }
            else
            {
                rowsCount++;
            }

            rowsCnt = rowsCount;

            char[,] tempHolder = new char[rowsCount, slicingValue];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < slicingValue; j++)
                {
                    if (count == input.Length)
                    {
                        tempHolder[i, j] = preDeterminedChar;
                    }
                    else
                    {
                        tempHolder[i, j] = input[count];
                        count++;
                    }

                }
            }

            HoldCharacters = tempHolder;
        }

        public string Encrypt(string input)
        {
            string encryptedData = "";
            Slice(input);
            for(int i = 0; i<rowsCnt; i++)
            {
                for(int j = 0; j < slicingValue; j++)
                {
                    foreach (KeyValuePair<char, int> kvp in charValuePair)
                    {
                        if (HoldCharacters![i,j] == kvp.Key)
                        {
                            
                            int newValue;  
                            newValue = kvp.Value + keyToNumbers[j];
                           
                            if(newValue < 0)
                            {
                                newValue = newValue + 29;
                            }

                            if(newValue > 29)
                            {
                                newValue = newValue % 29;
                            }

                            inputTextNumberEquilavents.Add(newValue);
                        }
                    }
                }
                
            }

            foreach(int i in inputTextNumberEquilavents)
            {
                foreach(KeyValuePair<char, int> kvp in charValuePair)
                {
                    if(kvp.Value == i)
                    {
                        encryptedData += kvp.Key;
                    }
                }
            }
            encryptedData.Trim();
            return encryptedData;

        }

        public string Decrypt(string input)
        {
            string decryptedData = "";
            Slice(input);
            if (input.Length % slicingValue == 0)
            {
                for (int i = 0; i < rowsCnt; i++)
                {
                    for (int j = 0; j < slicingValue; j++)
                    {
                        foreach (KeyValuePair<char, int> kvp in charValuePair)
                        {
                            if (HoldCharacters![i, j] == kvp.Key)
                            {
                                int newValue;
                               
                                newValue = kvp.Value - keyToNumbers[j];

                                if (newValue < 0)
                                {
                                    newValue = newValue + 29;
                                }
                                inputTextNumberEquilavents.Add(newValue);
                            }
                        }
                    }

                }
                foreach (int i in inputTextNumberEquilavents)
                {
                    foreach (KeyValuePair<char, int> kvp in charValuePair)
                    {
                        if (kvp.Value == i)
                        {
                            decryptedData += kvp.Key;
                        }
                    }
                }


               /* List<char> tempList = decryptedData.ToList();
               
                for(int i = tempList.Count - 1; ; i--)
                {
                    if (tempList[i] != preDeterminedChar)
                    {
                        lastIndex = i;
                        break;
                    }
                    else
                    {
                        numbersRemainingToCeiling++;
                    }
                }
               

                tempList.RemoveRange(lastIndex+1, numbersRemainingToCeiling);
               */

               // decryptedData = "";

                /*foreach (char c in tempList)
                {
                    decryptedData += c;
                }*/
            }
            else
            {
                throw new Exception("The text can't be decrypted!!!");
            }

            decryptedData.Trim();
            return decryptedData;
        }
    }
}
