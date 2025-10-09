using UnityEngine;

public class ApplySortingLayer : MonoBehaviour
{
    public string sortingLayerName = "Background";
    public int orderInLayer = 2;

    void Start()
    {
        foreach (var sr in GetComponentsInChildren<SpriteRenderer>())
        {
            sr.sortingLayerName = sortingLayerName;
            sr.sortingOrder = orderInLayer;
        }
    }
}
