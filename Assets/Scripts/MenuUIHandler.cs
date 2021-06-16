using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] GameObject nameInputOverlay;
    [SerializeField] InputField nameInput;

    private bool isWaitingForName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isWaitingForName && !string.IsNullOrEmpty(nameInput.text))
        {
            ScoreManager.Instance.PlayerName = nameInput.text;
            SceneManager.LoadScene(1);
        }
    }

    public void StartGame()
    {
        isWaitingForName = true;
        nameInputOverlay.SetActive(true);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
