using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{
    public class GameLogic
    {
        public static GameState NextEvent(GameEvent[] gameEvents, GameState gs, System.Random random, bool verbose)
        {
            gs.Turn += 1;

            var validGameEvents = new List<GameEvent>();
            {
                validGameEvents = gameEvents
                    .Where(e =>
                        // min turn requirement
                        gs.Turn >= e.MinTurn
                        // retention
                        && (gs.GameEventLastTurn.ContainsKey(e) == false || gs.GameEventLastTurn[e] + e.Retention <= gs.Turn)
                        // predicate
                        && e.Predicate(gs))
                    .ToList();

                if (validGameEvents.Count == 0)
                {
                    Debug.LogErrorFormat("No event is appropriate for a given game state: {0}. Choosing random one.", gs);
                    validGameEvents.Add(
                        gameEvents[random.Next(0, gameEvents.Length)]
                    );
                }
            }

            GameEvent currentEvent;
            {
                var uniquePriorities = validGameEvents.Select(e => e.Priority).Distinct().ToArray();
                var uniquePrioritiesSum = uniquePriorities.Sum(e => e);
                var uniquePrioritiesWeights = uniquePriorities.Select(pri => (double)pri / (double)uniquePrioritiesSum).ToArray();
                var selectedPriority = uniquePriorities[Math.ChooseIndexWeighted(uniquePrioritiesWeights, random.NextDouble())];

                var eligibleEvents = validGameEvents.Where(e => e.Priority == selectedPriority).ToArray();
                currentEvent = eligibleEvents[random.Next(0, eligibleEvents.Length)];
            }

            if (verbose)
            {
                Debug.LogFormat("Game next event. validGameEvents: [{0}], result: {1}",
                    string.Join(",", validGameEvents.Select(e => e.ToString()).ToArray()),
                    currentEvent
                );
            }

            gs.CurrentEvent = currentEvent;
            gs.CurrentEventAction = null;
            gs.GameEventLastTurn[currentEvent] = gs.Turn;
            return gs;
        }

        public static GameState PerformAction(GameState gs, GameEventActionType actionType, bool verbose)
        {
            if (verbose)
            {
                Debug.LogFormat("Game perform action. action: {0}", actionType);
            }

            gs.CurrentEventAction = gs.CurrentEvent.Actions.First(a => a.Type == actionType);

            gs.CurrentEventAction.Effect(gs);
            gs.Validate();

            return gs;
        }

        public static bool IsFinished(GameState gs)
        {
            return GetResult(gs) == GameResult.SUCCESS;
        }

        public static GameResult GetResult(GameState gs)
        {
            if (gs.Res.Altair && gs.Res.Relic && gs.Res.Virgin)
            {
                return GameResult.SUCCESS;
            }
            else if (gs.Res.Cultists == 0)
            {
                return GameResult.FAILURE_NO_CULTISTS;
            }
            else if (gs.Res.Zeal == 0)
            {
                return GameResult.FAILURE_NO_ZEAL;
            }
            else
            {
                return GameResult.UNKNOWN;
            }
        }

    }
}
