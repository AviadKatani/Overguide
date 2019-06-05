﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MediaManager;
using UIKit;

namespace Overguide.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        private static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
            CrossMediaManager.Current.Init();
        }
    }
}