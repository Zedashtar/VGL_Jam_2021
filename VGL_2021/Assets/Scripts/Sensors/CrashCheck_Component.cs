using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCheck_Component : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameController.g.GameOver();
    }
}
