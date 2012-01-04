﻿using System;
using System.IO;
using System.Net;
using System.Threading;
using Toaria;

namespace TShockAPI
{
	public class StatTracker
	{
		Utils Utils = TShock.Utils;
		public DateTime lastcheck = DateTime.MinValue;
		readonly int checkinFrequency = 5;

		public void checkin()
		{
            if ((DateTime.Now - lastcheck).TotalMinutes >= checkinFrequency)
			{
				ThreadPool.QueueUserWorkItem(callHome);
				lastcheck = DateTime.Now;
			}
		}

		private void callHome(object state)
		{
			string fp;
			string lolpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/.tshock/";
			if (!Directory.Exists(lolpath))
			{
				Directory.CreateDirectory(lolpath);
			}
			if (!File.Exists(Path.Combine(lolpath, Netplay.serverPort + ".fingerprint")))
			{
				fp = "";
				int random = Utils.Random.Next(500000, 1000000);
				fp += random;

				fp = Utils.HashPassword(Netplay.serverIP + fp + Netplay.serverPort + Netplay.serverListenIP);
				TextWriter tw = new StreamWriter(Path.Combine(lolpath, Netplay.serverPort + ".fingerprint"));
				tw.Write(fp);
				tw.Close();
			}
			else
			{
				fp = "";
				TextReader tr = new StreamReader(Path.Combine(lolpath, Netplay.serverPort + ".fingerprint"));
				fp = tr.ReadToEnd();
				tr.Close();
			}

			using (var client = new WebClient())
			{
				client.Headers.Add("user-agent",
								   "TShock (" + TShock.VersionNum + ")");
				try
				{
					string response;
					if (TShock.Config.DisablePlayerCountReporting)
					{
                        response = client.DownloadString("http://tshock.co/tickto.php?do=log&fp=" + fp + "&ver=" + TShock.VersionNum + "&os=" + System.Environment.OSVersion.ToString() + "&mono=" + Main.runningMono + "&port=" + Netplay.serverPort + "&plcount=0");
					}
					else
					{
                        response = client.DownloadString("http://tshock.co/tickto.php?do=log&fp=" + fp + "&ver=" + TShock.VersionNum + "&os=" + System.Environment.OSVersion.ToString() + "&mono=" + Main.runningMono + "&port=" + Netplay.serverPort + "&plcount=" + TShock.Utils.ActivePlayers());
					}
					Log.ConsoleInfo("Stat Tracker: " + response + "\n");
				}
				catch (Exception e)
				{
					Log.Error(e.ToString());
				}
			}
		}
	}
}
