using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventSuicidalThoughts
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Suicidal Thoughts",
            Predicate = gs => gs.Res.Cultists >= 90 && gs.Res.Zeal >= 80,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "Our following has grown to a considerable size recently. Dedication of our worshipers is pleasing. But brother Roger is reporting that the increasing" +
            "number of cultists are having suicidal thoughts. That might be caused by the weight of responsibility they are given.",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "Gloriously. We are in dire need of those who want to take their life without a blink.",
                    Effect = gs => {
                        gs.Res.Cultists -= 40;
                        gs.Res.Wealth += 50;
                        gs.Res.Zeal -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Booking a therapy session was indeed a bright idea my lord. Our cultists are more vigorous, and we are not afraid of being tracked down." +
                    "Medical secrecy is truly amazing. Unfortunately we couldn't sign for group therapy, so it was a bit costly.",
                    Effect = gs => {
                        gs.Res.Zeal += 40;
                        gs.Res.Notority -= 10;
                        gs.Res.Wealth -= 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Excuse my bravery my Lord, but why would you ever be furious at our followers for willing to take their lifes away. That's what" +
                    "we are supposed to do... right?",
                    Effect = gs => {
                        gs.Res.Zeal -= 50;
                        return gs;
                    }
                }
            }
        };

    }

}
