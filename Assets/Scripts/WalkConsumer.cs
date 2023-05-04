using UnityEngine;

public class WalkConsumer : IInputConsumer
{
    IMoveSystem moveSystem;
    Transform viewPoint;
    float walkSpeed;

    public WalkConsumer(IMoveSystem moveSystem, Transform viewPoint, float walkSpeed)
    {
        this.moveSystem = moveSystem;
        this.viewPoint = viewPoint;
        this.walkSpeed = walkSpeed;
    }

    public void Consume(Vector2 input)
    {
        moveSystem.Move(viewPoint.TransformDirection(new Vector3(input.x, 0, input.y) * walkSpeed));
    }
}