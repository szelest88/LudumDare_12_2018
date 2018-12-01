using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameResources
    {

        public int Cultists = GameConfig.CultistsStartingValue;
        public int Wealth = GameConfig.WealthStartingValue;
        public int Zeal = GameConfig.ZealStartingValue;
        public int Notority = GameConfig.NotorityStartingValue;

        public bool Virgin = false;
        public bool Altair = false;
        public bool Relic = false;

    }
}