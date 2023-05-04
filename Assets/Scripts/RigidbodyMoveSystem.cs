using UnityEngine;

public class RigidBodyMoveSystem : IMoveSystem
{
    Rigidbody rigidbody;

    public RigidBodyMoveSystem(Rigidbody rigidbody)
    {
        this.rigidbody = rigidbody;
    }

    public void Move(Vector3 moveVector)
    {
        Vector3 gravity = new Vector3(0, rigidbody.velocity.y, 0);
        rigidbody.velocity = moveVector + gravity;
    }
}