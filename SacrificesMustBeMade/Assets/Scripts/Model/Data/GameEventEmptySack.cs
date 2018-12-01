using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventEmptySack
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Empty Sack",
            Predicate = gs => gs.Res.Wealth <= 20,
            Priority = 5,
            Retention = 3,
            Description = "Our goods stock is almost non-existant. We could tackle this case in multiple ways. Some of our cultists are quite rich, they could share some of their goods" +
            ". Many of city's stores aren't well protected during nighttime. We could also give more tools to our followers so they put more effort in their work outside the cult. What's your will?",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Good my worshipers understand the necesity of sharing their possessions. That's not much, but it's going to help anyway.",
                    Effect = gs => {
                        gs.Res.Wealth += 10;
                        return gs;
                    }

                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Theft is indeed profitable. Some of cultist got caught, but the gains are much more impressive than the loses.",
                    Effect = gs => {
                        gs.Res.Wealth += 50;
                        gs.Res.Cultists -= 20;
                        return gs;
                    }

                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "They tried to gain more, but in vain. We just lose more resources trying to increase our gains. Our cultist also got distracted by working more outside the cult",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Zeal -= 20;
                        return gs;
                    }

                }
            }
        };

    }

}
