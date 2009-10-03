﻿using System;
using System.Collections.Generic;
using System.Text;

namespace helpmebot6.Commands
{
    class Count : GenericCommand
    {
        public Count( )
        {
            accessLevel = GlobalFunctions.commandAccessLevel( "count" );
        }

        protected override void execute( User source , string destination , string[ ] args )
        {
            if( args.Length > 0 )
            {
                string userName = string.Join( " " , args );
                int editCount = getEditCount( userName );
                if( editCount == -1 )
                {
                    string message = Configuration.Singleton( ).GetMessage( "noSuchUser" , userName );
                    IAL.singleton.IrcPrivmsg( destination , message );
                }
                else
                {


                    string[ ] messageParameters = { editCount.ToString( ) , userName };

                    string message = Configuration.Singleton( ).GetMessage( "editCount" , messageParameters );

                    IAL.singleton.IrcPrivmsg( destination , message );
                }
            }
            else
            {
                string[ ] messageParameters = { "count" , "1" , args.Length.ToString( ) };
                IAL.singleton.IrcNotice( source.Nickname , Configuration.Singleton( ).GetMessage( "notEnoughParameters" , messageParameters ) );
            }
        }

        public int getEditCount( string username )
        {
            if( username == string.Empty )
            {
                throw new ArgumentNullException( );
            }

            string baseWiki = Configuration.Singleton( ).retrieveGlobalStringOption( "baseWiki" );

            string api = DAL.Singleton( ).ExecuteScalarQuery( "SELECT `site_api` FROM `site` WHERE `site_id` = " + baseWiki + ";" );


            System.Xml.XmlTextReader creader = new System.Xml.XmlTextReader( api + "?format=xml&action=query&list=users&usprop=editcount&format=xml&ususers=" + username );
            do
            {
                creader.Read( );
            } while( creader.Name != "user" );
            string editCount = creader.GetAttribute( "editcount" );
            if( editCount != null )
            {
                return int.Parse( editCount );
            }
            else
            {
                if( creader.GetAttribute( "missing" ) == "" )
                {
                    return -1;
                }
                else
                {
                    throw new ArgumentException( );
                }
            }


        }
    }
}