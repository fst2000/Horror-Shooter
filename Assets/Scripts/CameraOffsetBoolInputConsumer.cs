using UnityEngine;
public class CameraOffsetBoolInputConsumer : IInputConsumer<bool>
{
    Transform transform;
    Transform origin;
    Vector3 onTrue;
    Vector3 onFalse;
    float cameraSmoothness;

    public CameraOffsetBoolInputConsumer(Transform transform, Transform origin, Vector3 onTure, Vector3 onFalse, float cameraSmoothness)
    {
        this.transform = transform;
        this.origin = origin;
        this.onTrue = onTure;
        this.onFalse = onFalse;
        this.cameraSmoothness = cameraSmoothness;
    }

    public void Consume(bool input)
    {
        Vector3 offset = input? onTrue : onFalse;
        Vector3 position = origin.position + new Vector3(0,offset.y,0) + transform.rotation * new Vector3(offset.x,0,-offset.z);
        transform.position = position;
    }
}