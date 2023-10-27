using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB10_MAUI_AttaxxPlus.Model
{
    public abstract class GameBase: ObservableObject
    {
        public GameBase()
        { }
        public abstract void InitializeGame();
        public Field[,]Fields { get; protected set; }
        public int NumberOfPlayers { get; protected set; }
        private int currentPlayer = 1;
        public int CurrentPlayer
        {
            get { return currentPlayer; }
            set
            {
                if (currentPlayer != value)
                {
                    currentPlayer = value;
                    Notify();
                }
            }
        }
        private int? winner = null;
        public int? Winner
        {
            get { return winner; }
            set 
            {
                if (winner != value)
                {
                    winner = value; 
                    Notify();
                    Notify(nameof(IsGameRunning));
                } 
            }
        }
        public bool IsGameRunning => Winner is null;
        public void EndOfTurn()
        {
            if(!CheckGameOver())
            {
                if (CurrentPlayer < NumberOfPlayers)
                    CurrentPlayer++;
                else
                    CurrentPlayer = 1;
            }
        }
        private bool CheckGameOver()
        {
            Winner = null;
            int[] counts = new int[NumberOfPlayers + 1];
            foreach (var f in Fields)
                counts[f.Owner]++;

            int totalFieldCount = Fields.GetLength(0) * Fields.GetLength(1);

            int playerWithMaxFields = 0;
            int maxFieldCountPerPlayer = 0;
            for (int i = 1; i < counts.Length; i++)
                if (counts[i] > maxFieldCountPerPlayer)
                {
                    playerWithMaxFields = i;
                    maxFieldCountPerPlayer = counts[i];
                }

         
            int othersFieldCount = totalFieldCount - counts[0] - maxFieldCountPerPlayer;
            if (othersFieldCount == 0)
            {
                Winner = playerWithMaxFields;
                return true;
            }

            if (maxFieldCountPerPlayer == totalFieldCount || counts[0] == 0)
            {
                
                Winner = (counts.Count(c => c == maxFieldCountPerPlayer) == 1)
                    ? playerWithMaxFields : 0;
                return true;
            }
            return false;
        }
    }
}

