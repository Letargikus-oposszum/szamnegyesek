using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace szamnegyes
{
    public partial class Form1 : Form
    {
        private int[,] board = new int[3, 3];
        private Label[,] labels = new Label[3, 3];

        public Form1()
        {
            InitializeComponent();
            CreateBoard();
            DrawBoard();
        }

        /// <summary>
        /// Creates the 3×3 grid and buttons
        /// </summary>
        private void CreateBoard()
        {
            // Create labels (3×3 board)
            for (int r = 0; r < 3; r++)
            {
                for (int c = 0; c < 3; c++)
                {
                    Label lbl = new Label
                    {
                        Size = new Size(40, 40),
                        Location = new Point(20 + c * 45, 20 + r * 45),
                        BorderStyle = BorderStyle.FixedSingle,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Segoe UI", 12),
                        Text = "0"
                    };

                    labels[r, c] = lbl;
                    Controls.Add(lbl);
                }
            }

            // Create buttons
            CreateButton("A", 20, 170, () => Add((0, 0), (0, 1), (1, 0), (1, 1)));
            CreateButton("B", 70, 170, () => Add((0, 1), (0, 2), (1, 1), (1, 2)));
            CreateButton("C", 120, 170, () => Add((1, 0), (1, 1), (2, 0), (2, 1)));
            CreateButton("D", 170, 170, () => Add((1, 1), (1, 2), (2, 1), (2, 2)));
            CreateButton("Reset", 20, 210, ResetBoard);
        }

        /// <summary>
        /// Helper to create buttons
        /// </summary>
        private void CreateButton(string text, int x, int y, Action action)
        {
            Button btn = new Button
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(45, 30)
            };

            btn.Click += (s, e) => action();
            Controls.Add(btn);
        }

        /// <summary>
        /// Increases selected cells by 1
        /// </summary>
        private void Add(params (int r, int c)[] cells)
        {
            foreach (var (r, c) in cells)
                board[r, c]++;

            DrawBoard();
        }

        /// <summary>
        /// Updates the UI
        /// </summary>
        private void DrawBoard()
        {
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    labels[r, c].Text = board[r, c].ToString();
        }

        /// <summary>
        /// Resets the board to zero
        /// </summary>
        private void ResetBoard()
        {
            board = new int[3, 3];
            DrawBoard();
        }
    }
}
