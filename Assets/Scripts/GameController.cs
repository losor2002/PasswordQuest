using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject passwordInput;
    public InputField passwordField;
    public TMP_Text passwordText;
    public GameObject gameOverText;
    public GameObject winText;
    public GameObject welcomeText;
    public TMP_Text goalText;
    public string[] objWithPasswordTags;
    public string[] objWithPasswordTexts;
    public string[] changeGoalTags;
    public string[] changeGoalTexts;

    private Lives _lives;
    private readonly Regex _regex = new(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*\p{P})[A-Za-z\d\p{P}]{8,}$");
    private readonly List<string> _passwords = new();

    private void Start()
    {
        _lives = FindObjectOfType<Lives>();
        Time.timeScale = 0.0f;
    }

    public void ObjectPicked(string objTag)
    {
        int index = Array.IndexOf(objWithPasswordTags, objTag);
        if (index >= 0)
        {
            passwordInput.SetActive(true);
            passwordField.text = "";
            passwordText.text = objWithPasswordTexts[index];
            Time.timeScale = 0.0f;
        }

        int indexGoal = Array.IndexOf(changeGoalTags, objTag);
        if (indexGoal >= 0)
        {
            goalText.text = changeGoalTexts[indexGoal];
        }
    }

    public void CheckPassword()
    {
        bool regexMatch = _regex.IsMatch(passwordField.text);
        bool duplicated = _passwords.Contains(passwordField.text);

        if (!regexMatch)
        {
            passwordText.text = "Sbagliato! La password inserita non è sicura, riprova";
        }
        else if (duplicated)
        {
            passwordText.text = "Sbagliato! La password è già stata usata in precedenza, riprova";
        }
        
        if (regexMatch && !duplicated)
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

    public void StartGame()
    {
        welcomeText.SetActive(false);
        Time.timeScale = 1.0f;
    }
}