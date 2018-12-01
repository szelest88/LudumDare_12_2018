namespace Model
{
    public class GameEventCultRadicalization
    {
        public static GameEvent Event = new GameEvent
        {
            Name = "Cult Radicalization",
            Predicate = gs => gs.Res.Zeal >= 50,
            Priority = 5,
            Retention = 3,
            Description = "Increasing number of your cultists start making offerings from their own blood. It particularly applies to the newcomers. Some of them are reported to have fainted during rituals",
            Actions = new [] {
                new GameEventAction {
                    Type = GameEventActionType.Apathy,
                    Description = "I'm content with the amount of sacrifice and decide not to intervene. Some of the zealots died due to excessive blood loss, but the overall zeal is growing immensely.",
                    Effect = gs => {
                        gs.Res.Zeal += 30;
                        gs.Res.Cultists -= 10;
                        return gs;
                    }
                },
                new GameEventAction {
                    Type = GameEventActionType.Enthusiasm,
                    Description = "A few dripplets of blood aren't going to satisfy me. The offerings are now more bloody. It didn't increase their zeal as expected, considerable amount of cultists died." +
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
                    Description = "They must stay alive in order to serve me. Unfortunately, they doesn't think rationally, and concern me as ungrateful god",
                    Effect = gs => {
                        gs.Res.Zeal -=20;
                        return gs;
                    }
                }
            }
        };

    }

}
