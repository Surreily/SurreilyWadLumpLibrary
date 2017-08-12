using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.File
{

    /// <summary>
    /// A directory entry. This is only used as the WAD is being constructed.
    /// </summary>
    public class DirectoryEntry
    {

        public DirectoryEntry(int offset, int size, string name)
        {
            _offset = offset;
            _size = size;
            _name = name;
        }

        private readonly int _offset;
        public int Offset { get { return _offset; } }

        private readonly int _size;
        public int Size { get { return _size; } }

        private readonly string _name;
        public string Name { get { return _name; } }


    }

}
