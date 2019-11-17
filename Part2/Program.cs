using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {

            TPR obj = new TPR(6, 4);
            obj.PriorityAlgorythm();
            obj.PrintRank();
            Console.ReadKey();
        }
    }
    class Element
    {
        private int mark;
        private int cur_rank;
        private int prev_rank;
        public Element(int mark)
        {
            this.mark = mark;
            cur_rank = 0;
            prev_rank = 0;
        }

        public int Mark
        {
            get { return mark; }
            set { }
        }

        public int Cur_rank
        {
            get { return cur_rank; }
            set { cur_rank = value; }
        }

        public int Prev_rank
        {
            get { return prev_rank; }
            set { prev_rank = value; }
        }

    }
    class TPR
    {
        private Element[,] table;
        int Rows, Columns;
        public TPR(int rows, int colums)
        {

            int[,] mark_table = new int[,] {{4,5,4,3}, {3,3,5,4}, {4,4,3,3}, {3,4,3,5}, {4,5,3,4}, {3,3,5,5}};
            this.Rows = rows;
            this.Columns = colums;
            int Mark = 0;
            Element[,] array = new Element[rows, colums];


            for (int i = 0; i < rows; i++)
                for (int j = 0; j < colums; j++)
                {
                   // Mark = Convert.ToInt32(Console.ReadLine());
                    array[i,j] = new Element(mark_table[i,j]);
                }
            this.table = array;
        }

        public void InitFirstColumn()
        {
            Dictionary<int, Element> List = new Dictionary<int, Element>();
            table[0,0].Cur_rank = 1;
            int current_rank = 1;
            List.Add(table[0,0].Mark, table[0,0]);
            for (int i = 0; i < Rows; i++)
            {
                if (List.ContainsKey(table[i,0].Mark))
                    table[i,0].Cur_rank = List[table[i,0].Mark].Cur_rank;
                else
                {
                    table[i,0].Cur_rank = ++current_rank;
                    List.Add(table[i,0].Mark, table[i,0]);
                }
            }
        }
        public void PriorityAlgorythm()
        {
            InitFirstColumn();
            Dictionary<int, Element> List = new Dictionary<int, Element>();

            int current_rank = 0;
            List.Add(table[0,0].Mark, table[0,0]);

            for (int i = 0; i < Columns; i++)
            {
                for (int r = 0; r < Rows; r++)
                {
                    SetRank(i, r, List, ref current_rank);
                }
            }

        }

        void SetRank(int column, int rnk, Dictionary<int, Element> List, ref int current_rank)
        {
            for (int i = 0; i < Rows; i++)
            {
                //добавить инициализацию prev_rank
                table[i,column].Prev_rank = table[i,column - 1].Cur_rank;
                if (table[i,column].Prev_rank == rnk)
                {
                    if (List.ContainsKey(table[i,column].Mark))
                        table[i,column].Cur_rank = List[table[i,column].Mark].Cur_rank;
                    else
                    {
                        
                        List<int> keys = new List<int>(List.Keys);
                        foreach (var key in keys)
                        {
                            if (table[i,column].Mark > List[key].Mark)
                            {
                                if (List[key].Prev_rank + 1 == current_rank)
                                    List[key].Cur_rank = List[key].Prev_rank + 2;
                                else List[key].Cur_rank = List[key].Prev_rank + 1;
                                current_rank = List[key].Cur_rank;
                            }
                            else
                            {
                                if (table[i,column].Prev_rank + 1 == current_rank)
                                    table[i,column].Cur_rank = table[i,column].Prev_rank + 2;
                                else table[i,column].Cur_rank = table[i,column].Prev_rank + 1;
                                current_rank = table[i,column].Cur_rank;
                            }
                        }
                        List.Add(table[i,column].Mark, table[i,column]);

                    }

                }
            }
        }

        public void PrintRank()
        {
            for (int i = 0; i< Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Console.Write("{table[i][j].Cur_rank} ");
                }
                Console.WriteLine();
            }
        }

    }
    
}
