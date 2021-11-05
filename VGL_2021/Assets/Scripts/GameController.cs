using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController g;

    [Header("Testing")]
    public bool buttonCheck;


    [Space][Header("Manager")]
    public bool started;
    public GameObject level;
    public Player player;
    
    //Input Detection
    public bool isSlide => Input.GetAxisRaw("Vertical") < -0.8f ? true : false;
    public bool isJump => Input.GetButtonDown("Jump");
    public bool isDash => Input.GetButtonDown("Dash");
    bool isCrouching;

    
    [Space][Header("Metrics")]
    public float speed;
    public float jumpForce;
    public float dashForce;
    public float dashDuration;
    float dSpeed = 1f;





    private void Awake()
    {
        g = this;
        player = FindObjectOfType<Player>();
    }


    void Start()
    {
        if (!buttonCheck)
            Invoke("StartLevel", 3f);
    }


    void Update()
    {
        DetectInput();
        UpdateCollider();
        
        
    }

    private void FixedUpdate()
    {
        if (!started)
            return;
        level.transform.Translate(Vector2.left * speed * dSpeed * Time.deltaTime);
    }

    void StartLevel()
    {
        started = true;
    }

    void DetectInput()
    {
        if (isJump && player.isGrounded)
        {
            player.rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (isDash)
        {
            player.rb.velocity = Vector2.zero;
            player.rb.gravityScale = 0f; 
            dSpeed = dashForce;
            Invoke("CancelDash", dashDuration);
        }

        if (isSlide && player.isGrounded)
        {
            isCrouching = true;
        }
        else isCrouching = false;



    }

    void UpdateCollider()
    {
        if (isCrouching)
        {
            player.sr.sprite = player.slideSprite[0];
            player.bc.size = new Vector2(1, 0.7f);
            player.bc.offset = new Vector2(0, -0.15f);
        }
        else
        {
            player.sr.sprite = player.mainSprite[0];
            player.bc.size = new Vector2(1, 1);
            player.bc.offset = new Vector2(0, 0);
        }
    }

    void CancelDash()
    {
        dSpeed = 1f;
        player.rb.gravityScale = 1f;
    }
}
