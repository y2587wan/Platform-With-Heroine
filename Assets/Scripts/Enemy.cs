using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody2D rb;
    public float maxSpeed = 10f;
    public Animator animator;
    bool faceRight = true;
    float move;
    public GameObject self;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 move = new Vector2(5f, 0);
        rb.AddForce(move * maxSpeed);
    }
    private void FixedUpdate()
    {
        move = rb.velocity.x; 
        if (move > 0 && !faceRight)
        {
            flip();
        }
        else if (move < 0 && faceRight)
        {
            flip();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
   
        PlayerController player = collision.collider.GetComponent<PlayerController>();
        if (player != null)
        {
            Destroy(player.gameObject);
            rb.velocity = new Vector2(0, 0);
        }
    }


    void flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
