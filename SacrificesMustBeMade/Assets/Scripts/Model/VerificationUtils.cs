using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{

    public class Verification {
        private List<string> Errors = new List<string>();

        public void Verify<T>(T value, System.Predicate<T> predicate, string error) {
            if (!predicate(value)) {
                Errors.Add(error);
            }
        }
    }

}