﻿// /****************************************************************************
//  *   This file is part of Helpmebot.                                        *
//  *                                                                          *
//  *   Helpmebot is free software: you can redistribute it and/or modify      *
//  *   it under the terms of the GNU General Public License as published by   *
//  *   the Free Software Foundation, either version 3 of the License, or      *
//  *   (at your option) any later version.                                    *
//  *                                                                          *
//  *   Helpmebot is distributed in the hope that it will be useful,           *
//  *   but WITHOUT ANY WARRANTY; without even the implied warranty of         *
//  *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the          *
//  *   GNU General Public License for more details.                           *
//  *                                                                          *
//  *   You should have received a copy of the GNU General Public License      *
//  *   along with Helpmebot.  If not, see <http://www.gnu.org/licenses/>.     *
//  ****************************************************************************/
#region Usings
using System.Reflection;

#endregion

namespace helpmebot6.Commands
{
    internal class Oauth : GenericCommand
    {
        protected override CommandResponseHandler execute(User source, string channel, string[] args)
        {
            Logger.instance( ).addToLog(
                "Method:" + MethodBase.GetCurrentMethod( ).DeclaringType.Name + MethodBase.GetCurrentMethod( ).Name,
                Logger.LogTypes.DNWB );


            if ( args.Length == 1  && args[0] != "")
            {
                new Twitter( ).authorise( args[ 0 ] );
            }
            else
            {
                new Twitter( );
            }

            return new CommandResponseHandler( Configuration.singleton( ).getMessage( "done" ) );
        }
    }
}