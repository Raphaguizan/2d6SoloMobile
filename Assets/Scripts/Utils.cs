using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Util
{
    public static class Utils
    {
        public static bool FiftyFifty()
        {
            return Random.Range(0, 2) == 0;
        }

        /// <summary>
        /// remapea um valor de uma escala para outra exemplo:
        /// 5 entre 0 à 10 numa escala 0 à 1 é igual a 0.5
        /// </summary>
        /// <param name="s">valor a ser remapeado</param>
        /// <param name="a1">valor1 min</param>
        /// <param name="a2">valor1 max</param>
        /// <param name="b1">valor2 min</param>
        /// <param name="b2">valor2 max</param>
        /// <returns>float ajustado para a nova escala</returns>
        public static float Remap(this float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
    }
}