using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventBuildAltar
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Build Altar",
            Predicate = gs => gs.Res.Wealth >= 100 && gs.Res.Altair == false,
            Priority = 8,
            MinTurn = 6,
            Retention = 5,
            Description = "It seems, our cult is doing well, when it comes to wealth. We could use it to build an altar in our base. Alternatively, we could make a bigger, more aggressive version. It would surely increase faith in our cult even more.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We didn't spare resources, and made an altar, that's functional and impressive. Truly, a testament of your power.",
                    Effect = gs => {
                        gs.Res.Wealth -= 100;
                        gs.Res.Zeal += 40;
                        gs.Res.Notority += 40;
                        gs.Res.Altair = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "The altar is built, as you commanded. ",
                    Effect = gs => {
                        gs.Res.Wealth -= 80;
                        gs.Res.Zeal += 20;
                        gs.Res.Notority += 20;
                        gs.Res.Altair = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We trust your judgement, when to build structures devoted to you.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
