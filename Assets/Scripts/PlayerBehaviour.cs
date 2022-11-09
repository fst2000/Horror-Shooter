using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] Transform gunTransform;
    [SerializeField] float rotationSpeed = 1f;
    PlayerInput playerInput;
    new Rigidbody rigidbody;
    Animator animator;
    Vector3 characterRotateInput;
    Vector3 characrerMoveInput;
    void Start()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        playerInput = new PlayerInput();
        rigidbody.freezeRotation = true;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }
    void Update()
    {
        characterRotateInput += new Vector3(0,playerInput.MouseX * rotationSpeed * Time.deltaTime, 0);
        characrerMoveInput = playerInput.WalkInput * moveSpeed;
        transform.rotation = Quaternion.Euler(characterRotateInput);
        Vector3 velocity = rigidbody.velocity;
        rigidbody.velocity = new Vector3(playerInput.WalkInput.x * moveSpeed, velocity.y,playerInput.WalkInput.z * moveSpeed);
        animator.SetFloat("BlendMoveX", playerInput.MoveHorizontal);
        animator.SetFloat("BlendMoveY", playerInput.MoveVertical);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gunTransform.position, gunTransform.position + gunTransform.rotation * Vector3.down * 1000f);
    }
}
