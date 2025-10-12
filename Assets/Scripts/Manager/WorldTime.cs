using System;
using System.Collections;
using UnityEngine;

public class WorldTime : MonoBehaviour
{
    public event EventHandler<TimeSpan> OnTimeChanged;

    [Header("Cycle Settings")]
    [Tooltip("Length of a full day in seconds")]
    public float _dayLength;// Seconds

    [Range(0f, 1f)] TimeSpan _currentTime;

    private float _minutesLength => _dayLength / WorldTimeConstants.MinutesInDay;

    private void Start()
    {
        _currentTime = new TimeSpan(6, 0, 0); // Start at 6:00 AM
        StartCoroutine(AddMinute());
    }

    private IEnumerator AddMinute()
    {
        while (true)
        {
            _currentTime += TimeSpan.FromMinutes(1);
            OnTimeChanged?.Invoke(this, _currentTime);
            yield return new WaitForSeconds(_minutesLength);
        }
    }
}
