using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject[] lives;

    private int _i;

    public bool RemoveLife()
    {
        if (_i >= lives.Length)
        {
            return false;
        }
        
        lives[_i++].SetActive(false);
        return _i != lives.Length;
    }
}
