using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int uid;
    public string nickname;
    public Weapon weapon;
    private float health = 100;
    private float horizontalAxis;
    private float verticalAxis;
    [SerializeField]
    private float speed = 5.0f;
    private Rigidbody2D rb;
    private TextMeshProUGUI nicknameText;
    [SerializeField]
    private Canvas cv;
    private Vector2 mousePos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        nicknameText = GameObject.Find("PlayerNickname").GetComponent<TextMeshProUGUI>();
        if (PlayerPrefs.HasKey("nickname"))
        {
            nickname = nicknameText.text = PlayerPrefs.GetString("nickname");
        }
    }
    private void Start()
    {
        weapon = GameObject.Find("GunPlaceHolder").GetComponentInChildren<Weapon>();
    }
    private void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        PlayerDirection();
        Move();
    }
    private void LateUpdate()
    {
        cv.transform.position = new Vector3(transform.position.x, transform.position.y-0.8f, cv.transform.position.z);
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void Heal(int health)
    {
        if(this.health + health <= 100)
        {
            this.health += health;
        }
        else
        {
            this.health = 100;
        }
    }

    public void Move()
    {
        Vector2 direction = new Vector2(horizontalAxis, verticalAxis);
        if (direction.magnitude > 0)
        {
            direction.Normalize();
            rb.velocity = speed * direction;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void PlayerDirection()
    {
        // player rotation must be equal to the mouse position
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    public void Respawn()
    {
        //Later
    }

    public void SetWeapon(Weapon weapon)
    {
        //Later
    }

    public void TakeDamage(int damage)
    {
        if((health - damage) > 0)
        {
            health -= damage;
        }
        else
        {
            Die();
        }
    }

    public float GetHealth() 
    { 
        return this.health;
    }
}
