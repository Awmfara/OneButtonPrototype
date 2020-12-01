using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swatter : MonoBehaviour
{
    GameManager gameManager;
    Fly targetedFly;
    [SerializeField]
    float startTimer = default;

    [Header("Audio")]
    [SerializeField]
    AudioClip smackClip = default;
    [SerializeField]
    AudioSource smackSource = default;

    public Animator swatterAnimator = default;



    /// <summary>
    /// Initialises variables
    /// </summary>
    private void Start()
    {
        swatterAnimator = GetComponent<Animator>();
        startTimer = 0;
    }
    /// <summary>
    /// Aligns swatter to mouse movements after intitial delay
    /// </summary>
    private void Update()
    {
        startTimer -= Time.deltaTime;
        if (startTimer <= 0)
        {
            Vector2 mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = mousePosition;
        }
    }
    /// <summary>
    /// Plays swat sound and triggers swat animation
    /// </summary>
    public void SmackSound()
    {
        swatterAnimator.SetTrigger("Swat");
        smackSource.Play();
    }

}
