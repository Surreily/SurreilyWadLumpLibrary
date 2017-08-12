using Microsoft.VisualStudio.TestTools.UnitTesting;
using SurreilyWadLumpLibrary.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurreilyWadLumpLibrary.Test.File
{

    [TestClass]
    [DeploymentItem(@"TestData\testmap.wad", "TestData")]
    public class WadManagerTest
    {

        [TestMethod]
        public void Wads_Can_Be_Loaded()
        {

            // Load a WAD
            Wad wad = new WadManager().Load(@"TestData\testmap.wad");
            Assert.IsNotNull(wad);

            // Is the WAD the correct type?
            Assert.AreEqual(WadType.Pwad, wad.Type);

            // Does the WAD have the correct number of lumps?
            Assert.AreEqual(11, wad.Lumps.Count);

        }

        [TestMethod]
        public void Wad_Lumps_Have_The_Correct_Names()
        {

            // Load a WAD.
            Wad wad = new WadManager().Load(@"TestData\testmap.wad");
            Assert.IsNotNull(wad);

            // Are all lumps correctly named?
            Assert.AreEqual("MAP01", wad.Lumps[0].Name);
            Assert.AreEqual("THINGS", wad.Lumps[1].Name);
            Assert.AreEqual("LINEDEFS", wad.Lumps[2].Name);
            Assert.AreEqual("SIDEDEFS", wad.Lumps[3].Name);
            Assert.AreEqual("VERTEXES", wad.Lumps[4].Name);
            Assert.AreEqual("SEGS", wad.Lumps[5].Name);
            Assert.AreEqual("SSECTORS", wad.Lumps[6].Name);
            Assert.AreEqual("NODES", wad.Lumps[7].Name);
            Assert.AreEqual("SECTORS", wad.Lumps[8].Name);
            Assert.AreEqual("REJECT", wad.Lumps[9].Name);
            Assert.AreEqual("BLOCKMAP", wad.Lumps[10].Name);

        }

        [TestMethod]
        public void Wad_Lumps_Have_The_Correct_Types()
        {
            // Load a WAD.
            Wad wad = new WadManager().Load(@"TestData\testmap.wad");
            Assert.IsNotNull(wad);

            // Are all lumps the correct type?
            Assert.AreEqual(LumpType.Map, wad.Lumps[0].Type);
        }

    }
}
