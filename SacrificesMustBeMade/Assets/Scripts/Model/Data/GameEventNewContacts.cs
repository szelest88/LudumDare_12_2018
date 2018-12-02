using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventNewContacts
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "New Contacts",
            Predicate = gs => gs.Res.Cultists <= 80,
            Priority = 5,
            MinTurn = 1,
            Retention = 7,
            Description = "A new bar has opened nearby. We could start recruiting new followers there. Or, we could start kidnapping drunk people. Or maybe even paying the owner to deliver us those, who fall in debt with him.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Dragging some drunk, unconscious bodies at night is apparently very good way of gaining new followers. They should open new bars more often.",
                    Effect = gs => {
                        gs.Res.Cultists += 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "Many people are willing to join a cult, as long, as it gives them a meaning in life. Sad, but true. But, talking about secret cults in bars makes them less secret.",
                    Effect = gs => {
                        gs.Res.Cultists += 20;
                        gs.Res.Notority += 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "A bar in this part of town has many clients, who fall in debt. We pay them a simple offer: When a client cannot pay, we pay for the client, and the client is delivered to us. And a small extra pay, so the bar owner doesn't ask any questions.",
                    Effect = gs => {
                        gs.Res.Wealth -= 20;
                        gs.Res.Cultists += 30;
                        gs.Res.Notority += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
