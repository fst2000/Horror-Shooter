using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraRotationSpeed = 1f;
    [SerializeField] Transform origin;
    [SerializeField] Vector3 cameraPosition;
    Vector3 cameraAngles = new Vector3();
    void Update()
    {
        Vector3 mouseInput = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        cameraAngles += mouseInput * cameraRotationSpeed;
        cameraAngles.x = Mathf.Clamp(cameraAngles.x, -45f,45f);
        transform.rotation =  Quaternion.Euler(cameraAngles);
        transform.position = origin.position + transform.rotation * cameraPosition;
    }
}
