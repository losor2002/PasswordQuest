using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBank : MonoBehaviour
{
    public GameObject bank;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stone cube"))
        {
            Destroy(other.gameObject);
            bank.SetActive(true);
        }
    }
}
