using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    [System.Serializable]
    public class GameResources
    {

        public int Cultists = GameConfig.CultistsStartingValue;
        public int Wealth = GameConfig.WealthStartingValue;
        public int Zeal = GameConfig.ZealStartingValue;
        public int Notority = GameConfig.NotorityStartingValue;

        public bool Virgin = false;
        public bool Altair = false;
        public bool Relic = false;

        public void Validate() {
            if (Cultists < 0) {
                Cultists = 0;
            }

            if (Wealth < 0) {
                Wealth = 0;
            }

            if (Zeal < 0) {
                Zeal = 0;
            }

            if (Notority < 0) {
                Notority = 0;
            }
        }

    }
}