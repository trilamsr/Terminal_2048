using System;

namespace Hackathon
{
    class Number
    {
        static Random rng = new Random();
        public int Value { get; set; }
        public Number() {
            this.Value = rng.Next(0,8) >= 2 ? 0 : rng.Next(0,2) == 0 ? 2 : 4;
        }
        public void Merge(Number target) {
            if (this.Value == target.Value) {
                this.Value += target.Value;
                target.Destroy();
            }
        }
        public void Destroy () {
            this.Value = 0;
        }
        public void AssignNumber () {
            this.Value = rng.Next(0,2) == 0 ? 2 : 4;
        }
        public bool Mergable (Number target) {
            return this.Value == target.Value;
        }
    }
}