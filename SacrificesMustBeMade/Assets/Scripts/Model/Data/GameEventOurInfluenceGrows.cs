using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventOurInfluenceGrows
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Our Influence Grows",

            Predicate = gs => gs.Res.Notority >= 80 && gs.Res.Cultists >= 40,
            Priority = 5,
            MinTurn = 1,
            Retention = 7,
            Description = "There's a shop on our terrain, that's doing pretty well recently. We did not bother the owner, until now. I think, we should, uh, negotiate the proper tax for running business on our turf. Or, we could send some men to break into the place and take, what's rightfully ours.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We broke into the shop, and started robbing whatever was not nailed down. But, it turns out, the shop owner also sells guns. And hires a few guards. Still, I think, the gain was worth the sacrifice.",
                    Effect = gs => {
                        gs.Res.Cultists -= 20;
                        gs.Res.Wealth += 50;
                        gs.Res.Notority += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Everybody's willing to reach a compromise, when surrounded by a bunch of hooded figures. We agreed, he'd pay for us not causing trouble to his shop. And he even agreed to sometimes sell some shady things, we might not need. What a great guy.",
                    Effect = gs => {
                        gs.Res.Wealth += 30;
                        return gs;
                    }
                },

                new GameEventAction
                {
                    Type = GameEventActionType.Apathy,
                    Description = "As you wish. But I fear, at this rate, the shop's owner will hire more guards, and won't be afraid of us in the future.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
