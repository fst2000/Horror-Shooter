using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    [SerializeField] GameObject joystick;

    [SerializeField] Button aimButton;

    RenderBoolInputConsumer joystickRenderConsumer;
    void Start()
    {
        joystickRenderConsumer = new RenderBoolInputConsumer(joystick);
    }
    void Update()
    {
        aimButton.GiveInput(new DelegateInputConsumer<bool>(i => joystickRenderConsumer.Consume(!i)));
    }
}
