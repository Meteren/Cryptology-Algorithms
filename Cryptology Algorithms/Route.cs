using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptology_Algorithms
{

   
    public static class Array
    {
        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();
        public static System.Collections.Generic.IEnumerable<T>
        Spiral<T>
        (
          this T[,] Matrix
        )
        {

            int top = Matrix.GetLowerBound(0)
              , bot = Matrix.GetUpperBound(0)
              , lft = Matrix.GetLowerBound(1)
              , rgt = Matrix.GetUpperBound(1);
            
            int count = 0;

            while (lft <= rgt)
            {
                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = bot; i >= top; i--)
                {
                    count++;
                    yield return (Matrix[i, lft]);
                } 

                lft++;

                if(Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = lft; i <= rgt; i++)
                {
                        count++;
                    yield return (Matrix[top, i]);
                } 

                top++;

                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = top; i <= bot; i++)
                {
                    count++;
                    yield return (Matrix[i, rgt]);
                }

                rgt--;

                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = rgt; i >= lft; i--)
                {
                    count++;
                    yield return (Matrix[bot, i]);
                }
                bot--;
                
            }

            yield break;
        }

        public static System.Collections.Generic.IEnumerable<(int,int)>
        SpiralElementLocations<T>
        (
          this T[,] Matrix
        )
        {
            int top = Matrix.GetLowerBound(0)
              , bot = Matrix.GetUpperBound(0)
              , lft = Matrix.GetLowerBound(1)
              , rgt = Matrix.GetUpperBound(1);

            int count = 0;

            while (lft <= rgt)
            {
                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = bot; i >= top; i--)
                {
                    count++;
                    yield return (i, lft);
                }

                lft++;

                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = lft; i <= rgt; i++)
                {
                    count++;
                    yield return (top, i);
                }

                top++;

                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = top; i <= bot; i++)
                {
                    count++;
                    yield return (i, rgt);
                }

                rgt--;

                if (Matrix.Length == count)
                {
                    yield break;
                }

                for (int i = rgt; i >= lft; i--)
                {
                    count++;
                    yield return (bot, i);
                }
                bot--;

            }

            yield break;
        }

    }
    class Route
    {
        int key = 5;
        int rowsCnt;
        char preDeterminedChar = 'j';
        
        private char[,]? HoldCharacters { get; set;}
        public Route()
        {

        }

        private void Slice(string input)
        {
            int count = 0;
            int rowsCount = input.Length / key;


            if (input.Length % key == 0)
            {

            }
            else
            {
                rowsCount++;
            }

            rowsCnt = rowsCount;

            char[,] tempHolder = new char[rowsCount, key];
            

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < key; j++)
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
            string encryptedData = "";
            var encryptedEnumerable = Array.Spiral<char>(HoldCharacters!);
            char[] encryptedList = encryptedEnumerable.ToArray();
            foreach(char c in encryptedList)
            {
                encryptedData += c;
            }

            return encryptedData;
                        
        }

        public string Decrypt(string input)
        {
            Slice(input);
            string decryptedData = "";
            (int,int)[] newList = Array.SpiralElementLocations(HoldCharacters!).ToArray();
            
            newList = newList.Reverse().ToArray();

           
            char[,] tempList = new char[rowsCnt,key];
            int count =  0;
            for(int i = rowsCnt - 1; i >= 0; i--)
            {
                for(int j = key - 1; j >= 0; j--)
                {
                    tempList[newList[count].Item1,newList[count].Item2] = HoldCharacters![i, j];
                    //MessageBox.Show(tempList[newList[count].Item1, newList[count].Item2].ToString());
                    count++;
                }
            }


            for (int i = 0; i < rowsCnt; i++)
            {
                for (int j = 0; j < key; j++)
                {
                    decryptedData += tempList[i, j];
                }
            }


            return decryptedData;

        }


    }
}
