using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{
    public class GameLogic
    {
        public static GameEvent NextEvent(GameEvent[] gameEvents, GameState gs, System.Random random, bool verbose)
        {
            var validGameEvents = new List<GameEvent>();
            {
                foreach (GameEvent ge in gameEvents)
                {
                    if (ge.Predicate(gs))
                    {
                        validGameEvents.Add(ge);
                    }
                }

                if (validGameEvents.Count == 0)
                {
                    Debug.LogErrorFormat("No event is appropriate for a given game state: {0}. Choosing random one.", gs);
                    validGameEvents.Add(
                        gameEvents[random.Next(0, gameEvents.Length)]
                    );
                }
            }

            // TODO: Select event with weighted random
            // {
            //     var uniquePriorities = new HashSet<uint>(validGameEvents.Select(e => e.Priority));
            //     var uniquePrioritiesSum = uniquePriorities.Sum(e => e);
            //     var weights = new double[uniquePriorities.Count];
            //     for (int i = 0; i < uniquePriorities.Count; ++i) {
            //         weights[i] = uniquePriorities
            //     }
            // }

            GameEvent result;
            {
                var maxPriority = validGameEvents.Max(e => e.Priority);
                var maxPriorityEvents = validGameEvents
                    .Where(e => e.Priority == maxPriority)
                    .ToList();
                result = maxPriorityEvents[random.Next(0, maxPriorityEvents.Count)];
            }


            if (verbose)
            {
                Debug.LogFormat("Game next event. validGameEvents: [{0}], result: {1}",
                    string.Join(",", validGameEvents.Select(e => e.ToString()).ToArray()),
                    result
                );
            }

            return result;
        }
    }
}
