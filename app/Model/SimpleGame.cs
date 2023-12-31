﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.Model
{
    public class SimpleGame : GameBase
    {
        public SimpleGame(int size) : base()
        {
            Fields = new Field[size, size];
            for (int row = 0; row < size; row++)
                for (int col = 0; col < size; col++)
                    Fields[row, col] = new Field() { Row = row, Column = col, Owner = 0 };
            NumberOfPlayers = 2;

            InitializeGame();
        }
        public override void InitializeGame()
        {
            for (int row = 0; row < Fields.GetLength(0); row++)
                for (int col = 0; col < Fields.GetLength(1); col++)
                    Fields[row, col].Owner = 0;

            Fields[0, 0].Owner = 1;
            Fields[Fields.GetLength(0) - 1, Fields.GetLength(1) - 1].Owner = 2;
        }
    }
}
