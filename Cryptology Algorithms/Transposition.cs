using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    class Transposition
    {
        Dictionary<char, char> key;
        string encryptedData = "";
        string decryptedData = "";
        public Transposition()
        {
            key = new Dictionary<char, char>() { 
                { 'a' , 'e' },{ 'b','s'},{'c', 'o'},
                { 'ç','ğ'},{'d','n'},{'e','ü'},{'f','a'},
                { 'g','y'},{'ğ','m'},{'h','ç'},{'ı','t'},
                { 'i','ş' },{ 'j','i'},{'k', 'u'},
                { 'l','p'},{'m','h'},{'n','z'},{'o','r'},
                { 'ö','d'},{'p','ı'},{'r','b'},{'s','k'},
                { 'ş','g'},{'t','j'},{'u','c'},{'ü','v'},
                { 'v','f'},{'y','ö'},{'z','l'}};
        }
       
        public string Encrypt(string input)
        {
            foreach(char s in input)
            {
                foreach(KeyValuePair<char,char> kvp in key)
                {
                    if(s == kvp.Key)
                    {
                        encryptedData += kvp.Value;
                        encryptedData.Trim();
                    }
                }
            }
            return encryptedData;
        }

        public string Decrypt(string input)
        {
            foreach (char s in input)
            {
                foreach (KeyValuePair<char, char> kvp in key)
                {
                    if (s == kvp.Value)
                    {
                        decryptedData += kvp.Key;
                        decryptedData.Trim();
                    }
                }
            }
            return decryptedData;
        }

    }
}
