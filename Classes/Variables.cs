﻿using Ensage;
using SharpDX;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pudge_Plus.Classes
{
    class Variables
    {
        public static Hero me;
        public static GlobalClasses.Tracker[] EnemyTracker = { new GlobalClasses.Tracker(null, 0), new GlobalClasses.Tracker(null, 0), new GlobalClasses.Tracker(null, 0), new GlobalClasses.Tracker(null, 0), new GlobalClasses.Tracker(null, 0), };// new GlobalClasses.Tracker[5];//Hero[] EnemyTracker = new Hero[5];
        //Strings//
        public static string AuthorNotes = "Pudge+ created by NadeHouse\nCurrently running: public access BETA\nTips\n\tPress 'e' when a prediction box appears on the screen and the script\n\twill hook for you\n\t\tNote: It will attempt to hook closest enemy to your\n\t\tmouse, identified with the RED Prediction text\n\tA non moving enemy that can be automattically hooked will be identified\n\twith the orange 'Locked' text\n\tNote: Do not rely on this script to hook Spirit Breaker as he charges";
        public static string LoadMessage = " > Pudge+ is now running";
        public static string UnloadMessage = " > Pudge+ is waiting for the next game to start.";
        public static string PredictMethod = "two"; //one = Pure maths //two = maths & prediction
        public static string visibleParticleEffect = @"particles\ui_mouseactions\hero_highlighter_playerglow.vpcf";//"particles\items2_fx\shivas_guard_impact.vpcf"; @"particles\ui_mouseactions\hero_highlighter_playerglow.vpcf"
        public static string NotificationText = "You are visible";
        public static GlobalClasses.SkillShotClass[] SkillShots = { new GlobalClasses.SkillShotClass("modifier_invoker_sun_strike", "hero_invoker/invoker_sun_strike_team", 175,1700,"Sun Strike"), new GlobalClasses.SkillShotClass("modifier_lina_light_strike_array", "hero_lina/lina_spell_light_strike_array_ring_collapse", 225,500, "Lina Stun"), new GlobalClasses.SkillShotClass("modifier_kunkka_torrent_thinker", "hero_kunkka/kunkka_spell_torrent_pool", 225, 1600, "Torrent"), new GlobalClasses.SkillShotClass("modifier_leshrac_split_earth_thinker", "hero_leshrac/leshrac_split_earth_b", 225, 350, "Split Earth") };
        public static List<GlobalClasses.SkillShotClass> DrawTheseSkillshots = new List<GlobalClasses.SkillShotClass>();
        public static readonly Dictionary<Unit, ParticleEffect> SkillShotEffect = new Dictionary<Unit, ParticleEffect>();
        //Bools//
        public static bool DeveloperMode = false;
        public static bool inGame = false;
        public static bool DrawNotification = false;
        public static bool HookForMe = false;
        public static bool CoolDownMethod = true; //True = advanced, false = basic
        public static bool HookLocationDrawer = false;
        //Ints//
        public static int TimeTillNextRune = -999;
        public static int EnemyIndex = 0;
        public static int HookSpeed = 1600;
        public static int HookCounter = 0;
        public static int Offset = 0;
        public static int MouseOffset = 0;
        public static string ResponseIndex = "null";
        public static int AttemptsRemaining = 3;
        //floats//
        public static float ToolTipActivationY;
        public static float ToolTipRadiantStart;
        public static float ToolTipDireStart;
        public static float WindowWidth;
        public static float TeamGap;
        public static float HeroIconWidth;
        //Vectors
        public static  Vector2 ESP_Notifier_StartingCoords = new Vector2(15, 50);
        public static Vector2 AutoHookLocation;
        public static Vector2 EnemyLocation;
        public static Vector2 PredictionLocation;
        public static Vector3[] EnemiesPos = new Vector3[5];
        //Runes
        public static CustomRune TopRune = new CustomRune();
        public static CustomRune BottomRune = new CustomRune();
        //misc
        public static Font font;
        public static ParticleEffect visibleGlow;
        public static float GapRatio = 0.171875f;
        public static float RadiantStartRatio = 0.2760416667f;
        public static float DireStartRatio = 0.5546875f;
        public static float ToolTipActivationYRatio = 0.04166666667f;
        
    }
}
