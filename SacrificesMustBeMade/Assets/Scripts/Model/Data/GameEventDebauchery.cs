using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventDebauchery
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Debauchery",

            Predicate = gs => gs.Res.Wealth >= 180,
            Priority = 10,
            MinTurn = 1,
            Retention = 3,
            Description = "Our wealth can be barely contained within our base. More importantly, we have trouble keeping it safe from our own cultists. Many of them spend the money on petty things. Others just waste it. We must find a way to stop this wave of profligacy",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We increased the penalties for wasting our resources. Many cultists have fled with some of our wealth. The rest has started to spend less.",
                    Effect = gs => {
                        gs.Res.Cultists -= 10;
                        gs.Res.Wealth -= 50;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "It quickly became apparent, that it's impossible to just stop this recless greed. So, we started to spend the wealth to improve the quality of life in our little society. Thanks to this, we got new members, and our fame spreads further.",
                    Effect = gs => {
                        gs.Res.Wealth -= 100;
                        gs.Res.Cultists += 20;
                        gs.Res.Zeal += 20;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Over time, our wealth has shrunk significantly. Now, there is no problem with keeping it safe.",
                    Effect = gs => {
                        gs.Res.Wealth -= 80;
                        gs.Res.Zeal += 10;
                        return gs;
                    }
                }

            }
        };

    }

}

