using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{
    class ZigZag
    {
        int rowKey = 5;
        int columns;
        char[,] keyMatrix;

        public ZigZag(int columns)
        {
            this.columns = columns;
            keyMatrix = new char[rowKey, this.columns];
        }

        public string Encrypt(string input)
        {
            string encryptedData = "";
            int count = -1;
            while (true)
            {
                for (int i = 0; i < rowKey; i++)
                {
                    if (count+1 == input.Length)
                    {
                        break;
                    }
                    count++;
                    keyMatrix[i, count] = input[count];
                                      
                }

                for (int i = rowKey - 2; i >= 1; i--)
                {
                    if (count+1 == input.Length)
                    {
                        break;
                    }
                    
                    count++;
                    keyMatrix[i, count] = input[count];
                    
                }
                if(count+1 == input.Length)
                {
                    break;
                }
            }

            encryptedData = new string((from char c in keyMatrix
                                       where c != '\0'
                                       select c).ToArray());
            encryptedData.Trim();
            return encryptedData;
            
        }

        public string Decrypt(string input)
        {
            string decryptedData = "";
            int count = -1;
            while (true)
            {
                for (int i = 0; i < rowKey; i++)
                {
                    if (count + 1 == input.Length)
                    {
                        break;
                    }
                    count++;
                    keyMatrix[i, count] = 'c';

                }

                for (int i = rowKey - 2; i >= 1; i--)
                {
                    if (count + 1 == input.Length)
                    {
                        break;
                    }

                    count++;
                    keyMatrix[i, count] = 'c';

                }
                if (count + 1 == input.Length)
                {
                    break;
                }
            }

            count = 0;
            for(int i = 0; i < rowKey; i++)
            {
                for(int j = 0; j < columns; j++)
                {
                    if (keyMatrix[i,j] == 'c')
                    {
                        keyMatrix[i, j] = input[count++];
                        MessageBox.Show(keyMatrix[i, j].ToString());
                    }
                }
            }

            count = -1;
            while (true)
            {
                for (int i = 0; i < rowKey; i++)
                {
                    if (count + 1 == input.Length)
                    {
                        break;
                    }
                    count++;
                    decryptedData += keyMatrix[i, count];

                }

                for (int i = rowKey - 2; i >= 1; i--)
                {
                    if (count + 1 == input.Length)
                    {
                        break;
                    }
                    count++;
                    decryptedData += keyMatrix[i, count];

                }
                if (count + 1 == input.Length)
                {
                    break;
                }
            }
            decryptedData.Trim();
            return decryptedData;

        }
    }
}
