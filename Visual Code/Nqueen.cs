using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual_Code
{
    public partial class Nqueen : Form
    {
        int first=0;
        bool refresh = false;
        int a = 0;
        public Nqueen()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int a = int.Parse(txtSize.Text);
            if (int.Parse(txtSize.Text) < 10)
            {
                int L = int.Parse(txtSize.Text);
                int x = 180, y = 150;//x = height from top and y = height from Left
                N = L;
                int[,] arr = new int[L, L];

                if (!theBoardSolver(arr, 0))
                {
                    MessageBox.Show("Solution not Possible .");
                }

                for (int i = 0; i < L; i++)
                {
                    //Creating Rows
                    for (int j = 0; j < L; j++)
                    {
                        //creating Columns
                        Button btn = new Button();
                        btn.Text = (i + 1) + "" + (j + 1);

                        btn.Width = 60;
                        btn.Height = 60;
                        btn.Left = x;
                        btn.Top = y;
                        btn.Name = btn + "" + i;
                        btn.BackColor = Color.White;
                        this.Controls.Add(btn);
                        x += 75;
                        //agar value 1 ho gi to hum queen place karayn gay nahi to wo value 0 ho gi or
                        //next row or column chalay ga
                        if (arr[i, j] == 1)
                        {
                            btn.Text = "Queen";
                            btn.BackColor = Color.Red;
                        }
                    }
                    x = 180;
                    y += 75;
                }
               
                first++;
        }
            else
            {
                MessageBox.Show("Please Enter Value In between The range of 1 to 10");
            }

}
        static int N;
        /* A utility function to check if a queen can 
   be placed on board[row,col]. Note that this 
   function is called when "col" queens are already 
   placeed in columns from 0 to col -1. So we need 
   to check only left side for attacking queens */

        static Boolean toPlaceOrNotToPlace(int[,] board, int row, int col)
        {
            int i, j;
            /* Check this row on left side */
            for (i = 0; i < col; i++)
            {
                if (board[row, i] == 1) return false;
            }

            /* Check upper diagonal on left side */
            for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            {
                if (board[i, j] == 1) return false;
            }

            /* Check lower diagonal on left side */
            for (i = row, j = col; j >= 0 && i < N; i++, j--)
            {
                if (board[i, j] == 1) return false;
            }
            return true;
        }
        /* A recursive utility function to solve N 
    Queen problem */
        static Boolean theBoardSolver(int[,] board, int col)
        {
            /* base case: If all queens are placed 
        then return true */
            if (col >= N)
                return true;
            /* Consider this column and try placing 
        this queen in all rows one by one */
            for (int i = 0; i < N; i++)
            {
                /* Check if the queen can be placed on 
            board[i,col] */
                if (toPlaceOrNotToPlace(board, i, col))
                {
                    /* Place this queen in board[i,col] */
                    board[i, col] = 1;
                    /* recur to place rest of the queens */
                    if (theBoardSolver(board, col + 1))
                        return true;
                    /* If placing queen in board[i,col] 
                doesn't lead to a solution then 
                remove queen from board[i,col] */
                    board[i, col] = 0;
                }
            }
            return false;
        }
        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            if (first > 0 && refresh == false)
            {
                refresh = true;
                txtSize.Clear();
                Nqueen f = new Nqueen();
                f.Show();
                this.Hide();
            }
        }
        private void txtSize_MouseClick(object sender, MouseEventArgs e)
        {
            txtSize.Clear();
        }

    }
}
