using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] Transform gunTransform;
    [SerializeField] float rotationSpeed = 1f;
    PlayerInput playerInput = new PlayerInput();
    new Rigidbody rigidbody;
    Vector3 characterRotateInput;
    Vector3 characrerMoveInput;
    void Start()
    {
        rigidbody = gameObject.AddComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
        rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
    }
    void Update()
    {
        characterRotateInput += new Vector3(0,playerInput.MouseX * rotationSpeed, 0);
        characrerMoveInput = playerInput.WalkInput * moveSpeed;
        transform.rotation = Quaternion.Euler(characterRotateInput);
        rigidbody.velocity = Camera.main.transform.rotation * characrerMoveInput;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(gunTransform.position, gunTransform.position + gunTransform.rotation * Vector3.forward * 1000f);
    }
}
