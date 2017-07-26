using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public GameObject cameraPosition;
    private Vector3 velocity;
    public float speed = 10f;

    void Start()
    {
        cameraPosition = GameManager.Instance.player._cameraPosition;
    }

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, cameraPosition.transform.position, ref velocity, 0.2f);
        transform.rotation = Quaternion.Lerp(transform.rotation, cameraPosition.transform.rotation, 1f);
    }


}
