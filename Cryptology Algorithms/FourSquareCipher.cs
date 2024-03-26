using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    class FourSquareCipher
    {
        char[,] sequencedList;
        char[,] mixedList;
        char preDeterminedChar = 'a';
        int rowsCnt;
        private char[,]? HoldCharacters { get; set; }

        public FourSquareCipher()
        {
            sequencedList = new char[6, 5] { {'a','b','c','ç','d'},{'e','f','g','ğ','h'},
                {'ı','i','j','k','l'},{'m','n','o','ö','p'},{'r','s','ş','t','u'},{'ü','v','y','z','x'}};
            mixedList = new char[6, 5] { {'x','n','i','ğ','k'},{'z','y','d','s','ö'},{'c','t','p','b','h'},
            {'u','v','j','f','l'},{'g','ü','a','r','ç'},{'m','ş','e','o','ı'}};
        }

        private void Slice(string input)
        {
            int count = 0;
            int rowsCount = input.Length / 2;


            if (input.Length % 2 == 0)
            {

            }
            else
            {
                rowsCount++;
            }

            rowsCnt = rowsCount;

            char[,] tempHolder = new char[rowsCount, 2];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < 2; j++)
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
            Slice(input);
            string encryptedOrDecryptedData = "";
            HandleCells(ref encryptedOrDecryptedData, State.encryption);
            return encryptedOrDecryptedData;
        }

        public string Decrypt(string input)
        {
            Slice(input);
            string encryptedOrDecryptedData = "";
            HandleCells(ref encryptedOrDecryptedData,State.decryption);
            return encryptedOrDecryptedData;
        }

        private void HandleCells(ref string encryptedOrDecryptedData,State state)
        {
            
            for (int i = 0; i < rowsCnt; i++)
            {
                int rowOne = 0;
                int rowTwo = 0;
                int columnOne = 0;
                int columnTwo = 0;
                for (int j = 0; j < 2; j++)
                {
                    for (int k = 0; k < 6; k++)
                    {
                        for (int l = 0; l < 5; l++)
                        {
                            if (state == State.encryption)
                            {
                                if (HoldCharacters![i, j] == sequencedList[k, l])
                                {
                                    if (j == 0)
                                    {
                                        rowOne = k;
                                        columnTwo = l;
                                    }
                                    if (j == 1)
                                    {
                                        columnOne = l;
                                        rowTwo = k;
                                    }

                                }
                            }
                            if(state == State.decryption)
                            {
                                if (HoldCharacters![i, j] == mixedList[k, l])
                                {
                                    if (j == 0)
                                    {
                                        rowOne = k;
                                        columnTwo = l;
                                    }
                                    if (j == 1)
                                    {
                                        columnOne = l;
                                        rowTwo = k;
                                    }

                                }
                            }
                            
                        }
                    }

                }
                if(state == State.encryption)
                {
                    encryptedOrDecryptedData += mixedList[rowOne, columnOne];
                    encryptedOrDecryptedData += mixedList[rowTwo, columnTwo];
                }
                if(state == State.decryption)
                {
                    encryptedOrDecryptedData += sequencedList[rowOne, columnOne];
                    encryptedOrDecryptedData += sequencedList[rowTwo, columnTwo];
                }

            }
        }

    }
}
