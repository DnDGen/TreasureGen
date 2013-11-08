using System;
using System.Collections.Generic;
using System.Text;

namespace Dungeon_Maker
{
    class GridPoint
    {
        public enum TYPE {WALL, DOOR, ROOM, AVAILABLE};
        public TYPE Type;

        public GridPoint()
        {
            Type = TYPE.AVAILABLE;
        }

        public GridPoint(TYPE Type)
        {
            this.Type = Type;
        }

        public bool Used()
        {
            if (Type == TYPE.AVAILABLE || Type == TYPE.WALL)
                return false;
            return true;
        }
    }
}
