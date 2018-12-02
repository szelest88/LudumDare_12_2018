namespace Model
{
    public class GameEventCultRadicalization
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Cult Radicalization",
            Predicate = gs => gs.Res.Zeal >= 50,
            Priority = 5,
            MinTurn = 1,
            Retention = 3,
            Description = "Increasing number of your cultists start making offerings from their own blood. It particularly applies to the newcomers. Some of them are reported to have fainted during rituals",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "If you're content with the amount of sacrifice, then I shall not intervene. Some of the zealots die due to excessive blood loss, but the overall zeal is growing immensely.",
                    Effect = gs => {
                        gs.Res.Zeal += 30;
                        gs.Res.Cultists -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "I encourage the cultists, that their devotion pleases you. The offerings are now more bloody. It didn't increase their zeal as expected, considerable amount of cultists died." +
                    "Also, hospitals started to report some brutal dismemberents.",
                    Effect = gs => {
                        gs.Res.Zeal += 20;
                        gs.Res.Cultists -= 30;
                        gs.Res.Notority =+ 20;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Diplomacy,
                    Description = "I convince the cultists, they won't be much of use to you, if they die. Unfortunately, they don't think rationally, and concern you as an ungrateful god",
                    Effect = gs => {
                        gs.Res.Zeal -=20;
                        return gs;
                    }
                }
            }
        };

    }

}
