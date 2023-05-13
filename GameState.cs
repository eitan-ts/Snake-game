﻿using System;
using System.Collections.Generic;

namespace Snake
{
    public class GameState
    {
        public int Rows { get; }
        public int Cols { get; }
        public GridValue[,] Grid { get; }
        public Direction Dir { get; private set; }
        public int Score { get; private set; }
        public bool GameOver { get; private set; }

        private readonly LinkedList<Position> snakePosition = new LinkedList<Position>(); 
        private readonly  Random random = new Random();

        public GameState(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Grid = new GridValue[rows, cols];
            Dir = Direction.Right;

            AddSnake();
        }

        private void AddSnake()
        {
            int r = Rows / 2;

            for(int c = 0; c < 3; c++)
            {
                Grid[r, c] = GridValue.Snake;
                snakePosition .AddFirst(new Position(r, c));

            }
        }

        private IEnumerable<Position> EmptyPosition()
        {
            for(int r = 0; r < Rows; r++)
            {
                for(int c =0; c< Cols; c++)
                {
                    if (Grid[r, c] == GridValue.Empty)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(EmptyPosition());

            if(empty.Count == 0)
            {
                return;
            }
            
            Position pos = empty[random.Next(empty.Count)];
            Grid[pos.Row, pos.Col] = GridValue.Food;
        }
    }
}
