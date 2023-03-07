using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth = 100;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private int numPotion = 0;
    [SerializeField] private Animator animator = null;


    public Text text;
    public HealthBar healthBar;


    public Rigidbody2D rigidbody = null;
    private Vector3 m_Velocity = Vector3.zero;
    public bool isGrounded = false;
    private bool isFacingRight = true;
    Vector2 movement;

    private void Start()
    {
        currentHealth = maxHealth;
        rigidbody = GetComponent<Rigidbody2D>();
        healthBar.setMaxHealth(maxHealth);
        text = GameObject.Find("Potion?").GetComponent<Text>();    // Domnt working for some reason 
        text.text = "it works";
        
    }

    private void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;        

        if (Input.GetButtonDown("Jump") && !Input.GetButtonDown("Fire1"))
        {
            rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
            animator.SetTrigger("Jumping");

        }
        float move = movementX * Time.deltaTime;
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
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

        //Debug.Log(text.text);
        //Debug.Log(numPotion);
        text.text = numPotion.ToString();
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy temp = collision.gameObject.GetComponent<Enemy>();
            TakeDamage(temp.dmgDealt);
            
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            Debug.Log("Hit Water");
            TakeDamage(maxHealth);
        }
        if (collision.gameObject.CompareTag("potion"))
        {
            Debug.Log("Aquired Potion");
            numPotion += 1;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("HPotion"))
        {
            Debug.Log("Aquired Health Potion");
            currentHealth += 10;
            healthBar.setHealth(currentHealth);
            collision.gameObject.SetActive(false);
        }

    }

    void TakeDamage(int damage) 
    { 
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
        if (currentHealth > 0)
        {
            animator.SetTrigger("Hit");
        }
        else if (currentHealth <= 0) 
        {
            animator.SetTrigger("Die");
            Invoke("endGame", 1);
        }
    }
    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void endGame() {
        SceneManager.LoadScene("MainMenu");
    }
}