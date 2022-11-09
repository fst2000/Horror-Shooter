using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float rotationInterpolationSpeed;
    [SerializeField] float positionInterpolationSpeed;
    [SerializeField] Transform origin;
    [SerializeField] Transform lookDirection;
    [SerializeField] Vector3 cameraOffset;
    [SerializeField] Vector3 cameraTilt;
    Vector3 originLerpPosition;
    private void OnPreRender()
    {
        Quaternion cameraRotation = Quaternion.Lerp(transform.rotation, lookDirection.rotation * Quaternion.Euler(cameraTilt), rotationInterpolationSpeed * Time.deltaTime);
        transform.rotation = cameraRotation;
        transform.position = originLerpPosition + cameraRotation * cameraOffset;
        originLerpPosition = Vector3.Lerp(originLerpPosition, origin.position, positionInterpolationSpeed * Time.deltaTime);
    }
}
