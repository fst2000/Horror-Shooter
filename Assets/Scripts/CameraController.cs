using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationInterpolationSpeed;
    [SerializeField] float positionInterpolationSpeed;
    [SerializeField] Transform origin;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] Vector3 cameraTilt;
    Vector3 originLerpPosition;
    private void Start()
    {

    }
    private void OnPreRender()
    {
        Quaternion cameraRotation = Quaternion.Lerp(transform.rotation, origin.rotation * Quaternion.Euler(cameraTilt), rotationInterpolationSpeed * Time.deltaTime);
        transform.rotation = cameraRotation;
        transform.position = originLerpPosition + cameraRotation * cameraOffset;
    }
    private void FixedUpdate()
    {
        originLerpPosition = Vector3.Lerp(originLerpPosition, origin.position, positionInterpolationSpeed * Time.fixedDeltaTime);
    }
}
