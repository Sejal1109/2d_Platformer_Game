using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private float health = 100f;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private Animator animator = null;

    public Rigidbody2D rigidbody = null;
    private Vector3 m_Velocity = Vector3.zero;
    public bool isGrounded = false;
    private bool isFacingRight = true;
    Vector2 movement;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;        

        if (Input.GetButtonDown("Jump") && !Input.GetButtonDown("Fire1"))
        {
            rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
            animator.SetTrigger("Jumping");

        }
        else if (Input.GetButtonDown("Jump") && Input.GetButtonDown("Fire1")) {
            rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
            animator.SetTrigger("Attacking");
        }
        else if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attacking");
        }
        float move = movementX * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, .05f);

        animator.SetFloat("Speed", targetVelocity.sqrMagnitude);
        if (movementX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movementX < 0 && isFacingRight)
        {
            Flip();
        }

    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player Hit");
            health = health - 10;
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}