using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventKleptomaniacs
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Kleptomaniacs",

            Predicate = gs => gs.Res.Wealth >= 100,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "The amounts of wealth stored in our base inspires our cultists. Some of them become too inspired. We have caught a number of them trying to steal the money. What should we do with them?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "I ordered to kill those, who reached for goods destined to you. The faith of others has risen.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "I talked to those, who lost their way. Some regret their actions. I ordered them penance. Others did not want to change their ways. I deemed them unworthy of being your servants, so I killed them.",
                    Effect = gs => {
                        gs.Res.Cultists -= 5;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Lack of action caused the theft incidents to continue over the next days. Eventually, fear of the consequences has caused them to stop.",
                    Effect = gs => {
                        gs.Res.Wealth -= 20;
                        return gs;
                    }
                }

            }
        };

    }

}
