﻿using helpmebot6.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using helpmebot6;

namespace HelpmebotTestHarness
{
    
    
    /// <summary>
    ///This is a test class for SayhiTest and is intended
    ///to contain all SayhiTest Unit Tests
    ///</summary>
    [TestClass( )]
    public class SayhiTest
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
            Sayhi_Accessor target = new Sayhi_Accessor( ); // TODO: Initialize to an appropriate value
            User toUser = null; // TODO: Initialize to an appropriate value
            string channel = string.Empty; // TODO: Initialize to an appropriate value
            string[ ] args = null; // TODO: Initialize to an appropriate value
            CommandResponseHandler_Accessor expected = null; // TODO: Initialize to an appropriate value
            CommandResponseHandler_Accessor actual;
            actual = target.execute( toUser, channel, args );
            Assert.AreEqual( expected, actual );
            Assert.Inconclusive( "Verify the correctness of this test method." );
        }

        /// <summary>
        ///A test for Sayhi Constructor
        ///</summary>
        [TestMethod( )]
        public void SayhiConstructorTest( )
        {
            Sayhi target = new Sayhi( );
            Assert.Inconclusive( "TODO: Implement code to verify target" );
        }
    }
}
