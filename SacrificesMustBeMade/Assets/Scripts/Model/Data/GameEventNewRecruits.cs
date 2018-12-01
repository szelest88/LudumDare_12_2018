using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventNewRecruits
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "New Recruits",
            Predicate = gs => gs.Res.Notority > 80,
            Priority = 5,
            MinTurn = 1,
            Retention = 7,
            Description = "This morning, a group of 20 poor people knocked on our door, asking to join our cult. They seem to be determined to join, but we'll need to equip them with clothes and satisfy their basic needs. Should we accept them in our ranks, refuse their offer, or maybe find a compromise?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "We warmy welcome our new cult members.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Cultists += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We offer them a place in our family, but refuse to waste expenses on them, until they prove their worth to you. Half of them agree to our terms.",
                    Effect = gs => {
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We send them back to wherever they came from.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
