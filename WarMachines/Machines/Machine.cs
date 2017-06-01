﻿namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        private string name;
        private IPilot pilot;
        private int healthPoints;
        private int attackPoints;
        private int defensePoints;
        private IList<string> targets;

        public Machine(string name, int healthPoints, int attackPoints, int defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Pilot cannot be null.");
                }

                this.pilot = value;
            }
        }

        public int HealthPoints
        {
            get
            {
                return this.healthPoints;
            }

            set
            {
                this.healthPoints = value;
            }
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }

            protected set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get
            {
                return this.defensePoints;
            }

            protected set
            {
                this.defensePoints = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("List of targets cannot be null.");
                }

                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            var result = string.Format("- {0}\n *Type: {1}\n *Health: {2}\n *Attack: {3}\n *Defense: {4}\n *Targets: {5}",
                this.Name, this.GetType().Name, this.HealthPoints, this.AttackPoints, this.DefensePoints, this.Targets.Count != 0 ? string.Join(", ", this.Targets) : "None");

            return result;
        }
    }
}
