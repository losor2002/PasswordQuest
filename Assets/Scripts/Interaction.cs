using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public string requiredObjectTag;
    public GameObject spaceBarText;
    
    private bool _interactable;
    private Inventory _inventory;
    private GameController _gameController;

    private void Start()
    {
        _inventory = FindObjectOfType<Inventory>();
        _gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        if (_interactable && Input.GetKeyDown(KeyCode.Space))
        {
            _inventory.AddObject(tag);
            _gameController.ObjectPicked(tag);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && GameObject.FindWithTag(requiredObjectTag) == null)
        {
            spaceBarText.SetActive(true);
            _interactable = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && GameObject.FindWithTag(requiredObjectTag) == null)
        {
            spaceBarText.SetActive(true);
            _interactable = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            spaceBarText.SetActive(false);
            _interactable = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            spaceBarText.SetActive(false);
            _interactable = false;
        }
    }
}
