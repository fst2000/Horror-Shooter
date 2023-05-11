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
    [SerializeField] float minTiltAngle;
    [SerializeField] float maxTiltAngle;
    float tiltAngle;

    new Rigidbody rigidbody;
    CapsuleCollider capsuleCollider;

    IInputConsumer<Vector2> playerVector2JoystickConsumer;
    IInputConsumer<Vector2> playerVector2TouchpadConsumer;
    IMoveSystem moveSystem;

    ITorqueSystem playerTorqueSystem;
    ITorqueSystem spineTorqueSystem;
    ITorqueSystem cameraTorqueSystem;
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
        playerTorqueSystem = new TransformTorqueSystem(transform);
        spineTorqueSystem = new TransformTorqueSystem(spineBone);
        cameraTorqueSystem = new DelegateTorqueSystem(eulerAngles =>
        {
            eulerAngles.x = Mathf.Clamp(eulerAngles.x, minTiltAngle, maxTiltAngle);
            cameraTransform.rotation *= Quaternion.Euler(eulerAngles);
        });

        Animator animator = gameObject.GetComponent<Animator>();

        playerVector2JoystickConsumer = new DelegateInputConsumer<Vector2>(input =>
        {
            moveSystem.Move(transform.TransformDirection(new Vector3(input.x , 0, input.y) * moveSpeed));
        });
        playerVector2TouchpadConsumer = new DelegateInputConsumer<Vector2>(input =>
        {
            playerTorqueSystem.Torque(new Vector3(0,input.x,0) * torqueSpeed);
            tiltAngle += -input.y;
            tiltAngle = Mathf.Clamp(tiltAngle, minTiltAngle, maxTiltAngle);
            spineTorqueSystem.Torque(new Vector3(tiltAngle,0,0));
            cameraTorqueSystem.Torque(new Vector3(-input.y,0,0));
        });
    }
    void Update()
    {
        joystick.GiveInput(playerVector2JoystickConsumer);
    }
    void LateUpdate()
    {
        IInput<Vector2> touchpadInput = touchpad.Input();
        touchpadInput.GiveInput(playerVector2TouchpadConsumer);
    }
}
