using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventGetRelic
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Get Relic",
            Predicate = gs => (gs.Res.Wealth >= 110 || gs.Res.Cultists >= 100) && gs.Res.Relic == false,
            Priority = 10,
            MinTurn = 10,
            Retention = 8,
            Description = "News of ancient temple spreads among University scholars. Description resembles temple depicted in 'The Book of Distant Shores'. Book says of dagger forged under red moon. Shall we send most devoted brothers on expedition. On the other hand, University archaeologist are eager to go. We could aid them through dangers of dwelling within temples erected in names of The Elder Ones and steal most sought possesion right from under their noses.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "Many brothers commited their flesh to the cause. Scourge inflicted upon them by protective seals placed within temple meant nothing as long as it brings us closer to Your forthcoming, Dark One",
                    Effect = gs => {
                        gs.Res.Cultists -= 70;
                        gs.Res.Zeal += 40;
                        gs.Res.Relic = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "To think they dare to call themselves scholars. They know nothing. We led them forth. Using them to focus wrath of Protectors on them. Their numbers dwindled fast but prospect of glory and faith made them walk over bodies of fallen. But prize at the end was never meant for them.",
                    Effect = gs => {
                        gs.Res.Notority += 60;
                        gs.Res.Cultists -= 30;
                        gs.Res.Wealth -= 50;
                        gs.Res.Relic = true;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "Really? Er, I mean, of course. We shall refrain from action. But the followers were eager to go.",
                    Effect = gs => {
                        gs.Res.Zeal -= 10;
                        return gs;
                    }
                }
            }
        };

    }

}
