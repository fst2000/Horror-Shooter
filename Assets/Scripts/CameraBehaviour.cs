using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform spine;
    [SerializeField] Transform origin;
    [SerializeField] Vector3 walkOffset;
    [SerializeField] Vector3 aimOffset;
    [SerializeField] float smoothness;

    [SerializeField] Button aimButton;

    CameraOffsetBoolInputConsumer cameraAimBoolInputConsumer;
    void Start()
    {
        Screen.SetResolution(640,320, FullScreenMode.ExclusiveFullScreen);
        cameraAimBoolInputConsumer = new CameraOffsetBoolInputConsumer(transform, origin, aimOffset, walkOffset, smoothness);
    }
    void OnPreRender()
    {
        aimButton.GiveInput(cameraAimBoolInputConsumer);
        Quaternion rotation = origin.rotation * Quaternion.Euler(spine.rotation.eulerAngles.x,0,0);
        transform.rotation = Quaternion.Lerp(transform.rotation,rotation, smoothness * Time.deltaTime);
    }
}
