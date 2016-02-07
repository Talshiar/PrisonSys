using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonSys.Model;
using PrisonSys.DAL;
using PrisonSys.Controller;
using PrisonSys.Interface;

namespace PrisonSys.Testing
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void AddCellblockTest()
        {
            Cellblock cellblock = new Cellblock("TestBlock");
            Cell cell = new Cell(4, 4, cellblock);
            Assert.AreEqual("TestBlock", cell.CellBlock.Name);
        }
        [TestMethod]
        public void RemoveCellblockTest()
        {
            Cellblock cellblock = new Cellblock("TestBlock");
            Cell cell = new Cell(4, 4, cellblock);
            cell.CellBlock = null;
            Assert.AreEqual(null, cell.CellBlock);
        }
    }
}

