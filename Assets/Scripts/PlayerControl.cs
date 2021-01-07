using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public static PlayerControl instance;
    private CapsuleCollider2D playerBoxCollider;
    public LayerMask whatIsGround;
    public GameObject player;

    public Animator animator;
    
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    public float speed = 10;
    public float jumpHeight = 8;
    public float moveInput;

    private Rigidbody2D body;
    private bool isFacingRight = true;
    public bool isMoving = true;

    public int maxFallDistance = -100;
    public bool isDesinfecting = false;

    private float timer;
    private bool won;
    private bool lost;
    public GameObject deathPanel;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        playerBoxCollider = transform.GetComponent<CapsuleCollider2D>();
        body = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);

        animator = GetComponent<Animator>();

        timer = 0;
        won = false;
        lost = false;
        deathPanel.SetActive(false);
    }

    void FixedUpdate()
    {
        //MOVE LEFT AND RIGHT
        if(isMoving) 
        {
            moveInput = Input.GetAxis("Horizontal");
            body.velocity = new Vector2(moveInput * speed, body.velocity.y); //move horizontaly
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        } else
        {
            animator.SetFloat("Speed", 0);
        }

        // TURN AROUND
        if (isFacingRight == false && moveInput > 0)
        {
            Flip(); 
        } 
        else if (isFacingRight == true && moveInput < 0) 
        {
            Flip();
        }

    }

    private void Update()
    {
        if (isMoving)
        {
            //JUMPING
            if (Input.GetKey(KeyCode.Space) && isGrounded())
            {
                body.velocity = Vector2.up * jumpHeight;
                animator.SetBool("isJumping", true);
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("isJumping", false);
            }

            //DESINFECT
            if (Input.GetKey(KeyCode.B))
            {
                isDesinfecting = true;
                animator.SetBool("isDesinfecting", true);
            }
            else if (Input.GetKeyUp(KeyCode.B))
            {
                isDesinfecting = false;
                animator.SetBool("isDesinfecting", false);
            }

            //JUMPING & DESINFECTING
            if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isJumpingAndDesinfecting", true);
                animator.SetBool("isDesinfecting", false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isRunningAndDesinfecting", false);
            }
            else if (Input.GetKeyUp(KeyCode.B) || Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("isJumpingAndDesinfecting", false);
            }

            //RUNNING & DESINFECTING
            if (Input.GetKey(KeyCode.B) && animator.GetFloat("Speed") > 0.01)
            {
                animator.SetBool("isRunningAndDesinfecting", true);
                animator.SetBool("isDesinfecting", false);
                animator.SetBool("isJumpingAndDesinfecting", false);
            }
            else if (Input.GetKeyUp(KeyCode.B) || animator.GetFloat("Speed") < 0.01)
            {
                animator.SetBool("isRunningAndDesinfecting", false);
            }

            //RUNNING, JUMPING & DESINFECTING
            if (Input.GetKey(KeyCode.B) && animator.GetFloat("Speed") > 0.01 && Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("isJumpingAndDesinfecting", true);
                animator.SetBool("isDesinfecting", false);
                animator.SetBool("isJumping", false);
                animator.SetBool("isRunningAndDesinfecting", false);
            }
            else if (Input.GetKeyUp(KeyCode.B) && animator.GetFloat("Speed") < 0.01 && Input.GetKeyUp(KeyCode.Space))
            {
                animator.SetBool("isJumpingAndDesinfecting", false);
            }
        }

        // CHECK IF FELL TO INFINITY
        timer += Time.deltaTime;

        if (timer >= 5 && lost == true)
        {
            decreaseHealth(currentHealth / 2);
            transform.position = GameManager.instance.lastCheckpoitPos;
            lost = false;
            deathPanel.SetActive(false);
        }

        //WIN AFTER CATCHING VACCINE
        if (timer >= 3 && won == true)
        {
            SceneManager.LoadScene("YouWin");
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Colide with limit definer object
        if(other.tag == "DeathCollider")
        {
            timer = 0;
            lost = true;
            if (GameManager.instance.isIsolated == false)
            {
                deathPanel.SetActive(true);
                GameManager.instance.dieSound.Play();
            }
        }

        //Collide with vaccine
        if (other.tag == "Vaccine" && GameManager.instance.getKnowledge() == GameManager.instance.maxKnowledge)
        {
            timer = 0;
            won = true;
            GameManager.instance.winSound.Play();
            animator.SetBool("isCelebrating", true);
        }
    }

    private bool isGrounded()
    {
        float extraHeightText = 0.5f;
        RaycastHit2D raycastHit = Physics2D.Raycast(playerBoxCollider.bounds.center, Vector2.down, playerBoxCollider.bounds.extents.y + extraHeightText, whatIsGround);

        return raycastHit.collider != null;
    }

    void Flip()
    {
        isFacingRight = !isFacingRight; //change control bool
        Vector3 Scaler = transform.localScale; //get scale
        Scaler.x *= -1; //flip it
        transform.localScale = Scaler; //update it
    }

    public void CatchVirus() 
    {
        currentHealth = 0;
        animator.SetBool("isJumping", false);
        animator.SetBool("isDesinfecting", false);
        healthBar.setHealth(currentHealth);
    }

    public void decreaseHealth(int healthValue)
    {
        currentHealth -= healthValue;
        healthBar.setHealth(currentHealth);
    }

    public int getHealth()
    {
        return currentHealth;
    }

    public void setHealth(int healthToSet)
    {
        currentHealth = healthToSet;
        healthBar.setHealth(currentHealth);
    }

    public void OnCollisionStay2D(Collision2D slidingTile) //Change player's parent so player assumes it's transform
    {
        if(slidingTile.gameObject.tag == "MovingTile")
        {
            transform.SetParent(slidingTile.gameObject.transform);
        }
    }

    public void OnCollisionExit2D(Collision2D slidingTile) //Remove player as child of moving tiles
    {
        if (slidingTile.gameObject.tag == "MovingTile")
        {
            transform.SetParent(null);
        }
    }
}
