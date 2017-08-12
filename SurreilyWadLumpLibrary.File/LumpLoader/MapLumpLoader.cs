using SurreilyWadLumpLibrary.Lumps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.File.LumpLoader
{

    public class MapLumpLoader : ILumpLoader
    {

        public bool CanLoad(BinaryReader reader, DirectoryEntry entry, DirectoryEntry next)
        {

            // If this lump has data, this cannot be a map lump.
            if (entry.Size != 0) return false;

            // If this is the last node, this cannot be a map lump.
            if (next == null) return false;

            // If this lump has map data after it, it is a map lump.
            if (next.Name == "THINGS" || next.Name == "TEXTMAP") return true;

            // Otherwise, return false.
            return false;

        }

        public Lump Load(BinaryReader reader, DirectoryEntry entry)
        {
            return new MapLump(entry.Name);
        }

    }

}
