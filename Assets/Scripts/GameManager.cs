using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    int flysSwatted = default;
    public int FlysSwatted { get => flysSwatted; }


    [SerializeField]
    Swatter swatter = default;
    Title title = default;
    BombManager bombManager = default;

    public List<Fly> flies = new List<Fly>();

    [SerializeField]
    public int amountOfFlies = default;




    private void Awake()
    {
        swatter = FindObjectOfType<Swatter>();
        title = FindObjectOfType<Title>();
        bombManager = FindObjectOfType<BombManager>();
        flysSwatted = 0;
        amountOfFlies = 0;
        Cursor.visible = false;

    }
    private void Update()
    {
        SwatterAction();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }
    /// <summary>
    /// Clicking the mouse button or pressing space swats the swatter
    /// Checks list of flies and if an alive fly is underneath the swatter fly is swat
    /// Also checks for a bomb undenereath swatter.
    /// Animates title
    /// And smack souns
    /// </summary>
    private void SwatterAction()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {


            foreach (Fly fly in flies)
            {
                if (Vector3.Distance(swatter.transform.position, fly.transform.position) < 2f)
                {
                    if (fly.flyAlive)
                    {
                        flysSwatted += 1;
                        Debug.Log("Fly Swatted");
                        fly.SelfDestruct();
                    }
                }
            }
            bombManager.BombCheck();
            swatter.SmackSound();
            title.WobbleTitle();
        }
    }
    public void QuitGame()
    {
#if UNITY_EDITOR // if In Unity Editor
        EditorApplication.ExitPlaymode(); //Exits Playmode
#endif
        Application.Quit(); //Quits Application
    }
}
