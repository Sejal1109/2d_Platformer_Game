using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float jumpSpeed = 10f;
    //[SerializeField] private Animator animator = null;

    public Rigidbody2D rigidbody = null;
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

        //if (Input.GetButtonDown("Jump"))
        //{
        //  animator.SetTrigger("IsAttacking");
        //}

        //animator.SetFloat("Horizontal", movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);

        

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));

        }
        Vector3 move = new Vector3(movementX * Time.deltaTime, 0.0f, 0.0f);
        transform.Translate(move);
        if (movementX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (movementX < 0 && isFacingRight)
        {
            Flip();
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