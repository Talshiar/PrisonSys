using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonSys.Model;
using PrisonSys.DAL;

namespace PrisonSys.Testing
{
    [TestClass]
    class PrisonerRepositoryTest
    {
        /// <summary>
        /// Test method tests the following:
        /// 1. Successfully calling a Prisoner constructor
        /// 2. Getting an assignment by index
        /// 3. Getting a cell by index
        /// 4. Adding a prisoner to the database
        /// 5. Getting a prisoner by his first and last name
        /// 6. Removing the prisoner from the database
        /// </summary>
        [TestMethod]
        public void AddThenRemovePrisonerTest()
        {
            PrisonerRepository prisTestRepo = new PrisonerRepository();
            AssignmentRepository assignTestRepo = new AssignmentRepository();
            CellRepository cellTestRepo = new CellRepository();

            string fName = "Name";
            string lName = "Last";
            string adr = "Test adress";
            DateTime from = new DateTime(2016, 2, 10);
            DateTime to = new DateTime(2018, 5, 21);
            string reason = "Testtesttest";
            int idAssign = 1;
            int idCell = 1;
            Prisoner prisoner = new Prisoner(fName, lName, adr, from, to, reason);
            prisoner.PrisonerAssignment = assignTestRepo.GetAssignmentByIndex(1);
            prisoner.PrisonerCell = cellTestRepo.GetCellByIndex(1);
            prisTestRepo.Add(fName, lName, adr, from, to, reason, idAssign, idCell);
            Assert.AreEqual(prisoner, prisTestRepo.GetByName("Name", "Last"));
        }
    }
}

