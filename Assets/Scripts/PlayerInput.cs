using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 40f;
    [SerializeField] private int maxHealth;
    [SerializeField] private int currentHealth = 100;
    [SerializeField] private float jumpSpeed = 10f;
    [SerializeField] private int numPotion;
    [SerializeField] private int Key = 0;
    [SerializeField] private int damage;
    [SerializeField] private Animator animator = null;
    [SerializeField] bool isGrounded = false;
    [SerializeField] bool canDoubleJump = false;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    public Text text;
    public Text text2;
    public TMP_Text healthText;
    public TMP_Text damageText;
    public TMP_InputField playerName;

    public HealthBar healthBar;
    public GameObject GameOverScreen;
    public GameObject levelUpScreen;
    public GameObject enterNameScreen;
    public GameObject player;

    public Rigidbody2D rigidbody = null;
    private Vector3 m_Velocity = Vector3.zero;
    private bool isFacingRight = true;
    Vector2 movement;

    private void Start()
    {
        player = GameObject.Find("Player");
        enterNameScreen = GameObject.Find("enterNameUI");
        rigidbody = GetComponent<Rigidbody2D>();
        if (MainMenu.gameState == "New")
        {
            maxHealth = SaveManager.instance.stats.maxHealth;
            numPotion = SaveManager.instance.stats.score;
            damage = SaveManager.instance.stats.attackDmg;
            enterNameScreen.SetActive(true);
        }
        if (MainMenu.gameState == "Load")
        {
            SaveManager.instance.LoadPlayer();
            maxHealth = SaveManager.instance.stats.maxHealth;
            numPotion = SaveManager.instance.stats.score;
            damage = SaveManager.instance.stats.attackDmg;
            enterNameScreen.SetActive(false);
        }
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        text = GameObject.Find("Potion").GetComponent<Text>();
        text2 = GameObject.Find("lvlPotion").GetComponent<Text>();
        healthText = GameObject.Find("health").GetComponent<TMP_Text>();
        damageText = GameObject.Find("damage").GetComponent<TMP_Text>();
        playerName = GameObject.Find("playerInput").GetComponent<TMP_InputField>();
        GameOverScreen = GameObject.Find("GameOverUI");
        GameOverScreen.SetActive(false);
        levelUpScreen = GameObject.Find("LevelUpUI");
        levelUpScreen.SetActive(false);
    }

    private void Update()
    {
        float movementX = Input.GetAxis("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump") && !Input.GetButtonDown("Fire1"))
        {
            if (isGrounded)
            {
                rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
                canDoubleJump = true;
                animator.SetTrigger("Jumping");
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                jumpSpeed = jumpSpeed / 1.5f;
                rigidbody.AddForce(new Vector3(0.0f, jumpSpeed, 0.0f));
                jumpSpeed = jumpSpeed * 1.5f;
                animator.SetTrigger("Jumping");
            }
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

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        text.text = numPotion.ToString();
        text2.text = numPotion.ToString();
        healthText.text = maxHealth.ToString();
        damageText.text = damage.ToString();
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
            numPotion += 10;
            SaveManager.instance.stats.score = numPotion;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("HPotion"))
        {
            //Debug.Log("Aquired Health Potion");
            if (currentHealth != maxHealth)
            {
                currentHealth += 5;
                healthBar.setHealth(currentHealth);
                collision.gameObject.SetActive(false);
            }

        }
        if (collision.gameObject.CompareTag("Key"))
        {
            //Debug.Log("Aquired Key");
            Key += 1;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.CompareTag("chest"))
        {
            chest();
            if (Key == 1)
            {
                LevelUp(); //I put this here because i want the chest animation to play before the level up screen

            }
        }
    }
    void chest()
    {
        if (Key == 1)
        {
            animator.SetTrigger("Chest");
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("Go Back and get the key");
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

    public void endGame()
    {
        player.gameObject.SetActive(false);
        GameOverScreen.SetActive(true);
    }
    public void LevelUp()
    {
        levelUpScreen.SetActive(true);
    }
    public void healthUp()
    {
        if (numPotion > 3)
        {
            numPotion -= 10;
            maxHealth += 5;
            SaveManager.instance.stats.maxHealth = maxHealth;
            SaveManager.instance.stats.score = numPotion;
        }

    }
    public void damageUp()
    {
        if (numPotion > 2)
        {
            numPotion -= 10;
            damage += 10;
            SaveManager.instance.stats.attackDmg = damage;
            SaveManager.instance.stats.score = numPotion;
        }
    }

    public void saveName()
    {
        string pName = playerName.text;
        SaveManager.instance.stats.name = pName.ToString();
        enterNameScreen.SetActive(false);
    }
}