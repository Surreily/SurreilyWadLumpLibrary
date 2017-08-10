using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.Lumps
{

    public class UnknownLump : Lump
    {

        /// <summary>
        /// Constructor for an unknown lump.
        /// </summary>
        /// <param name="name">The lump's name.</param>
        /// <param name="data">The lump's raw data.</param>
        public UnknownLump(string name, byte[] data) : base(name)
        {
            this.Data = data;
        }

        /// <summary>
        /// The lump's raw data.
        /// </summary>
        public byte[] Data { get; set; }

        public override LumpType Type
        {
            get { return LumpType.Unknown; }
        }

        public override int Size
        {
            get
            {
                // This lump's size is just the length of its data.
                return this.Data.Length;
            }
        }

    }

}
