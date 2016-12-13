using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobLogger;
using LoggerTests.Utility;
using System.Diagnostics;

namespace LoggerTests
{
    [TestClass]
    public class LoggerTest
    {

        [TestInitialize]
        public void TestInit()
        {
            ConsoleHelper.InitTestConsole();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            ConsoleHelper.ResetTestConsole();
        }


        [TestMethod]
        public void ConsoleLogCreated()
        {
            string message = "Test Console Message 001";
            var oJobLogger = new Logger(LogType.CONSOLE, SeverityLevel.WARNING);
            oJobLogger.LogMessage(message);

            string consoleOutput = ConsoleHelper.GetConsoleOutput();
            
            Assert.IsTrue(consoleOutput.Contains(message));
        }

        [TestMethod]
        public void FileLogCreated()
        {
            //Delete Current Log File
            var fileHelper = new FileHelper();
            fileHelper.DeleteCurrentLogFile();
            
            string message = "Test File Message 001";
            var oJobLogger = new Logger(LogType.FILE, SeverityLevel.ERROR);
            oJobLogger.LogMessage(message);

            //Existe Log File?
            Assert.IsTrue(fileHelper.ExistLogFile());
        }

        [TestMethod]
        public void DataBaseLogCreated()
        {
            //Empty Log Table
            var dataHelper = new DataHelper();
            dataHelper.EmptyLogTable();

            string message = "Test DataBase Message 001";
            var oJobLogger = new Logger(LogType.DATABASE, SeverityLevel.WARNING);
            oJobLogger.LogMessage(message);

            //IsLogEmpty
            Assert.IsFalse(dataHelper.IsLogEmpty());
        }
    }
}
