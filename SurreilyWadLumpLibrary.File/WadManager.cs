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

        public static Wad Load(string path)
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

                // Iterate through the directory.
                reader.BaseStream.Position = directoryOffset;
                for (int index=0; index<directoryCount; index++)
                {

                    // Read lump information.
                    int lumpOffset = reader.ReadInt32();
                    int lumpSize = reader.ReadInt32();
                    string name = System.Text.Encoding.UTF8.GetString(
                        reader.ReadBytes(8)).TrimEnd('\0');

                    // Add the lump.
                    wad.Lumps.Add(new MarkerLump(name));

                }

                // Return the complete WAD file.
                return wad;

            }

        }

    }

}
