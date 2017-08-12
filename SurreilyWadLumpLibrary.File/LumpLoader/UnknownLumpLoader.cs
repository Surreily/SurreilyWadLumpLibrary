using SurreilyWadLumpLibrary.Lumps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.File.LumpLoader
{

    public class UnknownLumpLoader : ILumpLoader
    {

        public bool CanLoad(BinaryReader reader, DirectoryEntry entry, DirectoryEntry next)
        {
            return true;
        }

        public Lump Load(BinaryReader reader, DirectoryEntry entry)
        {
            return new UnknownLump(entry.Name, reader.ReadBytes(entry.Size));
        }

    }

}
