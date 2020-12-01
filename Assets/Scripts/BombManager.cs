using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    GameManager game;
    Swatter swatter;
    public List<Bomb> bombs = new List<Bomb>();

    [SerializeField]
    GameObject killScreen;

    [SerializeField]
    AudioSource bombSource;
   

    private void Start()
    {
        swatter = FindObjectOfType<Swatter>();
    }
    //Checks all bomb in list and sees how close swatter is to it,  if close enough sets kill screen and plays bomb sound
    public void BombCheck()
    {
        foreach (Bomb bomb in bombs)
        {
            if (Vector3.Distance(swatter.transform.position, bomb.transform.position) < 2f)
            {
               
                killScreen.SetActive(true);
                bombSource.Play();
            }
        }
    }
}
