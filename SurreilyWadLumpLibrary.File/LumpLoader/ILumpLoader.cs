using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.File.LumpLoader
{

    /// <summary>
    /// A lump loader.
    /// </summary>
    public interface ILumpLoader
    {

        /// <summary>
        /// Indicates whether this reader can load the given lump.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <param name="entry">The lump's directory entry.</param>
        /// <param name="next">The next lump's directory entry.</param>
        /// <returns>True if the loader can load the lump, otherwise false.</returns>
        bool CanLoad(BinaryReader reader, DirectoryEntry entry, DirectoryEntry next);

        /// <summary>
        /// load the given lump.
        /// </summary>
        /// <param name="reader">The binary reader.</param>
        /// <param name="entry">The lump's directory entry.</param>
        /// <returns>The lump.</returns>
        Lump Load(BinaryReader reader, DirectoryEntry entry);

    }

}
