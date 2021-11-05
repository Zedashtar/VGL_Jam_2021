using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Sprite[] mainSprite;
    public Sprite[] jumpSprite;
    public Sprite[] dashSprite;
    public Sprite[] slideSprite;

    public SpriteRenderer sr;
    public BoxCollider2D bc;

    public bool isGrounded;


    [HideInInspector]
    public Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        bc = GetComponent<BoxCollider2D>();
    }

    //private void Update()
    //{
    //    if (GameController.g.isJump && isGrounded)
    //    {
    //        rb.AddForce(Vector2.up * GameController.g.jumpForce, ForceMode2D.Impulse);
    //    }
    //}




}
