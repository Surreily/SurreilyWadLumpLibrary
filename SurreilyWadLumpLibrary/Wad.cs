using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary
{

    /// <summary>
    /// Enum defining all WAD types.
    /// </summary>
    public enum WadType
    {
        Iwad,
        Pwad
    }

    /// <summary>
    /// A WAD file. Consists of multiple lumps (essentially just bits of data).
    /// </summary>
    public class Wad
    {

        /// <summary>
        /// Constructor for a WAD.
        /// </summary>
        /// <param name="type">The WAD's type.</param>
        public Wad(WadType type)
        {
            this.Type = type;
            this.Lumps = new List<Lump>();
        }

        /// <summary>
        /// The WAD's type.
        /// </summary>
        public WadType Type { get; set; }

        /// <summary>
        /// The WAD's lumps.
        /// </summary>
        public IList<Lump> Lumps { get; set; }

    }

}
