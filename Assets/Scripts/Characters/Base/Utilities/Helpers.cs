using UnityEngine;

public static class Helpers
{
    public static float Map(float value, float inMin, float inMax, float outMin, float outMax, bool clamp = false)
    {
        float mappedValue = (value - inMin) / (inMax - inMin) * (outMax - outMin) + outMin;
        if (clamp)
        {
            if (outMin < outMax)
                return Mathf.Clamp(mappedValue, outMin, outMax);
            else
                return Mathf.Clamp(mappedValue, outMax, outMin);
        }
        return mappedValue;
    }
}
