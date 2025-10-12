using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class WorldLight : MonoBehaviour
{
    [Header("References")]
    public Light2D _globalLight;
    public SpriteRenderer _skySprite;
    public Material _skyMaterial;

    private WorldTime _worldTime;

    [Header("Color Settings")]
    [Tooltip("màu n?n b?u tr?i")]
    public Gradient _skyColor;
    [Tooltip("màu ánh sáng ")]
    public Gradient _lightGradient;

    private void Awake()
    {
        _globalLight = GetComponent<Light2D>();
        _skySprite = GameObject.FindWithTag("Sky").GetComponent<SpriteRenderer>();
        _worldTime.OnTimeChanged += WorldTime_OnTimeChanged;
    }

    private void OnDestroy()
    {
        _worldTime.OnTimeChanged -= WorldTime_OnTimeChanged;
    }

    private void WorldTime_OnTimeChanged(object sender, System.TimeSpan e)
    {
        _globalLight.color = _lightGradient.Evaluate(PercentOfDay(e));
        _skySprite.color = _skyColor.Evaluate(PercentOfDay(e));
    }

    private float PercentOfDay(System.TimeSpan time)
    {
        return (float)time.TotalMinutes / WorldTimeConstants.MinutesInDay;
    }


}
