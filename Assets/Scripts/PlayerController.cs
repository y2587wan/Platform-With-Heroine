using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpHeight = 30f;
    public float maxSpeed = 5f;

    [SerializeField]
    private Transform[] groundPoints;

    public float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGround = false;
    private Rigidbody2D rb;

    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        isGround = IsGround();
 
            float move = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (rb.position.y <= -3)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        if (isGround && Input.GetAxis("Jump") > 0)
        {
            isGround = false;
            rb.AddForce(Vector2.up * jumpHeight);
        }
        isGround = IsGround();
    }

    private bool IsGround()
    {
        if (rb.velocity.y <= 0)
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
}
