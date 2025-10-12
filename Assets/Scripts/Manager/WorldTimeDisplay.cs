using TMPro;
using UnityEngine;


[RequireComponent(typeof(TMP_Text))]
public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField]
    private WorldTime _worldTime;
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
        _worldTime.OnTimeChanged += WorldTime_OnTimeChanged;
    }


    private void OnDestroy()
    {
        _worldTime.OnTimeChanged -= WorldTime_OnTimeChanged;
    }

    private void WorldTime_OnTimeChanged(object sender, System.TimeSpan e)
    {
        _text.SetText(e.ToString(@"hh\:mm"));
    }
}
