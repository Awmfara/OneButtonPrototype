using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    #region Variables
    public GameManager gameManager;
    [SerializeField]
    GameObject bombPrefab;

    float flySpeed = default;
    private float directionChangeTime = default;
    private float timer = default;

    [Range(0, 6)]
    private int dropBomb;
    private bool spent;

    public bool flyAlive;
    private Animator flyAnimator;



    Vector3 destination = default;
    SpriteRenderer spriteRenderer;
    #endregion

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        flyAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        InitialiseVariables();
    }
    /// <summary>
    /// Sets Initial Variables
    /// Adds Fly to List in Game Manager
    /// Creates a random speed,random time to change direction and random point
    /// </summary>
    private void InitialiseVariables()
    {
        gameManager.amountOfFlies += 1;
        gameManager.flies.Add(this);
        directionChangeTime = Random.Range(1, 10);
        flySpeed = Random.Range(0, 20);
        destination = RandomPoint();
        dropBomb = 0;
        spent = false;
        flyAlive = true;

    }

    void Update()
    {
        if (flyAlive)
        {
            FlyMovement();
        }
     

    }
    /// <summary>
    /// Fly Moves to Destination Point at Speed determined at start,  if timer reaches 0
    /// Fly gets new destination and moves towards it
    /// Will face direction of new destination on destination change
    /// </summary>
    private void FlyMovement()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, destination, flySpeed * Time.deltaTime);

        DropBomb();

        if (timer <= 0)
        {
            timer = directionChangeTime;
            destination = RandomPoint();
            dropBomb = Random.Range(0, 3);
            if (destination.x > this.transform.position.x)
            {
                spriteRenderer.flipX = false;
            }
            else
            {
                spriteRenderer.flipX = true;
            }

        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
    /// <summary>
    /// Drops Bomb when fly is still for a period of time
    /// </summary>
    private void DropBomb()
    {
        if (Vector3.Distance(this.transform.position, destination) < 0.01f&& spent == false)
        {
            spent = true;
            Instantiate(bombPrefab, this.transform.position, this.transform.rotation);
            Debug.Log("DropBomb");
        }
    }
    /// <summary>
    /// Changes fly to dead, changes animation and fly no longer moves
    /// </summary>
    public void SelfDestruct()
    {
        if (flyAlive)
        {
            
            flyAlive = false;
            flyAnimator.SetBool("deadFly", true);
        }
 

    }

    /// <summary>
    /// Creates a Random point for Fly to Move to
    /// </summary>
    /// <returns></returns>
    Vector3 RandomPoint()
    {
        int x = Random.Range(-10, 10);
        int y = Random.Range(-10, 10);
        return new Vector3(x, y, 1);
    }
}
