using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController controller;

    public float speed = 12f;
    public float gravity = 9.81f;
    public float jumpHeight = 3f;
    int dashCount = 0;

    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;
    Rigidbody rb;
    public float dashForce = 2f;
    [SerializeField] PauseMenu pauseMenu;

    bool isGrounded;
    void Start()
    {
        groundCheck = transform.GetChild(0);
        controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (pauseMenu.on) return;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (!isGrounded)
        {
            speed = 5;
            rb.drag = 0;
        }
        else
        {
            speed = 8;
            rb.drag = 5;
            dashCount = 0;
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && dashCount <1 && Time.timeScale < 1f)
        {
            dashCount++;
            rb.AddForce(transform.forward * dashForce, ForceMode.Impulse);
        }

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > 7)
        {
            Vector3 limitedVel = flatVel.normalized * 7;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }


        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        rb.AddForce(move.normalized * speed * 100f, ForceMode.Force);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, groundDistance);
    }
}
