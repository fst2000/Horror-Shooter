using UnityEngine;

public class PlayerTorqueVector2InputConsumer : IInputConsumer<Vector2>
{
    ITorqueSystem torqueSystem;
    float torqueSpeed;

    public PlayerTorqueVector2InputConsumer(ITorqueSystem torqueSystem, float torqueSpeed)
    {
        this.torqueSystem = torqueSystem;
        this.torqueSpeed = torqueSpeed;
    }

    public void Consume(Vector2 input)
    {
        Vector3 torque = new Vector3(0,input.x,0) * torqueSpeed;
        torqueSystem.Torque(torque);
    }
}