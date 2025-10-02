using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Camera _camera;

    public Transform subject;

    Vector2 startPosition;
    float startZ;

    Vector2 travel => (Vector2)_camera.transform.position - startPosition;


    float parallaxEffect => Mathf.Abs(distanceFromSubject) / clippingPlane;
    float distanceFromSubject => transform.position.x - subject.position.x;

    float clippingPlane => (_camera.transform.position.z + (distanceFromSubject > 0? _camera.farClipPlane: _camera.nearClipPlane));




    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        //Vector2 newPosition = startPosition + parallaxEffect;
        //transform.position = new Vector3(newPosition.x, newPosition.y, startZ);

        Vector2 newPos = startPosition + travel * parallaxEffect;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);

    }
}
