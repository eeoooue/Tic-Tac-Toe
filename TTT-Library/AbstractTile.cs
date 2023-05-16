﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TTT_Library
{
    public abstract class AbstractTile
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public char Character { get; protected set; }
        public bool Marked { get; protected set; }

        public AbstractTile(int row, int column)
        {
            Row = row;
            Column = column;
            Character = ' ';
        }

        public abstract void Mark();
    }
}
