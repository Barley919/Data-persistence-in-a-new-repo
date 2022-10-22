using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameInputText;
    [SerializeField] TextMeshProUGUI topScoreText;
    string username;

    private void Start()
    {
        if(SaveManager.Instance.bestScore > 0)
        {
            topScoreText.text = "Top Score: " + SaveManager.Instance.bestScore;
        }
    }

    public void NameInput()
    {
        username = nameInputText.text;
        SaveManager.Instance.username = username;
        Debug.Log(username);
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveManager.Instance.SaveInfo();

# if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
