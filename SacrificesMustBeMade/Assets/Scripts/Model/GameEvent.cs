using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{

	[System.Serializable]
    public class GameEvent : IVerifiable
    {

        public string Name;

        public System.Predicate<GameState> Predicate = gs => true;

        public uint Priority;

		public uint MinTurn;

        public uint Retention;

        public string Description;

        public GameEventAction[] Actions;

		public void Verify(Verification verification) {
			verification.Verify(Name, n => n != null, "Name == null");
			verification.Verify(Predicate, p => p != null, "Predicate == null");
			verification.Verify(Priority, p => p > 0, "Priority <= 0");
			verification.Verify(MinTurn, mt => mt > 0, "MinTurn <= 0");
			verification.Verify(Description, d => d != null, "Description == null");
			verification.Verify(Description, d => d.Length == 0, "Description is empty");
			verification.Verify(Actions, a => a.Length > 0, "Actions is empty");
			verification.Verify(Actions, a => a.Select(ac => ac.Type).Distinct().Count() == a.Length, "Actions are duplicated.");
		}

    }

}
