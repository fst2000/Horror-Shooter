using UnityEngine;

public class TransformMoveSystem : IMoveSystem
{
    Transform transform;

    public TransformMoveSystem(Transform transform)
    {
        this.transform = transform;
    }

    public void Move(Vector3 moveVector)
    {
        transform.position += moveVector;
    }
}