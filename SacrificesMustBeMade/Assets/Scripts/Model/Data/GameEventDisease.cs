using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventDisease
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Disease",
            Predicate = gs => true,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "Some of our cultists seem to be sick. This brings my attention to level of health care in our base. Which is pretty low. We could make some investments related to this. We could refrain from action, and tell them, the sickness is actually a test of their faith. Or, we could kick the sick people out, so the disease won't spread among us.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "I sent qualified people to buy medical equipment. In short time, our sick members are treated and return to health.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Zeal += 5;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Lack of action causes the disease to spread among us. We order the sick to stay away from the others. In result, some of our followers die, and some leave the cult.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Zeal -= 10;
                        gs.Res.Notority -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We cast out the sick to not infect others.",
                    Effect = gs => {
                        gs.Res.Cultists -= 5;
                        return gs;
                    }
                }
            }
        };

    }

}
