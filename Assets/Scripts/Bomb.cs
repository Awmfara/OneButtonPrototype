using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour

{
    BombManager bombManager;
    [SerializeField]
    GameObject boomPrefab;
    [SerializeField]
    GameObject killScreen;

    bool exploded = false;
    private void Awake()
    {
        bombManager = FindObjectOfType<BombManager>();
    }
    void Start()
    {
        //Initialises settings for Bomb, sets parent as bomb manager and adds to bomb manager list
        exploded = false;
        this.transform.SetParent(bombManager.transform);
        bombManager.bombs.Add(this);
    }

}
