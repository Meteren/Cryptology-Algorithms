using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    class PermutationCipher
    {
        static char preDeterminedChar = 'z';
        static int slicingValue = 5;
        int rowsCnt;
        Dictionary<int, int> keyValuePair;
        private char[,]? HoldCharacters { get; set; }

        public PermutationCipher()
        {
            keyValuePair = new Dictionary<int, int>() { { 1, 4 }, { 2, 1 }, { 3, 5 }, { 4, 2 }, { 5, 3 } };
        }

        private void Slice(string input)
        {
            int count = 0;
            int rowsCount = input.Length/slicingValue;

            if (input.Length % slicingValue == 0)
            {
                
            }
            else
            {
                rowsCount++;
            }

            rowsCnt = rowsCount;
            
            char[,] tempHolder = new char[rowsCount,slicingValue]; 
            
            for(int i = 0; i < rowsCount; i++)
            {
                for(int j = 0; j<slicingValue; j++)
                {
                    if( count  == input.Length)
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
            Slice(input);
            string encryptedData = "";
            for(int i = 0; i < rowsCnt; i++)
            {
                for(int j = 0; j < slicingValue; j++)
                {
                    foreach(KeyValuePair<int,int> kvp in keyValuePair)
                    {
                        if(j+1 == kvp.Key)
                        {
                            for (int k = 0; k < slicingValue; k++)
                            {
                                if (k + 1 == kvp.Value)
                                {
                                        encryptedData += HoldCharacters![i, k];
                                }
                            }
                            
                        }
                    }
                }
            }
            encryptedData.Trim();
            return encryptedData;

        }

        public string Decrypt(string input )
        {
            string decryptedData = "";
            if (input.Length % slicingValue == 0)
            {
                Slice(input);
                for (int i = 0; i < rowsCnt; i++)
                {
                    for (int j = 0; j < slicingValue; j++)
                    {
                        foreach (KeyValuePair<int, int> kvp in keyValuePair)
                        {
                            if (j + 1 == kvp.Value)
                            {
                                for (int k = 0; k < slicingValue; k++)
                                {
                                    if (k + 1 == kvp.Key)
                                    {
                                        decryptedData += HoldCharacters![i, k];
                                    }
                                }
                            }
                        }
                    }
                }
              
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
