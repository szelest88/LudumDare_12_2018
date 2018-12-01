using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace Model
{

    public class MathTest
    {

        [Test]
        public void TestChooseIndexWeighted1()
        {
            double[] weights = new [] { 0.5, 0.5 };

            for (int idx = 0; idx < weights.Length; ++idx) {
                // Assert.AreEqual(idx, Math.ChooseIndexWeighted(weights, idx * 0.1));
                // Assert.AreEqual(idx, Math.ChooseIndexWeighted(weights, (idx + 1) * 0.1 - float.Epsilon));
            }
        }

    }

}