using UnityEngine;

public class Pipes : MonoBehaviour
{
    public static float speed;
    private Rigidbody2D rb;
    void Start()
    {
        speed = 5f;
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = speed * Vector2.left;
    }

    void Update()
    {
        if(transform.position.x <= -15)
        {
            Destroy(gameObject);
        }
    }

    public void Stop()
    {
        rb.linearVelocity = Vector2.zero;
    }

}
