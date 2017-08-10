using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary
{

    /// <summary>
    /// Enum defining all lump types.
    /// </summary>
    public enum LumpType
    {
        
        // Maps
        Map,

        // Misc.
        Marker,
        Unknown

    }

    /// <summary>
    /// A lump inside a WAD file.
    /// </summary>
    public abstract class Lump
    {

        /// <summary>
        /// Constructor for a lump.
        /// </summary>
        /// <param name="name">The lump's name.</param>
        public Lump(string name)
        {

            // Reject a null name.
            if (name == null)
                throw new ArgumentNullException("Name cannot be null.");

            // Set the name.
            this._name = name;

        }

        
        /// <summary>
        /// The lump's name. Cannot exceed 8 characters in length.
        /// </summary>
        public string Name {
            get
            {
                return this._name;
            }
            set
            {
                if (value.Length > 8)
                    this._name = value.Substring(0, 8);
                else
                    this._name = value;
            }
        }
        private string _name;

        /// <summary>
        /// The lump's type.
        /// </summary>
        public abstract LumpType Type { get; }

        /// <summary>
        /// The lump's size in bytes.
        /// </summary>
        public abstract int Size { get; }

    }

}
