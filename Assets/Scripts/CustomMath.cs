using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomMath{
    public static class Math
    {
        public static float Map (this float value, float fromSource, float toSource, float fromTarget, float toTarget)
        {
            return (value - fromSource) / (toSource - fromSource) * (toTarget - fromTarget) + fromTarget;
        }
    }
}