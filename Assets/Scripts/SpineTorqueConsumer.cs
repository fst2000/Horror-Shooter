using UnityEngine;

public class SpineTorqueConsumer : IInputConsumer
{
    ITorqueSystem torqueSystem;
    float torqueSpeed;
    Vector3 boneEuler = Vector3.zero;

    public SpineTorqueConsumer(ITorqueSystem torqueSystem, float torqueSpeed)
    {
        this.torqueSystem = torqueSystem;
        this.torqueSpeed = torqueSpeed;
    }

    public void Consume(Vector2 input)
    {
        boneEuler += new Vector3(input.y,0,0) * torqueSpeed;
        Debug.Log(boneEuler);
        torqueSystem.Torque(boneEuler);
    }
}