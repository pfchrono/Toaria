﻿using System;
using System.IO;

namespace Terraria
{
    public static class Statics
    {
        public const int BUILD = 1701;
        public const int CURRENT_TERRARIA_RELEASE = 1601;
        public static string CURRENT_TERRARIA_RELEASE_STR = CURRENT_TERRARIA_RELEASE.ToString();

        private const String WORLDS = "Worlds";
        private const String PLUGINS = "Plugins";
        private const String DATA = "Data";

        public static bool cmdMessages = true;
        public static bool keepRunning = false;

        public static volatile bool IsActive = false;
        public static volatile bool serverStarted = false;

        public static String SavePath = Environment.CurrentDirectory;

        public static String WorldPath
        {
            get
            {
                return SavePath + Path.DirectorySeparatorChar + WORLDS;
            }
        }

        public static String PluginPath
        {
            get
            {
                return SavePath + Path.DirectorySeparatorChar + PLUGINS;
            }
        }

        public static String DataPath
        {
            get
            {
                return SavePath + Path.DirectorySeparatorChar + DATA;
            }
        }
    }
}
