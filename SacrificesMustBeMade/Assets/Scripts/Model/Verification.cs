using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public interface IVerifiable
    {
        void Verify(Verification verification);
    }

    public class Verification
    {
        public List<string> Errors = new List<string>();

        public void Verify<T>(T value, System.Predicate<T> predicate, string error)
        {
            if (!predicate(value))
            {
                Errors.Add(error);
            }
        }
    }

    public class Verifier
    {
        public List<string> Errors = new List<string>();

        public void Verify(IVerifiable[] verifiables, string error)
        {

            for (int i = 0; i < verifiables.Length; ++i)
            {
                var verifiable = verifiables[i];

                var verification = new Verification();
                verifiable.Verify(verification);

                if (verification.Errors.Count != 0)
                {
                    Errors.Add(string.Format("{0}. idx: {1}", error, i));
                    Errors.AddRange(verification.Errors);
                };
            }

        }
    }

}