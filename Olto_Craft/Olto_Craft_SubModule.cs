using System;
using System.IO;
using System.Xml.Serialization;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.Library;
//using TaleWorlds.ObjectSystem;

namespace Olto_Craft
{
    public class Olto_Craft_SubModule : MBSubModuleBase
    {
        public static int xp_t0;
        public static int xp_t1;
        public static int xp_t2;
        public static int xp_t3;
        public static int xp_t4;
        public static int xp_t5;
        public static int xp_t6;
        public static bool no_coal;

        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            base.OnGameStart(game, gameStarterObject);
            if (game.GameType is Campaign)
            {
                CampaignGameStarter gameInitializer = (CampaignGameStarter)gameStarterObject;
                AddBehaviors(gameInitializer);
            }
        }
        private void AddBehaviors(CampaignGameStarter gameInitializer)
        {
            gameInitializer.AddBehavior(new Olto_Craft_Behaviors());
        }
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            LoadSettings();
        }
        private void LoadSettings()
        {
            Settings settings = new XmlSerializer(typeof(Settings)).Deserialize((Stream)File.OpenRead(Path.Combine(BasePath.Name, "Modules/Olto_Craft/settings.xml"))) as Settings;
            xp_t0 = settings.xp_t0;
            xp_t1 = settings.xp_t1;
            xp_t2 = settings.xp_t2;
            xp_t3 = settings.xp_t3;
            xp_t4 = settings.xp_t4;
            xp_t5 = settings.xp_t5;
            xp_t6 = settings.xp_t6;
            no_coal = settings.no_coal;
        }
    }
    [Serializable]
    public class Settings
    {
        public int xp_t0;
        public int xp_t1;
        public int xp_t2;
        public int xp_t3;
        public int xp_t4;
        public int xp_t5;
        public int xp_t6;
        public bool no_coal;
    }
}