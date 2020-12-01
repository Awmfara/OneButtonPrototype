using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Keeps Music Persistent through scenes
public class AudioManager : MonoBehaviour
{
   
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
