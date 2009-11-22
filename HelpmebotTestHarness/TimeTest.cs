﻿using helpmebot6.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using helpmebot6;

namespace HelpmebotTestHarness
{
    
    
    /// <summary>
    ///This is a test class for TimeTest and is intended
    ///to contain all TimeTest Unit Tests
    ///</summary>
    [TestClass( )]
    public class TimeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for execute
        ///</summary>
        [TestMethod( )]
        [DeploymentItem( "helpmebot6.exe" )]
        public void executeTest( )
        {
            Time_Accessor target = new Time_Accessor( ); // TODO: Initialize to an appropriate value
            User source = null; // TODO: Initialize to an appropriate value
            string channel = string.Empty; // TODO: Initialize to an appropriate value
            string[ ] args = null; // TODO: Initialize to an appropriate value
            CommandResponseHandler_Accessor expected = null; // TODO: Initialize to an appropriate value
            CommandResponseHandler_Accessor actual;
            actual = target.execute( source, channel, args );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "Verify the correctness of this test method." );
        }

        /// <summary>
        ///A test for Time Constructor
        ///</summary>
        [TestMethod( )]
        public void TimeConstructorTest( )
        {
            Time target = new Time( );
            Assert.Inconclusive( "TODO: Implement code to verify target" );
        }
    }
}
