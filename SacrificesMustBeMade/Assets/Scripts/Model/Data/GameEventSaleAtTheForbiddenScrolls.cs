using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventSaleAtTheForbiddenScrolls
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Sale at the 'Forbidden Scrolls;",
            Predicate = gs => gs.Res.Wealth >= 60,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "The 'Forbidden Scrolls' are orgranizing a sale. The most notable offers are: special black cats to burn, red paint for making occultistic symbols," +
            "and coats that cast evil shadow on its wearer. Should we bother it, Master?",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "This is the best trade deal in the history of trade deals. Maybe ever. Cats burn for more than 40 minutes whilst red point contains as much" +
                    "as 15% of blood! Our cultists are overjoyed, and the new ones are joining.",
                    Effect = gs => {
                        gs.Res.Wealth -= 30;
                        gs.Res.Zeal += 60;
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "Trying to steal from them was a an abominable concept. They casted a curse on us in revenge. Our cultists die, they want to change the cult," +
                    "and our possessions are damaged.",
                    Effect = gs => {
                        gs.Res.Zeal -= 30;
                        gs.Res.Cultists -= 20;
                        gs.Res.Wealth -= 30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "Brother Roger isn't the sharpest tool in the shed. Especially when it comes to bartering. Not only we didn't manage to get the lower price" +
                    "but we also got written into the black list of clients. Also, brother Roger doesn't want to take part in cult anymore.",
                    Effect = gs => {
                        gs.Res.Notority += 30;
                        gs.Res.Wealth -= 10;
                        gs.Res.Cultists -= 1;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Well, that sale is a shady place anyway.",
                    Effect = gs => {
                        return gs;
                    }
                }
            }
        };

    }

}
