using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventBookStolen
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Book Stolen",
            Predicate = gs => gs.Res.Zeal <= 50 && gs.Res.Cultists >= 60 && gs.Res.Wealth >= 30,
            Priority = 5,
            MinTurn = 10,
            Retention = 10,
            Description = "A crazed follower has stolen one of our most prized books and fled the cult base! Now, he's threatening us, he'll destroy the book, if we don't pay him ransom. What should we do?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We sent our people after him. They quickly outnumbered him, but in the struggle, he managed to tear some pages off the sacred book. To punish him, we sacrificially killed him, according to instructions in the book, he stole.",
                    Effect = gs => {
                        gs.Res.Cultists -= 1;
                        gs.Res.Zeal += 10;
                        gs.Res.Wealth -= 5;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "We paid him an amount of money, almost equal to how much the book's worth. Still, the secrets of our faith contained in its pages are much more important to us.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Cultists -= 1;
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We did not allow him to threaten us. Then, we never heard from that man again. The book was worth some money, but most importantly, it contained secrets of our faith.",
                    Effect = gs => {
                        gs.Res.Wealth -= 10;
                        gs.Res.Zeal -= 20;
                        gs.Res.Cultists -= 1;
                        return gs;
                    }
                }
            }
        };

    }

}
