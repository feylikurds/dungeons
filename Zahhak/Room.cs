/*
Zahhak, a C# 6.0 coding example in form of a console game.
Copyright (C) 2016 Aryo Pehlewan aryopehlewan@hotmail.com

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zahhak
{
    internal class Room : GameObject
    {
        protected const string NAME = "Room";
        protected const string SYMBOL = "R";
        protected const int CAPACITY = 2;

        private readonly int capacity;
        private List<GameObject> gameObjects = new List<GameObject>();

        public Room(int capacity = CAPACITY, string name = NAME, string symbol = SYMBOL) : base(name, symbol)
        {
            this.capacity = capacity;
        }

        public Room(string name = NAME, string symbol = SYMBOL, int capacity = CAPACITY) : base(name, symbol)
        {
            this.capacity = capacity;
        }

        public bool HasRoomForTwo()
        {
            var n = capacity - gameObjects.Count;

            if (n >= 2)
                return true;

            return false;
        }

        public bool Enter(GameObject gameObject)
        {
            var numGameObjects = gameObjects.Count;

            if (numGameObjects >= capacity)
                return false;

            gameObjects.Add(gameObject);

            return true;
        }

        public void Leave(GameObject gameObject)
        {
            gameObjects.Remove(gameObject);
        }

        public List<GameObject> GetGameObjects()
        {
            return gameObjects;
        }

        public IEnumerable<Health> GetHealths()
        {
            var healths = gameObjects.Where(gameObject => gameObject is Health).Cast<Health>();

            return healths;
        }

        public IEnumerable<Strength> GetStrengths()
        {
            var strengths = gameObjects.Where(gameObject => gameObject is Strength).Cast<Strength>();

            return strengths;
        }

        public IEnumerable<Treasure> GetTreasures()
        {
            var treasures = gameObjects.Where(gameObject => gameObject is Treasure).Cast<Treasure>();

            return treasures;
        }

        public IEnumerable<Creature> GetCreatures()
        {
            var creatures = gameObjects.Where(gameObject => gameObject is Creature).Cast<Creature>();

            return creatures;
        }
    }
}
