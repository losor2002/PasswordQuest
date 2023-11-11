using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Image key;
    public Image smartphone;
    public Image email;
    public Image bank;

    public void AddObject(string objTag)
    {
        switch (objTag)
        {
            case "key":
                key.color = Color.white;
                break;
            case "smartphone":
                smartphone.color = Color.white;
                break;
            case "email":
                email.color = Color.white;
                break;
            case "bank":
                bank.color = Color.white;
                break;
        }
    }
}
