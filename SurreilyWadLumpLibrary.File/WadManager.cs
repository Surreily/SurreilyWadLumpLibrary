using SurreilyWadLumpLibrary.File.LumpLoader;
using SurreilyWadLumpLibrary.Lumps;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.File
{

    public class WadManager
    {

        

        protected IList<ILumpLoader> _loaders { get; set; }

        public WadManager()
        {

            // Initialize the loaders list.
            this._loaders = new List<ILumpLoader>();

            // Populate the loaders list with default loaders.
            this._loaders.Add(new MapLumpLoader());
            this._loaders.Add(new UnknownLumpLoader());

        }

        public Wad Load(string path)
        {

            // Begin a file stream.
            using (BinaryReader reader = new BinaryReader(new FileStream(path, FileMode.Open)))
            {

                // Read WAD header information.
                byte[] type = reader.ReadBytes(4);
                int directoryCount = reader.ReadInt32();
                int directoryOffset = reader.ReadInt32();

                // Construct the WAD file based on the type's first character.
                Wad wad;
                switch(type[0])
                {

                    case (byte) 'I':
                        wad = new Wad(WadType.Iwad);
                        break;

                    case (byte) 'P':
                        wad = new Wad(WadType.Pwad);
                        break;

                    default:
                        throw new Exception("WAD file format is not supported.");
                    
                }

                // Move the reader's position to the directory.
                reader.BaseStream.Position = directoryOffset;

                // Read the directory.
                IList<DirectoryEntry> directory = new List<DirectoryEntry>();
                for (int index = 0; index < directoryCount; index++)
                {

                    // Read the lump offset, the lump size, and the lump's name
                    // (in that order) and store it in the directory.
                    directory.Add(new DirectoryEntry(
                        reader.ReadInt32(),
                        reader.ReadInt32(),
                        System.Text.Encoding.UTF8.GetString(
                        reader.ReadBytes(8)).TrimEnd('\0')
                    ));

                }

                // Add a null entry in the directory, purely to prevent us
                // going out of bounds or having to check for it every time.
                directory.Add(null);

                // Go over the directory again, this time loading lumps.
                for (int index = 0; index < directoryCount; index++)
                {

                    // Jump to the lump offset.
                    reader.BaseStream.Position = directory[index].Offset;

                    // Load the correct lump type.
                    foreach (ILumpLoader loader in this._loaders)
                    {
                        if (loader.CanLoad(reader, directory[index], directory[index+1]))
                        {
                            wad.Lumps.Add(loader.Load(reader, directory[index]));
                            break;
                        }
                    }

                }

                // Return the complete WAD.
                return wad;

            }

        }

    }

}
