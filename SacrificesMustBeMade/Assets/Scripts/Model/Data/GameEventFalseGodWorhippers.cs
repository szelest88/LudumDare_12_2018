using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventFalseGodWorhippers
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "False God Worhippers",
            Predicate = gs => gs.Res.Zeal >= 50 && gs.Res.Notority <= 75,
            Priority = 5,
            MinTurn = 1,
            Retention = 12,
            Description = "Carollers at our doors? How displeasing! Chanting songs of false god! But they're young and nothing is more sincere than faith of neophyte. Shall we teach them of true Lord, chase them away or let theirs mouth spew these blasphemous noise",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "As we unchain dogs they scream. They dare to ask 'Why such violence in this merry time?'. Words of cruel isolationists spreads",
                    Effect = gs => {
                        gs.Res.Zeal += 30;
                        gs.Res.Notority += 30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Songs of false prophet upsets our brothers. They dare to ask how you my Lord allow for such lies to be spread on ground of your temple. Vacant stares are of your worhippers are assumed to be amazement by noise makers. Glad they go on their way. Most likely to ruin someone else's evening",
                    Effect = gs => {
                        gs.Res.Zeal -= 30;
                        gs.Res.Notority -=30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "'It's cold outside. Would you like something warm to drink?'. With good humor they march through our doorstep. We shall unleash most vile horrors upon them from 'The Tome of Meaninglessness'. We shall bring their minds to the edge of insanity. Then whe shall give them solace in obidience to you. Our Dark One",
                    Effect = gs => {
                        gs.Res.Notority +=20;
                        gs.Res.Cultists += 20;
                        return gs;
                    }
                }
            }
        };

    }

}
