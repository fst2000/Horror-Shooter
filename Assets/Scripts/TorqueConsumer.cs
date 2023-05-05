using UnityEngine;

public class TorqueConsumer : IInputConsumer
{
    ITorqueSystem torqueSystem;
    float torqueSpeed;

    public TorqueConsumer(ITorqueSystem torqueSystem, float torqueSpeed)
    {
        this.torqueSystem = torqueSystem;
        this.torqueSpeed = torqueSpeed;
    }

    public void Consume(Vector2 input)
    {
        Vector3 torque = new Vector3(0,input.x,0) * torqueSpeed * Time.deltaTime;
        torqueSystem.Torque(torque);
    }
}