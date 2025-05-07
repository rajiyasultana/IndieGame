using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls inputActions;
    private Vector2 moveInput;
    private float moveSpeed = 5f;
    private float max_x = 2f;
    private float min_x = -2f;

    private void Awake()
    {
        inputActions = new PlayerControls();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= ctx => moveInput = ctx.ReadValue<Vector2>();
        inputActions.Player.Move.canceled -= ctx => moveInput = Vector2.zero;
        inputActions.Player.Disable();
    }

    private void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, 0);
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // Clamp X position to stay within bounds
        float clampedX = Mathf.Clamp(transform.position.x, min_x, max_x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

    }
}
