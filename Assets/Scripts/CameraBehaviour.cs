using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] Transform head;
    [SerializeField] Transform origin;
    [SerializeField] Vector3 walkOffset;
    [SerializeField] Vector3 aimOffset;
    [SerializeField] float smoothness;

    [SerializeField] Button aimButton;

    CameraOffsetBoolInputConsumer cameraAimBoolInputConsumer;
    void Start()
    {
        Screen.SetResolution(640,320, FullScreenMode.FullScreenWindow);
        cameraAimBoolInputConsumer = new CameraOffsetBoolInputConsumer(transform, origin, aimOffset, walkOffset, smoothness);
    }
    void OnPreRender()
    {
        aimButton.GiveInput(cameraAimBoolInputConsumer);
    }
}
