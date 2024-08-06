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
    }
}