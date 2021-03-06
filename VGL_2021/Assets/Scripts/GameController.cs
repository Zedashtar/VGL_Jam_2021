using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public static GameController g;

    [Header("Testing")]
    public bool buttonCheck;


    [Space][Header("Manager")]
    public bool running;
    public GameObject level;
    public Player player;
    AudioSource bgm;
    
    //Input Detection
    public bool isSlide => Input.GetAxisRaw("Vertical") < -0.8f ? true : false;
    public bool isJump => Input.GetButtonDown("Jump");
    public bool isDash => Input.GetButtonDown("Dash");
    public bool isCrouching;
    bool isDashing;
    float dashStartTime;
    float dashTime;

    
    [Space][Header("Metrics")]
    public float speed;
    public float jumpForce;
    public float dashForce;
    public AnimationCurve dashCurve;
    public float dashDuration;







    private void Awake()
    {
        g = this;
        player = FindObjectOfType<Player>();
        bgm = GetComponent<AudioSource>();
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

        if (isDashing)
        {
            dashTime = (Time.time - dashStartTime)/dashDuration;
        }
        
        
    }

    private void FixedUpdate()
    {
        if (!running)
        {
            if (isDashing && buttonCheck)
                level.transform.Translate(Vector2.left * (speed + dashForce * (isDashing ? dashCurve.Evaluate(dashTime) : 0)) * Time.deltaTime);
            else return;
        }
            
            
        else level.transform.Translate(Vector2.left * (speed + dashForce * (isDashing ? dashCurve.Evaluate(dashTime) : 0 )) * Time.deltaTime);

    }

    void StartLevel()
    {
        running = true;
        bgm.Play();
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
            if (!isDashing)
            {
                dashStartTime = Time.time;
                isDashing = true;
                player.destroyCheck.enabled = true;
            }
            
            Invoke("CancelDash", dashDuration);
            
        }

        if ((isSlide || player.isRoofed) && player.isGrounded)
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
            player.boxCol.size = new Vector2(1, 0.7f);
            player.boxCol.offset = new Vector2(0, -0.15f);
            player.crashCheck.size = new Vector2(0.85f, 0.5f);
            player.crashCheck.offset = new Vector2(0, -0.15f);
            player.roofCheck.offset = new Vector2(0, -0.3f);

        }
        else
        {
            player.sr.sprite = player.mainSprite[0];
            player.boxCol.size = new Vector2(1, 1);
            player.boxCol.offset = new Vector2(0, 0);
            player.crashCheck.size = new Vector2(0.85f, 0.8f);
            player.crashCheck.offset = new Vector2(0, 0);
            player.roofCheck.offset = new Vector2(0, 0);

        }
    }

    void CancelDash()
    {
        player.rb.gravityScale = 2f;
        isDashing = false;
        dashTime = 0f;
        player.destroyCheck.enabled = true;
    }

    public void GameOver()
    {
        running = false;
        Debug.Log("Game Over");
    }
}
