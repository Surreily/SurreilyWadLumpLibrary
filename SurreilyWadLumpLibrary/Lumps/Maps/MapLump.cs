using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.Lumps.Maps
{

    public class MapLump : Lump
    {

        /// <summary>
        /// Constructor for a map marker.
        /// </summary>
        /// <param name="name">The map's name.</param>
        public MapLump(string name) : base(name) { }

        public override LumpType Type
        {
            get { return LumpType.Map; }
        }

        public override int Size
        {
            get
            {
                // Map markers have no data, so return 0.
                return 0;
            }
        }

    }

}
