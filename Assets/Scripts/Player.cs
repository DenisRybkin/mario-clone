using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{

    private HealthbarManager? healthbarManager;

    public float speed = 0.15f;
    public float jumpForce;

    public float speedBonus;
    public float timerSpeed;
    public float timerSpeedMax;

    public float timerScale;
    public float timerScaleMax;
    public int fires = 0;
    public int lives = 5;

    private float speedStart;
    
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    [SerializeField] private ContactFilter2D _platform;
    private bool isGrounded => rigidBody.IsTouching(_platform);

    public int score = 0;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textFires;

    public GameObject fireBulet;
    public Transform fireBuletPoint;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        healthbarManager = GetComponentInChildren<HealthbarManager>();
    }

    public void SpeedBonus()
    {
        timerSpeed = timerSpeedMax;
    }

    public void ScaleBonus()
    {
        timerScale = timerScaleMax;
    }

    private void Start()
    {
        score = PlayerPrefs.GetInt("score",0);
        textScore.text = score.ToString();
        speedStart = speed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) Jump();
        if (Input.GetKeyDown(KeyCode.F) && fires > 0) ShootFire();
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);

    }

    private void FixedUpdate()
    {
        if (timerSpeed > 0) { speed = speedBonus; timerSpeed--; }
        else speed = speedStart;

        if (RunCutscene.isCutsceneOn) return;

        BonusCheck();
        Move();

    }

    public void Damage()
    {
        lives--;
        Debug.Log(healthbarManager.ToString());
        healthbarManager?.TakeDamage(20);
        if(lives <= 0)
        {
            if (score > 0) PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - score);
            SceneManager.LoadScene(2);
            Destroy(gameObject);
        }
    }

    private void Move()
    {
        if (Input.GetAxis("Horizontal") != 0)
            animator.SetInteger("State", 1);
        else animator.SetInteger("State", 0);
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        spriteRenderer.flipX = dir.x <= 0.0f;

        Vector3 position = transform.position;

        position.x += Input.GetAxis("Horizontal") * speed;

        transform.position = position;
    }

    private void BonusCheck()
    {
        if (timerSpeed > 0) { speed = speedBonus; timerSpeed--; }
        else speed = speedStart;

        if (timerScale > 0) 
        {
            transform.localScale = new Vector3(1.5f,1.5f,1);
            timerScale--; 
        }
        else transform.localScale = new Vector3(1, 1, 1);
    }


    private void Jump()
    {
        if (isGrounded)
            rigidBody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        
    }

    private void ShootFire()
    {
        fires--;
        textFires.text = fires.ToString();
        Instantiate(fireBulet, fireBuletPoint.position, transform.rotation);
    }

    public void AddCoin(int count)
    {
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score", score) + count);
        score += count;
        textScore.text = score.ToString();
    }

    public void AddFires(int count)
    {
        fires += count;
        textFires.text = fires.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovePlatform"))
        {
            var origScale = transform.localScale;
            transform.parent = collision.transform;
            transform.parent.localScale = origScale;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MovePlatform"))
            transform.parent = null;
    }
}
