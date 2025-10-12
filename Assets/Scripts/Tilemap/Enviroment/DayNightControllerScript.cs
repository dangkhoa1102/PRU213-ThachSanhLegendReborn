using UnityEngine;
using UnityEngine.Rendering.Universal; // cần nếu dùng Light2D

public class DayNightController : MonoBehaviour
{
    [Header("Cycle Settings")]
    [Tooltip("Thời gian 1 ngày (giây)")]
    public float dayLength = 120f;
    [Range(0f, 1f)] public float timeOfDay = 0f; // 0 = sáng, 0.5 = tối
    public bool autoCycle = true;

    [Header("References")]
    public Light2D globalLight; // URP 2D light
    public SpriteRenderer skySprite; // background hoặc overlay

    [Header("Color Settings")]
    public Gradient lightColor; // màu ánh sáng ban ngày → ban đêm
    public Gradient skyColor;   // màu nền bầu trời

    void Update()
    {
        if (autoCycle)
            timeOfDay += Time.deltaTime / dayLength;
        if (timeOfDay > 1f) timeOfDay -= 1f;

        UpdateLighting(timeOfDay);
    }

    void UpdateLighting(float t)
    {
        if (globalLight)
        {
            globalLight.color = lightColor.Evaluate(t);
            globalLight.intensity = Mathf.Lerp(1f, 0.2f, Mathf.Sin(t * Mathf.PI)); // sáng→tối
        }

        if (skySprite)
            skySprite.color = skyColor.Evaluate(t);
    }
}
