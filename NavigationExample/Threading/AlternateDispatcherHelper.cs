﻿//based on the file DispatcherHelper.cs

// ****************************************************************************
// <copyright file="DispatcherHelper.cs" company="GalaSoft Laurent Bugnion">
// Copyright © GalaSoft Laurent Bugnion 2009-2016
// </copyright>
// ****************************************************************************
// <author>Laurent Bugnion</author>
// <email>laurent@galasoft.ch</email>
// <date>25.03.2015</date>
// <project>GalaSoft.MvvmLight</project>
// <web>http://www.mvvmlight.net</web>
// <license>
// See license.txt in this solution or http://www.galasoft.ch/license_MIT.txt
// </license>
// <LastBaseLevel>BL0004</LastBaseLevel>
// ****************************************************************************

using System;
using System.Text;
using GalaSoft.MvvmLight.Views;

using Plugin.CurrentActivity;

namespace NavigationExample
{
    /// <summary>
    /// Helper class for dispatcher operations on the UI thread in Android.
    /// </summary>
    //// [ClassInfo(typeof(AlternateDispatcherHelper))]
    public static class AlternateDispatcherHelper
    {
        /// <summary>
        /// Executes an action on the UI thread. If this method is called
        /// from the UI thread, the action is executed immendiately. If the
        /// method is called from another thread, the action will be enqueued
        /// on the UI thread's dispatcher and executed asynchronously.
        /// </summary>
        /// <param name="action">The action that will be executed on the UI
        /// thread.</param>
        // ReSharper disable InconsistentNaming
        public static void CheckBeginInvokeOnUI(Action action)
        // ReSharper restore InconsistentNaming
        {
            if (action == null)
            {
                return;
            }

            CheckDispatcher();
            //ActivityBase.CurrentActivity.RunOnUiThread(action);
            CrossCurrentActivity.Current.Activity.RunOnUiThread(action);
        }

        /// <summary>
        /// This method is only here for compatibility with
        /// other platforms but it doesn't do anything.
        /// </summary>
        public static void Initialize()
        {
        }

        /// <summary>
        /// This method is only here for compatibility with
        /// other platforms but it doesn't do anything.
        /// </summary>
        public static void Reset()
        {
        }

        private static void CheckDispatcher()
        {
            //if (ActivityBase.CurrentActivity == null)
            if (CrossCurrentActivity.Current.Activity == null)
            {
                var error = new StringBuilder("The DispatcherHelper cannot be called.");
                //error.AppendLine();
                //error.Append("Make sure that your main Activity derives from ActivityBase.");

                throw new InvalidOperationException(error.ToString());
            }
        }
    }
}

