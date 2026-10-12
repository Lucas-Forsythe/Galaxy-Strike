using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;
    Vector2 Movement;

    void Update()
    {
        ProcessMovement();
        processRotation();
    }

    private void ProcessMovement()
    {
        float xOffset = Movement.x * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xClampRange, xClampRange);
        
        float yOffset = Movement.y * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void processRotation()
    {
        float pitch = -Movement.y * controlPitchFactor;
        float roll = -Movement.x * controlRollFactor;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0f, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }
}
