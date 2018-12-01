using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventBaseAttack
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Base Attack",
            Predicate = gs => gs.Res.Notority >= 180,
            Priority = 5,
            Retention = 3,
            Description = "The Inquisition's attacking! They found our base, and are performing an attack! There's so many of them! What should we do? Run away? Fight back? We need your guidance!",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We did it! The inquisitors are slain. But so are many of our cultists. And our base suffered during the fight. But, the Inquisition will surely think twice next time, they will want to pay us a visit.",
                    Effect = gs => {
                        gs.Res.Cultists -= 50;
                        gs.Res.Wealth -= 20;
                        gs.Res.Notority -= 80;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "We ran away with whatever posessions we had on us. Some of us were not fast enough. Hours later, we found a suitable place for a new base. With little resources, our faith was truly tested today. But, we are still alive, and there's little chance, the Inquisition will be able to trace our steps to this new location.",
                    Effect = gs => {
                        gs.Res.Cultists -= 5;
                        gs.Res.Wealth -= 60;
                        gs.Res.Zeal -= 30;
                        gs.Res.Notority -= 100;
                        gs.Res.Altair = false;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "With no direction in this crucial moment, our forces were in true panic. Some of the cultists decided to flee. Some decided to fight back, and got decimated. Those, who ran away and stayed together, started looking for a place for our new base. The situation is so dire, even, if the Inquisition knew, where we are, they would likely not even bother with us anymore.",
                    Effect = gs => {
                        gs.Res.Cultists -= 70;
                        gs.Res.Wealth -= 80;
                        gs.Res.Zeal -= 40;
                        gs.Res.Notority -= 140;
                        gs.Res.Altair = false;
                        return gs;
                    }
                }
            }
        };

    }

}
