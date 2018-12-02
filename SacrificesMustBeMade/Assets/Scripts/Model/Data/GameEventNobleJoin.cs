using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventNobleJoin
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Noble Join",
            Predicate = gs => gs.Res.Notority >= 100,
            Priority = 5,
            MinTurn = 6,
            Retention = 12,
            Description = "Today, a nobleman has visited. He has heard aboout our cult, and is really interested in joining us. He seems pretty oblivious of what's going on here. I feel, he's just bored and wants to experience something extreme or esoteric. Still, he offers to immediately give us some money. And he's pretty rich. But, I doubt, he'll be able to stay discreet when talking to his friends outside the cult. Should we let him in?",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "The nobleman was basically in extasy, when he saw our interiors. He immediately gave suggestions on how to make it look even better. He also gave 'some' money, so we would be able to make his suggestions happen. Maybe we will.",
                    Effect = gs => {
                        gs.Res.Cultists += 1;
                        gs.Res.Wealth += 50;
                        gs.Res.Notority += 30;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We shot the man down and robbed him of his belongings. The morale of cultists suffered from this act, but he will surely remain silent now.",
                    Effect = gs => {
                        gs.Res.Wealth += 20;
                        gs.Res.Zeal -= 10;
                        gs.Res.Notority -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "We told the man, we are not interested in people like him. Strangely, he took this as a challenge. He left, promising, he'll be back, someday. I have a feeling, he'll still talk about us with his friends.",
                    Effect = gs => {
                        gs.Res.Notority += 10;
                        return gs;
                    }
                }
            }
        };

    }

}
