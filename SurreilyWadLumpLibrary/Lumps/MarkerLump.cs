using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.Lumps
{

    public class MarkerLump : Lump
    {

        /// <summary>
        /// Constructor for a marker.
        /// </summary>
        /// <param name="name">The marker's name.</param>
        public MarkerLump(string name) : base(name) { }

        public override LumpType Type
        {
            get { return LumpType.Marker; }
        }

        public override int Size
        {
            get
            {
                // Markers have no data, so return 0.
                return 0;
            }
        }

    }

}
