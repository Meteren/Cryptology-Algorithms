using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    
    class LineerAffine
    {
        Dictionary<char, int> charValuePair;
        int a = 3, b = 2;
        public LineerAffine()
        {
            charValuePair = new Dictionary<char, int>() {
                { 'a' , 1 },{ 'b',2},{'c', 3},
                { 'ç',4},{'d',5},{'e',6},{'f',7},
                { 'g',8},{'ğ',9},{'h',10},{'ı',11},
                { 'i',12},{ 'j',13},{'k', 14},
                { 'l',15},{'m',16},{'n',17},{'o',18},
                { 'ö',19},{'p',20},{'r',21},{'s',22},
                { 'ş',23},{'t',24},{'u',25},{'ü',26},
                { 'v',27},{'y',28},{'z',29}};
        }
       
        private int LineerFunctForX(int x)
        {
            int y;
            y = a * x + b;
            return y;
        }

        private int LineerFunctForY(int y)
        {
            while (true)
            {
                if((y - b) % 3 != 0)
                {
                   
                    y += 29;
                }
                else
                {
                    break;
                }
            }
            int x;

            x = (y - b) / a;

            if(x == 0)
            {
                x = 29;
            }

            return x;
        }

        public string Encrypt(string input)
        {
            string encryptedData = "";
            List<int> keyToNumber = new List<int>();
            foreach (char c in input)
            {
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if (c == kvp.Key)
                    {  
                        keyToNumber.Add(LineerFunctForX(kvp.Value));

                    }
                }
            }

            foreach (int i in keyToNumber)
            {
                int tempNumb = i;
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if(tempNumb > 29)
                    {
                        tempNumb = tempNumb % 29;
                    }
                    if (tempNumb == kvp.Value)
                    {
                        encryptedData += kvp.Key;
                        break;                        
                    }
                }
            }
            return encryptedData;

        }

        public string Decrypt(string input)
        {
            string decryptedData = "";
            List<int> keyToNumber = new List<int>();
            foreach (char c in input)
            {
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if (c == kvp.Key)
                    {
                        keyToNumber.Add(LineerFunctForY(kvp.Value));

                    }
                }
            }

            foreach (int i in keyToNumber)
            {
                int tempNumb = i;
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if (tempNumb > 29)
                    {
                        tempNumb = tempNumb % 29;
                    }
                    if (tempNumb == kvp.Value)
                    {
                        decryptedData += kvp.Key;
                        break;
                    }
                    
                }
            }
            return decryptedData;

        }

    }
}
