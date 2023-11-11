using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject passwordInput;
    public TMP_InputField passwordField;
    public GameObject gameOverText;
    public GameObject winText;
    public string[] objWithPasswordTags;

    private Lives _lives;
    private readonly Regex _regex = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\p{P})[A-Za-z\d\p{P}]{8,}$");
    private readonly List<string> _passwords = new();

    private void Start()
    {
        _lives = FindObjectOfType<Lives>();
    }

    public void ObjectPicked(string objTag)
    {
        if (objWithPasswordTags.Contains(objTag))
        {
            passwordInput.SetActive(true);
            passwordField.text = "";
            Time.timeScale = 0.0f;
        }
    }

    public void CheckPassword()
    {
        if (_regex.IsMatch(passwordField.text) && !_passwords.Contains(passwordField.text))
        {
            passwordInput.SetActive(false);
            _passwords.Add(passwordField.text);
            
            if (_passwords.Count >= objWithPasswordTags.Length)
            {
                winText.SetActive(true);
                return;
            }

            Time.timeScale = 1.0f;
        }
        else if (!_lives.RemoveLife())
        {
            passwordInput.SetActive(false);
            gameOverText.SetActive(true);
        }
        else
        {
            passwordField.text = "";
        }
    }

    public void Restart()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Cainos/Pixel Art Top Down - Basic/Scene/SC Pixel Art Top Down - Basic");
    }
}