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

using System;
using System.Collections;
using System.Reflection;
using System.Threading;

#endregion

namespace helpmebot6.Threading
{
    internal class ThreadList
    {
        private static ThreadList _instance;

        public static ThreadList instance()
        {
            return _instance ?? ( _instance = new ThreadList( ) );
        }

        protected ThreadList()
        {
            this._threadedObjects = new ArrayList();
        }

        private readonly ArrayList _threadedObjects;

        public void register(IThreadedSystem sender)
        {
            Logger.instance().addToLog(
                "Method:" + MethodBase.GetCurrentMethod().DeclaringType.Name + MethodBase.GetCurrentMethod().Name,
                Logger.LogTypes.DNWB);

            this._threadedObjects.Add(sender);
        }

        public void stop()
        {
            Logger.instance().addToLog(
                "Method:" + MethodBase.GetCurrentMethod().DeclaringType.Name + MethodBase.GetCurrentMethod().Name,
                Logger.LogTypes.DNWB);

            Thread shutdownControllerThread
                = new Thread(this.shutdownMethod);

            shutdownControllerThread.Start();
        }

        private void shutdownMethod()
        {
            Logger.instance().addToLog(
                "Method:" + MethodBase.GetCurrentMethod().DeclaringType.Name + MethodBase.GetCurrentMethod().Name,
                Logger.LogTypes.DNWB);

            foreach (object obj in this._threadedObjects)
            {
                try
                {
                    Logger.instance().addToLog("Attempting to shut down threaded system: " + obj.GetType(),
                                               Logger.LogTypes.General);
                    ((IThreadedSystem) obj).stop();
                }
                catch (NotImplementedException ex)
                {
                    GlobalFunctions.errorLog(ex);
                }
            }

            Logger.instance().addToLog("All threaded systems have been shut down.", Logger.LogTypes.General);
        }

        public string[] getAllThreadStatus()
        {
            Logger.instance().addToLog(
                "Method:" + MethodBase.GetCurrentMethod().DeclaringType.Name + MethodBase.GetCurrentMethod().Name,
                Logger.LogTypes.DNWB);

            ArrayList responses = new ArrayList();
            foreach (IThreadedSystem item in this._threadedObjects)
            {
                string status = item.GetType() + ": ";
                try
                {
                    foreach (string i in item.getThreadStatus())
                    {
                        responses.Add(status + i);
                    }
                }
                catch (NotImplementedException)
                {
                    status += "Not available.";
                    responses.Add(status);
                }
            }

            string[] responseArray = new string[responses.Count];

            responses.CopyTo(responseArray);

            return responseArray;
        }
    }
}