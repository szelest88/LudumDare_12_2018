using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventAvoidSpotlight
    {

        public static GameEvent Event = new GameEvent
        {
            Name = "Avoid Spotlight",

            Predicate = gs => gs.Res.Notority >= 150 && gs.Res.Wealth >= 40 && gs.Res.Cultists >= 30,
            Priority = 5,
            MinTurn = 1,
            Retention = 7,
            Description = "Our actions have left quite a mark in the city. More people are aware of our existence by the day. Why don't we try to shift their gaze to something, or someone else? I'm thinking about framing some people of hideous crimes. Something newsworthy. Oh, speaking of which, I have a better idea! How about causing a fire? That will surely make people forget about us for a long time.",
            Actions = new[] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "We tried to make the fire as big, as possible. But a bunch of people carrying gas canisters cause suspitions. After they started the fire, the police quickly got some of them. But, they did it. The red aura was even visible from over here.",
                    Effect = gs => {
                        gs.Res.Cultists -= 20;
                        gs.Res.Wealth -= 10;
                        gs.Res.Notority -= 70;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "As long, as one has money, anything is possible. Long story short: we paid some people, they did some things, and now we got news about mass murderers on the loose. Maybe they'll want to join our cult?",
                    Effect = gs => {
                        gs.Res.Wealth -= 30;
                        gs.Res.Notority -= 50;
                        return gs;
                    }
                },

                new GameEventAction
                {
                    Type = GameEventActionType.Apathy,
                    Description = "As you order, we sit quietly for a week or two. With no activities on our side, there's not as much attention on us anymore.",
                    Effect = gs => {
                        gs.Res.Notority -= 20;
                        return gs;
                    }
                }
            }
        };

    }

}
