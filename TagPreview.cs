using System;
using System.Collections.Generic;
using System.Linq;

namespace RainWorldStateEdit
{
    static class TagPreview
    {
        public static string TagString(StateTag tag)
        {
            string additional = GetTagAdditionalData(tag);
            if (!string.IsNullOrEmpty(additional)) additional = $" ({additional})";
            else additional = "";

            if (tag.IsValueTag())
            {
                return $"{tag.Value}: {tag[0].Value}{additional}";
            }
            if (PreviewFirstTag.Contains(tag.Value)) return $"{tag.Value}: {(tag[0].IsValueTag() ? tag[0][0].Value : tag[0].Value)}{additional}";
            return tag.Value + additional;
        }

        public static string GetTagAdditionalData(StateTag tag)
        {
            if (tag.Value.EndsWith("-0-0") && int.TryParse(tag.Value.Replace("-0-0",""), out int id) && IDToNameMap.ContainsKey(id))
            {
                return $"Creature: {IDToNameMap[id]}";
            }
            if (tag.Value == "TOTTIME" && tag.IsValueTag()) 
            {
                return TimeSpan.FromSeconds(int.Parse(tag[0].Value)).ToString("c");
            }
            return null;
        }

        internal static string[] PreviewFirstTag = new string[] { "MAP", "SHELTERLIST", "REGIONSTATE", "SAVE STATE", "InputSetup", "GAMETYPE", "CONFIG" };
        static Dictionary<int, string> IDToNameMap = new Dictionary<int, string>()
        {
            {0,     "StandardGroundCreature"},
            {1,     "Slugcat"},
            {2,     "LizardTemplate"},
            {3,     "PinkLizard"},
            {4,     "GreenLizard"},
            {5,     "BlueLizard"},
            {6,     "YellowLizard"},
            {7,     "WhiteLizard"},
            {8,     "RedLizard"},
            {9,     "BlackLizard"},
            {10,    "Salamander"},
            {11,    "CyanLizard"},
            {12,    "Fly"},
            {13,    "Leech"},
            {14,    "SeaLeech"},
            {15,    "Snail"},
            {16,    "Vulture"},
            {17,    "GarbageWorm"},
            {18,    "LanternMouse"},
            {19,    "CicadaA"},
            {20,    "CicadaB"},
            {21,    "Spider"},
            {22,    "JetFish"},
            {23,    "BigEel"},
            {24,    "Deer"},
            {25,    "TubeWorm"},
            {26,    "DaddyLongLegs"},
            {27,    "BrotherLongLegs"},
            {28,    "TentaclePlant"},
            {29,    "PoleMimic"},
            {30,    "MirosBird"},
            {31,    "TempleGuard"},
            {32,    "Centipede"},
            {33,    "RedCentipede"},
            {34,    "Centiwing"},
            {35,    "SmallCentipede"},
            {36,    "Scavenger"},
            {37,    "Overseer"},
            {38,    "VultureGrub"},
            {39,    "EggBug"},
            {40,    "BigSpider"},
            {41,    "SpitterSpider"},
            {42,    "SmallNeedleWorm"},
            {43,    "BigNeedleWorm"},
            {44,    "DropBug"},
            {45,    "KingVulture"},
            {46,    "Hazer"}
        };
    }
}
