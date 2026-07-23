using UnityEngine;
using UnityEngine.InputSystem;

public class CrosshairController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float acceleration = 3f;
    [SerializeField] private float deceleration = 3f;
    [SerializeField] private float turnResistance = 1f;

    private Rigidbody2D _rb;
    private Vector2 moveDirection;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 currentVelocity = _rb.linearVelocity;

        if (moveDirection.sqrMagnitude < 0.0001f)
        {
            _rb.linearVelocity = Vector2.MoveTowards(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
            return;
        }

        Vector2 desiredDirection = moveDirection.normalized;
        float speed = currentVelocity.magnitude;
        float dot = speed > 0.01f ? Vector2.Dot(currentVelocity.normalized, desiredDirection) : 1f;
        float turnFactor = Mathf.Lerp(turnResistance, 1f, Mathf.InverseLerp(-1f, 1f, dot));

        Vector2 accelerationVector = desiredDirection * acceleration * turnFactor;
        Vector2 nextVelocity = currentVelocity + accelerationVector * Time.fixedDeltaTime;
        _rb.linearVelocity = Vector2.ClampMagnitude(nextVelocity, maxSpeed);
    }

    private void OnMove(InputValue inputValue)
    {
        moveDirection = inputValue.Get<Vector2>();
    }
}
