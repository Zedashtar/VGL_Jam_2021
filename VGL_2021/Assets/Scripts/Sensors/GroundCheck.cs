using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    GameController.g.player.isGrounded = true;
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    GameController.g.player.isGrounded = false;
    //}



    public float size;
    public LayerMask groundcheck;

    private void Update()
    {
        Collider2D col = Physics2D.OverlapCircle(transform.position, size, groundcheck);
        if (col != null )
        {
            GameController.g.player.isGrounded = true;
        }
        else GameController.g.player.isGrounded = false;

    }

    private void OnDrawGizmos()
    {
        if (GameController.g != null)
        {
            Gizmos.color = GameController.g.player.isGrounded ? Color.red : Color.green;
        }
        
        Gizmos.DrawWireSphere(transform.position, size);
    }

}
