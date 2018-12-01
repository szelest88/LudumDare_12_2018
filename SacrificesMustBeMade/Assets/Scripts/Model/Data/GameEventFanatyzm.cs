using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class GameEventFanatyzm
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Fanatyzm",
            Predicate = gs => gs.Res.Zeal >= 180 && gs.Res.Altair,
            Priority = 10,
            Retention = 3,
            Description = "Mam przyjemność poinformować, że oddanie naszych kultystów jest wielkie. Nawet… zbyt wielkie. Zgłębianie wiedzy tajemnej odbija się negatywnie na umysłach słabszych osób. Obłęd w naszych szeregach staje się powszechnością. W jaki sposób powinniśmy rozwiązać ten problem?",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Conflict,
                    Description = "Rozkazałem zabić obłąkanych oraz zwiększyłem wymogi dostępu do ksiąg. Problem szaleństwa został zażegnany, choć przez te restrykcje, oddanie w naszym kulcie zmalało.",
                    Effect = gs => {
                        gs.Res.Cultists -= 15;
                        gs.Res.Zeal -= 80;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Ruse,
                    Description = "Przeznaczyliśmy część zasobów, żeby stworzyć księgi o mniej radykalnej zawartości. Teraz, kultyści będą mogli zgłębiać nasze tajniki w odpowiednim dla siebie, wolniejszym tempie.",
                    Effect = gs => {
                        gs.Res.Wealth -= 60;
                        gs.Res.Zeal -= 40;
                        return gs;
                    }
                }
            }
        };

    }

}
