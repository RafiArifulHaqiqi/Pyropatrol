using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 20f;
    public float turnSpeed = 100f;

    [Header("Mobile Button")]
    public MobileButton gasButton;
    public MobileButton brakeButton;
    public MobileButton leftButton;
    public MobileButton rightButton;

    float moveInput;
    float turnInput;

    Rigidbody rb;

    private bool enginePlaying = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ReadInput();
    }

    void FixedUpdate()
    {
        Move();
        Turn();
    }

    void ReadInput()
    {
        moveInput = 0;
        turnInput = 0;

        if (Input.GetKey(KeyCode.W))
            moveInput = 1;

        if (Input.GetKey(KeyCode.S))
            moveInput = -1;

        if (Input.GetKey(KeyCode.A))
            turnInput = -1;

        if (Input.GetKey(KeyCode.D))
            turnInput = 1;

        if (gasButton != null && gasButton.IsPressed)
            moveInput = 1;

        if (brakeButton != null && brakeButton.IsPressed)
            moveInput = -1;

        if (leftButton != null && leftButton.IsPressed)
            turnInput = -1;

        if (rightButton != null && rightButton.IsPressed)
            turnInput = 1;

        // ENGINE SOUND
        if (moveInput != 0)
        {
            if (!enginePlaying)
            {
                AudioManager.Instance.PlayEngine();
                enginePlaying = true;
            }
        }
        else
        {
            if (enginePlaying)
            {
                AudioManager.Instance.StopEngine();
                enginePlaying = false;
            }
        }
    }

    void Move()
    {
        rb.linearVelocity = transform.forward * moveInput * moveSpeed;
    }

    void Turn()
    {
        if (moveInput != 0)
        {
            rb.MoveRotation(
                rb.rotation *
                Quaternion.Euler(
                    0,
                    turnInput * turnSpeed * Time.fixedDeltaTime,
                    0));
        }
    }
}