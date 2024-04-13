using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDialog : MonoBehaviour
{
    public GameObject enterDialog;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            
          enterDialog.SetActive(true);
        }
    }
}
