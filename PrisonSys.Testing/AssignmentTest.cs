using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrisonSys.Model;
using PrisonSys.DAL;
using PrisonSys.Controller;
using PrisonSys.Interface;

namespace PrisonSys.Testing
{
    [TestClass]
    public class AssignmentTest
    {
        [TestMethod]
        public void AddSupervisorTest()
        {
            Supervisor supervisor = new Supervisor("TestName", "TestSurname");
            Assignment assignment = new Assignment("Test", supervisor);
            Assert.AreEqual("TestName", assignment.AssignmentSupervisor.FirstName);
        }
        [TestMethod]
        public void RemoveSupervisorTest()
        {
            Supervisor supervisor = new Supervisor("TestName", "TestSurname");
            Assignment assignment = new Assignment("Test", supervisor);
            assignment.AssignmentSupervisor = null;
            Assert.AreEqual(null, assignment.AssignmentSupervisor);
        }

    }
}

