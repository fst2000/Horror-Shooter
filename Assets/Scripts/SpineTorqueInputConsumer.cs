using UnityEngine;

public class SpineTorqueInputConsumer : IInputConsumer<Vector2>
{
    ITorqueSystem torqueSystem;
    float torqueSpeed;
    Vector3 boneEuler = Vector3.zero;

    public SpineTorqueInputConsumer(ITorqueSystem torqueSystem, float torqueSpeed)
    {
        this.torqueSystem = torqueSystem;
        this.torqueSpeed = torqueSpeed;
    }

    public void Consume(Vector2 input)
    {
        boneEuler += new Vector3(-input.y,0,0) * torqueSpeed;
        boneEuler.x = Mathf.Clamp(boneEuler.x,-40,30);
        torqueSystem.Torque(boneEuler);
    }
}