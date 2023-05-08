using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] Transform spineBone;
    [SerializeField] Transform cameraTransform;

    [SerializeField] Joystick joystick;
    [SerializeField] Touchpad touchpad;
    [SerializeField] Button aimButton;

    [SerializeField] float moveSpeed;
    [SerializeField] float torqueSpeed;

    new Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;
    RigidBodyMoveSystem moveSystem;

    TransformTorqueSystem torqueSystem;
    TransformTorqueSystem spineTorqueSystem;
    SpineTorqueInputConsumer spineTorqueConsumer;
    IInput<Vector2> touchpadInput;

    IInputConsumer<Vector2> walkVector2InputConsumer;
    IInputConsumer<Vector2> playerTorqueConsumer;
    IInputConsumer<Vector2> animatorInputConsumer;
    IInputConsumer<bool> animatorAimBoolInputConsumer;
    void Start()
    {
        capsuleCollider = gameObject.AddComponent<CapsuleCollider>();
        capsuleCollider.height = 1.8f;
        capsuleCollider.radius = 0.3f;
        capsuleCollider.center = new Vector3(0, 0.9f, 0);

        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.mass = 80;
        rigidbody.freezeRotation = true;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
        rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;

        moveSystem = new RigidBodyMoveSystem(rigidbody);
        torqueSystem = new TransformTorqueSystem(transform);
        spineTorqueSystem = new TransformTorqueSystem(spineBone);
        spineTorqueConsumer = new SpineTorqueInputConsumer(spineTorqueSystem,torqueSpeed);
        walkVector2InputConsumer = new WalkConsumer(moveSystem,cameraTransform, moveSpeed);
        playerTorqueConsumer = new PlayerTorqueVector2InputConsumer(torqueSystem,torqueSpeed);
        Animator animator = gameObject.GetComponent<Animator>();
        animatorInputConsumer = new AnimatorVector2InputConsumer(animator, "BlendMoveX", "BlendMoveY");
        animatorAimBoolInputConsumer = new AnimatorBoolInputConsumer(animator, "GunAim", "WalkBlend");
    }
    void Update()
    {
        touchpadInput = touchpad.Input();
        joystick.GiveInput(walkVector2InputConsumer);
        joystick.GiveInput(animatorInputConsumer);
        aimButton.GiveInput(animatorAimBoolInputConsumer);
        touchpadInput.GiveInput(playerTorqueConsumer);
    }
    void LateUpdate()
    {
        touchpadInput.GiveInput(spineTorqueConsumer);
    }
}
