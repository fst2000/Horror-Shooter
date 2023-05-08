using UnityEngine;

public class WalkConsumer : IInputConsumer<Vector2>
{
    IMoveSystem moveSystem;
    ITorqueSystem torqueSystem;
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
        Vector3 moveDirection = viewPoint.TransformDirection(new Vector3(input.x, 0, input.y));
        Vector3 flatMoveDirection = new Vector3(moveDirection.x,0,moveDirection.z);
        moveSystem.Move(flatMoveDirection * walkSpeed);
    }
}