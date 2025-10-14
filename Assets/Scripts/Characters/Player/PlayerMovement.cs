using NUnit.Framework.Interfaces;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // === Trạng thái ===
    public AirState airborne;
    public IdleState idle;
    public RunState running;

    private State state;

    // === Components ===
    public Rigidbody2D body;
    public BoxCollider2D groundCheck;
    public Animator animator;

    // === Cấu hình ===
    public LayerMask groundMask;

    [Tooltip("gia tốc (tốc độ tăng tốc)")]
    [Range(0f, 100f)]
    public float acceleration = 10f;
    [Range(0f, 1f)] public float groundDecay = 0.8f;

    [Tooltip("Tốc độ tối đa của nhân vật")]
    [Range(0f, 20f)]
    public float maxXSpeed = 5f;

    [Tooltip("Lực nhảy của nhân vật")]
    [Range(0f, 20f)]
    public float jumpSpeed = 10f;

    // === Biến runtime ===
    public bool grounded { get; private set; }
    public float xInput { get; private set; }
    public float yInput { get; private set; }

    void Awake()
    {
        // Tự tìm các component cần thiết
        //body = GetComponent<Rigidbody2D>();
        //animator = GetComponentInChildren<Animator>();

        //// Tìm groundCheck trong child theo tên (hoặc theo component nếu muốn)
        //groundCheck = GetComponentInChildren<BoxCollider2D>(includeInactive: true);

        //// Nếu các state là ScriptableObject — thì có thể gán qua inspector hoặc tự tạo instance
        //if (airborne == null) airborne = GetComponentInChildren<AirState>();
        //if (idle == null) idle = GetComponentInChildren<IdleState>();
        //if (running == null) running = GetComponentInChildren<RunState>();

        //// Đặt state mặc định
        //state = idle;
        //state.Enter();


    }

    void Start()
    {
        idle.Setup(body, animator, this);
        running.Setup(body, animator, this);
        airborne.Setup(body, animator, this);

        state = idle;// Đặt state mặc định
    }

    void Update()
    {
        CheckInput();
        HandleJump();

        if (state.isComplete)
            SelectState();

        state.FrameUpdate();
    }

    void FixedUpdate()
    {
        CheckGround();
        HandleXMovement();
        ApplyFriction();
    }

    // ================== STATE LOGIC ==================
    void SelectState()
    {
        if (grounded)
        {
            if (Mathf.Abs(xInput) < 0.01f)
                state = idle;
            else
                state = running;
        }
        else
        {
            state = airborne;
        }

        state.Enter();
    }

    // ================== INPUT & MOVEMENT ==================
    void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
    }

    void HandleXMovement()
    {
        if (Mathf.Abs(xInput) > 0)
        {
            float increment = xInput * acceleration;
            float newSpeed = Mathf.Clamp(body.linearVelocity.x + increment, -maxXSpeed, maxXSpeed);
            body.linearVelocity = new Vector2(newSpeed, body.linearVelocity.y);
            FaceInput();
        }
    }

    void FaceInput()
    {
        float direction = Mathf.Sign(xInput);
        transform.localScale = new Vector3(direction, 1, 1);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, airborne.jumpSpeed);
        }
    }

    void CheckGround()
    {
        if (groundCheck != null)
        {
            grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
        }
    }

    void ApplyFriction()
    {
        if (grounded && Mathf.Abs(xInput) < 0.01f && body.linearVelocity.y <= 0)
        {
            body.linearVelocity *= groundDecay;
        }
    }
}
