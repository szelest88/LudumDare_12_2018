using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventFanatyzm
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Fanatyzm",
            Predicate = gs => gs.Res.Zeal >= 180,
            Priority = 10,
            MinTurn = 1,
            Retention = 3,
            Description = "I have the pleasure of informing you, the zeal of our cultists is great. Too great, even... Learning the deepest secrets of our faith is hard, especially for the lesser minds. Insanity becomes common among our people. How should we deal with this problem?",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "I ordered to kill the insane people, and restricted the access to our sacred books. The problem of insanity is solved, but our devotion suffered.",
                    Effect = gs => {
                        gs.Res.Cultists -= 15;
                        gs.Res.Zeal -= 80;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "We have used some of our wealth to write new books with less extreme contents. Now, followers can learn the secrets of our cult at slower pace.",
                    Effect = gs => {
                        gs.Res.Wealth -= 60;
                        gs.Res.Zeal -= 40;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Extreme fanatism along with insanity has led to a small catastrophy in our base. Crazy cultists have destroyed some of our resources, and ran away, babbling about The Elder Ones. And about our cult. This situation has injected doubt in our ranks.",
                    Effect = gs => {
                        gs.Res.Zeal -= 100;
                        gs.Res.Cultists -= 10;
                        gs.Res.Wealth -= 20;
                        gs.Res.Notority += 30;
                        return gs;
                    }
                }
            }
        };

    }

}
