using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
/// <summary>
/// Starts New game or Quit Game Options
/// </summary>
public class MainMenu : MonoBehaviour
{
    private string LoadScene = "GameScene";
    public void StartGame()
    {
        SceneManager.LoadScene(LoadScene);
    }
    /// <summary>
    /// Quits Application. If in Unity Editor, exits PlayMode
    /// </summary>
    public void QuitGame()
    {
#if UNITY_EDITOR // if In Unity Editor
        EditorApplication.ExitPlaymode(); //Exits Playmode
#endif
        Application.Quit(); //Quits Application
    }
}
