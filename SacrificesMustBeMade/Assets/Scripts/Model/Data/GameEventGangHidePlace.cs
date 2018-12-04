using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventGangHidePlace
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Gang Hide Place",
            Predicate = gs => gs.Res.Notority <= 80,
            Priority = 5,
            MinTurn = 1,
            Retention = 6,
            Description = "A gang of about twenty people has chosen an abandoned building right next to our base, as hiding spot. Oh, the irony. We must deal with them, before they grow in numbers and power. But what would be the best course of action? If we attack them, they will likely fight back. We could just light their base on fire. Or, we could always invite them to join our group.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We approached them with intent to kill. But even a small group of people makes a deadly force, when equipped with guns and faced with no other option, than to fight. They died, but took some of ours with them. But, their money is now ours.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Wealth += 30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Turns out, they would really like to join a big group, like ours. But, their basic life approach does not help our followers understand your wisdom.",
                    Effect = gs => {
                        gs.Res.Cultists += 20;
                        gs.Res.Wealth += 10;
                        gs.Res.Zeal -= 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "The operation was a success. The fire consumed their entire hiding place, along with the building. And then started spreading. Not only did our base suffer casualties, the fire attracted unwanted attention. But the gang is gone. That's good, right?",
                    Effect = gs => {
                        gs.Res.Wealth -=30;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                }
            }
        };

    }

}
