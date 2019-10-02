using System;
using System.Collections.Generic;

namespace Hackathon {

    class Board {
        private Number[,] Grid; private Dictionary<string, Action> Dict;
        public Board() {
            Grid = new Number[4, 4];
            for (int x = 0; x < this.Grid.GetLength(0); x++) {
                for (int y = 0; y < this.Grid.GetLength(1); y++) {
                    Grid[x,y] = new Number();
            }}
            Dict = new Dictionary<string, Action>();
            Dict.Add("W", this.Up);
            Dict.Add("S", this.Down);
            Dict.Add("A", this.Left);
            Dict.Add("D", this.Right);
        }
        public void ReceiveInput(string input) {
            if (Dict.ContainsKey(input.ToUpper())) {
                this.Dict[input]();
                this.newTurn();
            }
            this.Display();
        }
        private List<int[]> GetEmpty() {
            List <int[]> ret = new List <int[]>();
            for (int x = 0; x < this.Grid.GetLength(0); x++) {
                for (int y = 0; y < this.Grid.GetLength(1); y++) {
                    if (this.Grid[x,y].Value == 0) {
                        int [] ele = {x,y};
                        ret.Add(ele);
            }}}
            return ret;
        }
        private void newTurn() {
            List <int[]> CurrentBoard = GetEmpty ();
            foreach (var item in CurrentBoard) {
                if (CurrentBoard.Count < 2) {
                    Number newEle = new Number();
                    newEle.AssignNumber();
                    this.Grid[item[0], item[1]] = newEle;
                } else {
                    this.Grid[item[0], item[1]] = new Number();
            }
        }}
        
        private void Up(){
            ShiftUp();
            for (int i = 0; i < this.Grid.GetLength(0); i++) {
                for (int j = 0; j < this.Grid.GetLength(0) - 1 ; j++) {
                    if (this.Grid[j, i].Mergable(this.Grid[j + 1, i])) {
                        this.Grid[j, i].Merge(this.Grid[j + 1, i]);
                        ShiftUp();
                    }
                }
            }
        }
        private void ShiftUp() {
            List<int> nums = new List<int>();
            for (int col = 0; col < this.Grid.GetLength(0); col++) {
                for (int row = 0; row < this.Grid.GetLength(0); row++) {
                    if(this.Grid[row, col].Value != 0) {
                        nums.Add(this.Grid[row, col].Value);
                        this.Grid[row, col].Destroy();
                    }
                }
                for(int i = 0; i < nums.Count; i++) {
                    this.Grid[i, col].Value = nums[i];
                }
                nums.Clear();
            }
        }
        private void Down() {
            ShiftDown();
            for (int i = 0; i < this.Grid.GetLength(0); i++) {
                for (int j = 3; j > 0 ; j--) {
                    if (this.Grid[j, i].Mergable(this.Grid[j - 1, i])) {
                        this.Grid[j, i].Merge(this.Grid[j - 1, i]);
                        ShiftDown();
                    }
                }
            }
        }

        private void ShiftDown() {
            List<int> nums = new List<int>();
            for (int col = 0; col < this.Grid.GetLength(0); col++) {
                for (int row = this.Grid.GetLength(0) - 1; row > -1; row--) {
                    if(this.Grid[row, col].Value != 0) {
                        nums.Add(this.Grid[row, col].Value);
                        this.Grid[row, col].Destroy();
                    }
                }
                for(int i = 0; i < nums.Count; i++) {
                    this.Grid[this.Grid.GetLength(0) - 1 - i, col].Value = nums[i];
                }
                nums.Clear();
            } 
        }
        private void ShiftLeft() {
            List<int> nums = new List<int>();
            for (int row = 0; row < this.Grid.GetLength(0); row++) {
                for (int col = 0; col < 4; col++) {
                    if(this.Grid[row, col].Value != 0) {
                        nums.Add(this.Grid[row, col].Value);
                        this.Grid[row, col].Destroy();
                    }
                }
                for(int i = 0; i < nums.Count; i++) {
                    this.Grid[row, i].Value = nums[i];
                }
                nums.Clear();
            } 
        }
        private void Left() {
            ShiftLeft();
            for (int i = 0; i < this.Grid.GetLength(0); i++) {
                for (int j = 0; j < 3; j++) {
                    if(this.Grid[i,j].Mergable(this.Grid[i,j+1])) {
                        this.Grid[i,j].Merge(this.Grid[i,j+1]);
                        ShiftLeft();
        }}}}
        private void Right() {
            ShiftRight();
            for (int i = 0; i < this.Grid.GetLength(0); i++) {
                for (int j = 3; j > 0 ; j--) {
                    if (this.Grid[i, j].Mergable(this.Grid[i, j-1])) {
                        this.Grid[i, j].Merge(this.Grid[i, j-1]);
                        ShiftRight();
        }}}}
        private void ShiftRight() {
            List<int> nums = new List<int>();
            for (int row = 0; row < this.Grid.GetLength(0); row++) {
                for (int col = this.Grid.GetLength(0) - 1; col >= 0; col--) {
                    if(this.Grid[row, col].Value != 0) {
                        nums.Add(this.Grid[row, col].Value);
                        this.Grid[row, col].Destroy();
                    }
                }
                for(int i = 0; i < nums.Count; i++) {
                    this.Grid[row, this.Grid.GetLength(0) - 1 - i].Value = nums[i];
                }
                nums.Clear();
        }}
        
        public void Display () {
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("--------------------------------------------");
            for (int row = 0; row < this.Grid.GetLength(0); row++) {
                string line = "||";
                for (int col = 0; col < this.Grid.GetLength(1); col++) {
                    line+= $"{this.Grid[row, col].Value}".PadLeft(10, ' ');
                }
                line += "||";
                System.Console.WriteLine(line);
            }
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("--------------------------------------------");
            System.Console.WriteLine("");
            System.Console.WriteLine("");
        }
        
        public bool NotMergable () {
            for (int row = 0; row < this.Grid.GetLength(0); row++) {
                int curCol = 0;

                while (curCol < 4) {
                    if(row + 1 < 4) {
                        if (this.Grid[row, curCol].Mergable(this.Grid[row + 1, curCol])) {
                            return false;
                        }
                    }
                    if (curCol + 1 < 4) {
                        if (this.Grid[row, curCol].Mergable(this.Grid[row, curCol+1])) {
                            return false;
                        }
                    }
                    curCol++;
                }
            }
            return true;
        }
        public bool GameOver() {
            if (NotMergable() && GetEmpty().Count == 0) {
                return true;
            }
            return false;
        }

    }
}

