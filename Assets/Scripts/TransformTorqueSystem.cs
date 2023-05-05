using UnityEngine;

public class TransformTorqueSystem : ITorqueSystem
{
    Transform transform;

    public TransformTorqueSystem(Transform transform)
    {
        this.transform = transform;
    }

    public void Torque(Vector3 eulerAngles)
    {
        transform.rotation = Quaternion.Euler(eulerAngles * Time.deltaTime) * transform.rotation;
    }
}