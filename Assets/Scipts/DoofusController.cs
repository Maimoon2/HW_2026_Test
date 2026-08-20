using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class DoofusController : MonoBehaviour
{
    [SerializeField] private float fallbackSpeed = 3f;
    private GameObject lastPulpit;
    /*[SerializeField] private bool rotateToFaceMovement = true;
    [SerializeField] private float rotationSpeed = 100f;*/

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            input.x = Keyboard.current.aKey.isPressed ? -1f : 0f;
            input.x += Keyboard.current.dKey.isPressed ? 1f : 0f;
            input.y = Keyboard.current.sKey.isPressed ? -1f : 0f;
            input.y += Keyboard.current.wKey.isPressed ? 1f : 0f;

            // Arrow keys
            input.x += Keyboard.current.leftArrowKey.isPressed ? -1f : 0f;
            input.x += Keyboard.current.rightArrowKey.isPressed ? 1f : 0f;
            input.y += Keyboard.current.downArrowKey.isPressed ? -1f : 0f;
            input.y += Keyboard.current.upArrowKey.isPressed ? 1f : 0f;
        }

        input = Vector2.ClampMagnitude(input, 1f);
        Vector3 movement = new Vector3(input.x, 0f, input.y);

        float speed = (GameConfig.Instance != null) ? GameConfig.Instance.Speed : fallbackSpeed;

        rb.linearVelocity = new Vector3(
            movement.x * speed,
            rb.linearVelocity.y,
            movement.z * speed
        );

        /*if (rotateToFaceMovement && movement.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movement, Vector3.up);
            rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
        }*/
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pulpit"))
        {
            if (collision.gameObject != lastPulpit)
            {
                lastPulpit = collision.gameObject;

                if (ScoreManager.Instance != null)
                {
                    ScoreManager.Instance.ReachedPulpit(collision.gameObject);
                }
            }
        }
    }
}