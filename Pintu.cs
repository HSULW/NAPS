using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int row = 16;
            int col = 16;

            for (int i = 0; i < row; i++)
            {

                for (int j = 0; j < col; j++)
                {

                    //求角
                    if (CheckCorner(i, j))
                    {

                    }
                    else if (CheckSide(i, j))
                    {//求邊

                    }
                    else
                    {
                        //求中間
                        if ((i % 2 == 0 && j % 2 == 0) || (i % 2 != 0 && j % 2 != 0))
                        {

                            Console.Write("CX");

                        }
                        else
                        {

                            Console.Write("CV");

                        }
                    }

                }
                Console.Write("\n");

            }

            Console.ReadKey();

            bool CheckSide(int i, int j)
            {
                //上
                if (i == 0 && j != 0 && j != col - 1)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("TO");
                    }
                    else
                    {
                        Console.Write("TQ");
                    }

                    return true;
                }
                //下
                else if (i == row - 1 && j != 0 && j != col - 1)
                {
                    if (j % 2 != 0)
                    {
                        Console.Write("BO");
                    }
                    else
                    {
                        Console.Write("BQ");
                    }

                    return true;
                }
                //左
                else if (j == 0 && i != 0 && i != col - 1)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write("LO");
                    }
                    else
                    {
                        Console.Write("LQ");
                    }

                    return true;
                }
                //右
                else if (j == col - 1 && i != 0 && i != col - 1)
                {
                    if (i % 2 != 0)
                    {
                        Console.Write("RO");
                    }
                    else
                    {
                        Console.Write("RQ");
                    }

                    return true;
                }

                return false;
            }

            bool CheckCorner(int i, int j)
            {
                //左上角
                if (i == 0 && j == 0)
                {
                    Console.Write("LM");
                    return true;
                    //右上角
                }
                else if (i == 0 && j == col - 1)
                {
                    Console.Write("RM");
                    return true;
                    //左下角
                }
                else if (j == 0 && i == row - 1)
                {
                    Console.Write("LN");
                    return true;
                    //右下角
                }
                else if (i == col - 1 && j == row - 1)
                {
                    Console.Write("RN");
                    return true;
                }
                return false;
            }

        }//end of static void Main(string[] args)
    }
}