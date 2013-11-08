using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class GridNode
    {
        public GridPoint Value;

        public GridNode North;
        public GridNode South;
        public GridNode East;
        public GridNode West;
        public GridNode Up;
        public GridNode Down;

        public GridNode(GridPoint Value)
        {
            this.Value = Value;
        }

        public GridNode(GridPoint Value, GridNode[] Nodes)
        {
            this.Value = Value;
            North = Nodes[0];
            South = Nodes[1];
            East = Nodes[2];
            West = Nodes[3];
            Up = Nodes[4];
            Down = Nodes[5];
        }
    }
}
