using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] Joystick joystick;
    [SerializeField] Touchpad touchpad;
    [SerializeField] float moveSpeed;
    [SerializeField] float torqueSpeed;
    new Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    RigidBodyMoveSystem moveSystem;
    TransformTorqueSystem torqueSystem;
    IInputConsumer inputConsumer;
    TorqueConsumer torqueConsumer;
    AnimatorInputConsumer animatorInputConsumer;
    void Start()
    {
        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = 1.8f;
        capsuleCollider.radius = 0.3f;
        capsuleCollider.center = new Vector3(0, 0.9f, 0);

        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = 80;
        rigidbody.freezeRotation = true;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        moveSystem = new RigidBodyMoveSystem(rigidbody);
        torqueSystem = new TransformTorqueSystem(transform);
        inputConsumer = new WalkConsumer(moveSystem,cameraTransform, moveSpeed);
        torqueConsumer = new TorqueConsumer(torqueSystem,torqueSpeed);
        animatorInputConsumer = new AnimatorInputConsumer(gameObject.GetComponent<Animator>(), "BlendMoveX", "BlendMoveY");
    }

    // Update is called once per frame
    void Update()
    {
        joystick.GiveInput(inputConsumer);
        touchpad.GiveInput(torqueConsumer);
        joystick.GiveInput(animatorInputConsumer);
    }
}
