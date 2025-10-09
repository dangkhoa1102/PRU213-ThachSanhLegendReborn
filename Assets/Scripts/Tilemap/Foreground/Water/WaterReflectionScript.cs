using UnityEngine;

[ExecuteInEditMode]
public class WaterReflectionScript : MonoBehaviour
{

    [SerializeField] private Transform mainCamera;
    [SerializeField] private bool lockY = true;

    private Vector3 offset;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main.transform;

        offset = transform.position - mainCamera.position;
    }

    void LateUpdate()
    {
        Vector3 targetPos = mainCamera.position + offset;

        if (lockY)
            targetPos.y = transform.position.y;

        transform.position = targetPos;
    }
}
