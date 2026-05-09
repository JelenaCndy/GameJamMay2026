using UnityEngine;

public class CharacterTurn : MonoBehaviour
{
    public float turnSpeed = 180f;

    void Update()
    {
        float turnInput = 0f;

        if (Input.GetKey(KeyCode.A))
            turnInput = -1f;

        if (Input.GetKey(KeyCode.D))
            turnInput = 1f;

        // Rotate character left/right
        transform.Rotate(Vector3.up * turnInput * turnSpeed * Time.deltaTime);
    }
}