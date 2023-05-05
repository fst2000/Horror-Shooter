using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform origin;
    [SerializeField] float height;
    [SerializeField] float distance;
    [SerializeField] float offset;
    void OnPreRender()
    {
        transform.rotation = origin.rotation;
        transform.position = origin.position + new Vector3(0,height,0) + (transform.rotation * new Vector3(offset,0,-distance));
    }
}
