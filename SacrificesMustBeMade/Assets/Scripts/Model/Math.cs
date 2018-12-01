using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Model
{
    public class Math
    {
        // weights: sum of its elements is equal 1.0
        // weight: is in [0, 1.0) range
        public static int ChooseIndexWeighted(double[] weights, double value)
        {
			if ((weights.Length != 0) == false) {
				throw new System.InvalidOperationException("Weights must not be empty.");
			}
			if ((0.0 <= value && value < 1.0) == false) {
				throw new System.InvalidOperationException("Value must be in [0.0, 1.0) range. value: " + value);
			}

            double total = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                total += weights[i];
                if (value < total)
                {
                    return i;
                }
            }
			// Shouldn't happen, but assuming float errors choose the last element.
			return weights.Length - 1;
        }
    }
}
