using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    class Caeser
    {
        Dictionary<char, int> charValuePair;
        static readonly int increment = 3;
        public Caeser()
        {
            charValuePair = new Dictionary<char, int>() {
                { 'a' , 1 },{ 'b',2},{'c', 3},
                { 'ç',4},{'d',5},{'e',6},{'f',7},
                { 'g',8},{'ğ',9},{'h',10},{'ı',11},
                { 'i',12 },{ 'j',13},{'k', 14},
                { 'l',15},{'m',16},{'n',17},{'o',18},
                { 'ö',19},{'p',20},{'r',21},{'s',22},
                { 'ş',23},{'t',24},{'u',25},{'ü',26},
                { 'v',27},{'y',28},{'z',29}};
        }


        public string Encrypt(string input)
        {
            string encryptedData = "";
            List<int> keyToNumber = new List<int>();
            foreach(char c in input)
            {
                foreach(KeyValuePair<char,int> kvp in charValuePair)
                {
                    if(c == kvp.Key)
                    {
                        if(kvp.Value + increment > 29)
                        {
                            int mod = kvp.Value + increment % 29;
                            keyToNumber.Add(mod);

                        }
                        else
                        {
                            keyToNumber.Add(kvp.Value+increment);
                        }
                        
                    }
                }
            }

            foreach(int i in keyToNumber)
            {
                foreach(KeyValuePair<char, int> kvp in charValuePair)
                {
                    if(kvp.Value == i)
                    {
                        encryptedData += kvp.Key;
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
                        if (kvp.Value - increment < 0)
                        {
                            int mod = kvp.Value - increment + 29;
                            keyToNumber.Add(mod);
                        }
                        else
                        {
                            keyToNumber.Add(kvp.Value - increment);
                        }

                    }
                }
            }

            foreach (int i in keyToNumber)
            {
                foreach (KeyValuePair<char, int> kvp in charValuePair)
                {
                    if (kvp.Value == i)
                    {
                        decryptedData += kvp.Key;
                    }
                }
            }

            return decryptedData;
        }
    }
}
