using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillScreen : MonoBehaviour
{
    [SerializeField]
    float timer = default;
    private string LoadScene = "TitleScreen";
    [SerializeField]
    GameObject spawnPoints;
    private void Start()
    {
        //Deactivates spawn points and hence flies
        //Reactiaves cursor
        //starts countdown
        spawnPoints.SetActive(false);
        Cursor.visible = true;
        timer = 5;
    }
    private void Update()
    {
        //returns to title screen after countdown
        if (timer <= 0)
        {
            SceneManager.LoadScene(LoadScene);
        }
        else
        {
            timer -= Time.deltaTime;
        }

    }
}
