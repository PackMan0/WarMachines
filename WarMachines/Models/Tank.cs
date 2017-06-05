namespace WarMachines.Models
{
    public class Tank : Machine, ITank
    {
        private bool _defenseMode = true;

        public Tank(string name, int attackPoints, int defensePoints) 
            : base(name, 100, attackPoints, defensePoints)
        {
        }

        public bool DefenseMode
        {
            get
            {
                return this._defenseMode;
            }

            private set
            {
                this._defenseMode = value;
            }
        }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                this.DefensePoints -= 30;
                this.AttackPoints += 40;
            }
            else
            {
                this.DefenseMode = true;
                this.DefensePoints += 30;
                this.AttackPoints -= 40;
            }
        }

        public override string ToString()
        {
            return base.ToString() + string.Format("\n *Defense: {0}", this.DefenseMode ? "ON" : "OFF");
        }
    }
}
