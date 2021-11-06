using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Space]
    [Header("Sprites")]
    public Sprite[] mainSprite;
    public Sprite[] jumpSprite;
    public Sprite[] dashSprite;
    public Sprite[] slideSprite;

    [Space]
    [Header("Component")]
    [HideInInspector] public SpriteRenderer sr;
    [HideInInspector] public BoxCollider2D boxCol;
    [HideInInspector] public Rigidbody2D rb;

    public BoxCollider2D crashCheck;
    public BoxCollider2D roofCheck;
    public BoxCollider2D destroyCheck;


    [Space]
    [Header("Other")]
    public bool isGrounded;
    public bool isRoofed;


    


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();
        
    }





}
