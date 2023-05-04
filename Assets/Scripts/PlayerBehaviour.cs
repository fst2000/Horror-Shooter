using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Joystick joystick;
    new Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    RigidBodyMoveSystem moveSystem;
    IInputConsumer inputConsumer;
    void Start()
    {
        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = 1.8f;
        capsuleCollider.radius = 0.2f;
        capsuleCollider.center = new Vector3(0, 0.9f, 0);

        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = 80;
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        moveSystem = new RigidBodyMoveSystem(rigidbody);
        inputConsumer = new WalkConsumer(moveSystem, cameraTransform, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        joystick.GiveInput(inputConsumer);
    }
}
