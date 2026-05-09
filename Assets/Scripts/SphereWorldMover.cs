using UnityEngine;

public class SphereWorldMover : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 120f;

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveInput) > 0.01f)
        {
            Vector3 moveDirection = player.forward;

            Vector3 rotationAxis = Vector3.Cross(moveDirection, Vector3.up);

            transform.Rotate(
                rotationAxis,
                moveInput * moveSpeed * Time.deltaTime,
                Space.World
            );
        }
    }
}