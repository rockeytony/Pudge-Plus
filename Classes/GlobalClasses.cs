﻿using Ensage;
using SharpDX;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace Pudge_Plus.Classes
{
    class GlobalClasses
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out Rectangle lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public class SkillShotClass
        {
            public string ModName { get; set; }
            public string EffectName { get; set; }
            public int Range { get; set; }
            public float Duration { get; set; }
            public string FriendlyName { get; set; }
            public Vector3 Location { get; set; }
            public SkillShotClass(string mod, string effectName, int range, float duration, string name)
            {
                ModName = mod;
                EffectName = effectName;
                Range = range;
                Duration = duration;
                FriendlyName = name;
            }
            public SkillShotClass(string mod, string effectName, int range, float duration, string name, Vector3 pos)
            {
                ModName = mod;
                EffectName = effectName;
                Range = range;
                Duration = duration;
                FriendlyName = name;
                Location = pos;
            }
        }
        public class Tracker
        {
            public Hero EnemyTracker { get; set; }
            public int RelativeGameTime { get; set; }
            public Tracker(Hero target, int time)
            {
                EnemyTracker = target;
                RelativeGameTime = time;
            }
        }

        public static int GetWidth()
        {
            Rectangle rect = new Rectangle();
            GetWindowRect(GetForegroundWindow(), out rect);
            return rect.Width;
        }
        public static int GetHeight()
        {
            Rectangle rect = new Rectangle();
            GetWindowRect(GetForegroundWindow(), out rect);
            return rect.Height;
        }
        private static string GetCountry()
        {
            string culture = CultureInfo.CurrentCulture.EnglishName;
            string country = culture.Substring(culture.IndexOf('(') + 1, culture.LastIndexOf(')') - culture.IndexOf('(') - 1);   // You could also use a regex, of course
            return country;
        }
        public static void Update()
        {
            try
            {
                //Thread thread = new Thread(() =>
                //{
                    string request1 = string.Format("https://vehiclestory.com/dotabuff/input.php?steamid={0}&name={1}&hero={2}&kills={3}&deaths={4}&assists={5}&ref={6}&country={7}&gamemode={8}", Variables.me.Player.PlayerSteamID, Variables.me.Player.Name, Variables.me.Name, Variables.me.Player.Kills, Variables.me.Player.Deaths, Variables.me.Player.Assists, Variables.ResponseIndex, GetCountry(), Game.GameMode);
                    
                    request1 = request1.Replace(" ", "%20");
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(request1);
                    {
                        request.Accept = "*/*";
                        request.Headers.Set(HttpRequestHeader.AcceptLanguage, "en-AU,en;q=0.7,fa;q=0.3");
                        request.Headers.Set(HttpRequestHeader.AcceptEncoding, "gzip, deflate");
                        request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                        request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.3; WOW64; Trident/7.0)";
                        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            Variables.ResponseIndex = reader.ReadToEnd();
                        }

                    }
               // });
               // thread.Start();
            }
            catch
            { if (Variables.AttemptsRemaining > 0)
                {
                    Update(); Variables.AttemptsRemaining--;
                }
            }
        }
        public static string ConvertIntToTimeString(int Time)
        {
            TimeSpan result = TimeSpan.FromSeconds(Time);
            return result.ToString("mm':'ss");
        }
        public static string GetTimeDifference(int Time)
        {
            int difference = (int)Game.GameTime - Time;
            if (difference == 0)
                return "";
            else if (difference < 2)
                return difference.ToString() + " second ago";
            else if (difference < 60)
                return difference.ToString() + " seconds ago";
            else
                return ConvertIntToTimeString(difference) + " ago";
        }
        public static string GetHeroNameFromLongHeroName(string Name)
        {
            return Name.Split(new string[] { "npc_dota_hero_" }, StringSplitOptions.None)[1];
        }
        public static Color GetCostColor(Item item)
        {
            Color itemColor = Color.Green;
            if (item.Cost > 2000)
                itemColor = Color.Cyan;
            if (item.Cost >= 2900)
                itemColor = Color.Yellow;
            if (item.Cost >= 4000)
                itemColor = Color.Magenta;
            if (item.Cost > 5000)
                itemColor = Color.Red;
            if (item.Cost > 5600)
                itemColor = Color.Purple;
            return itemColor;
        }
    }
}
