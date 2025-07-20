using UnityEngine;
using DG.Tweening;
public class Bird : MonoBehaviour
{
    public float fallSpeed, flySpeed;
    private Rigidbody2D rb;
    private float birdAngle;
    private bool isFlying;
    private bool isStarted;

    public GameDirector gameDirector;

    public Animator animator;

    private void Awake()
    {
        if(gameDirector == null)
        {
            gameDirector = FindAnyObjectByType<GameDirector>();
        }   
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        fallSpeed = -14f;
        RestartBird();
        StartAnimation();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponentInChildren<Collider2D>().CompareTag("Pipe"))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name == "PointWall")
        {
            gameDirector.menuManager.AddScore();
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!isStarted && (isFlying && Input.GetKeyDown(KeyCode.Mouse0)))
        {
            DisableAnimation();
            isStarted = true;
            FlyBird();
        }

        else if (isStarted)
        {
            rb.linearVelocity = Vector2.up * flySpeed;

            if (isStarted && (flySpeed >= fallSpeed))
                flySpeed -= 0.9f;

            if (flySpeed <= fallSpeed && birdAngle >= -90)
            {
                birdAngle -= 6;
                transform.eulerAngles = new Vector3(0, 0, birdAngle);
            }
            if (isFlying && (Input.GetKeyDown(KeyCode.Mouse0)))
            {
                FlyBird();
            }
        }

        if (transform.position.y < -10)
        {
            if (isFlying) GameOver();

            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        if (transform.position.y >= 7)
            transform.position = new Vector2(-2, 7);

    }

    private void FlyBird()
    {
        flySpeed = -fallSpeed + 1;
        //transform.Rotate(0,0,45);
        birdAngle = 20;
        transform.eulerAngles = new Vector3(0, 0, birdAngle);
    }

    public void DisableBird()
    {
        Debug.Log("Game Over");
        GetComponent<CapsuleCollider2D>().enabled = false;
        rb.linearVelocity = Vector2.up * fallSpeed;
        isFlying = false;
        animator.enabled = false;
        isStarted = false;
        //enabled = false;
    }

    public void GameOver()
    {
        DisableBird();
        gameDirector.GameOver();
    }

    public void RestartBird(){
        flySpeed = -fallSpeed + 1;
        isFlying = true;
        GetComponent<CapsuleCollider2D>().enabled = true;
        gameObject.transform.position = new Vector2(-2, 0);
        transform.eulerAngles = new Vector3(0, 0, 0);
        animator.enabled = true;
        //animator.speed = 0.8f;

        //rb.linearVelocity = Vector2.up * fallSpeed; // flyspeed?
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        StartAnimation();
    }

    private void StartAnimation()
    {
        transform.DOMoveY(transform.position.y + .5f, 0.4f)
            .SetLoops(-1, LoopType.Yoyo)
            .SetEase(Ease.InOutQuad);
    }

    private void DisableAnimation()
    {
        transform.DOKill();
    }
}
