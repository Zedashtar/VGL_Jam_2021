using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofCheck_Component : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameController.g.isCrouching)
            GameController.g.player.isRoofed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (GameController.g.isCrouching)
        {
            GameController.g.player.isRoofed = false;
        }

    }
}
