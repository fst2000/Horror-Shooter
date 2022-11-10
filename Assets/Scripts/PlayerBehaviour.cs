using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] Transform gunTransform;
    [SerializeField] float rotationSpeed = 1f;
    PlayerInput playerInput;
    CapsuleCollider capsuleCollider;
    NavMeshAgent navMeshAgent;
    Animator animator;
    float playerRotation;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        navMeshAgent.radius = capsuleCollider.radius;
        navMeshAgent.height = capsuleCollider.height;
        animator = gameObject.GetComponent<Animator>();
        playerInput = new PlayerInput();
    }
    void Update()
    {
        playerRotation += playerInput.MouseX * rotationSpeed * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(playerRotation, Vector3.up);
        Vector3 velocity = navMeshAgent.velocity;
        navMeshAgent.velocity = playerInput.WalkInput * moveSpeed;
        animator.SetFloat("BlendMoveX", playerInput.MoveHorizontal);
        animator.SetFloat("BlendMoveY", playerInput.MoveVertical);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gunTransform.position, gunTransform.position + gunTransform.rotation * Vector3.down * 1000f);
    }
}
