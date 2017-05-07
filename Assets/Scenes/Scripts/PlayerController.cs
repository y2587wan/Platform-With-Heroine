using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float jumpHeight = 30f;
    public float maxSpeed = 5f;
    public Text countText;
    public Text winText;

    [SerializeField]
    private Transform[] groundPoints;

    public float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGround = false;
    private Rigidbody2D rb;
    public Animator animator;
    bool faceRight = true;
    private int count;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
<<<<<<< HEAD:Assets/Scenes/Scripts/PlayerController.cs
		count = 0;
		winText.text = "";
		countText.text = "SCORE: " + count.ToString ();
		if (count >= 10)
		{ winText.text = " YOU WIN";
		}
	}
=======
        count = 0;
        winText.text = "";
        countText.text = "$ " + count.ToString();
    }
>>>>>>> origin/master:Assets/Scripts/PlayerController.cs


    void FixedUpdate()
    {

        isGround = IsGround();
        float move = Input.GetAxis("Horizontal");
        if (move > 0 && !faceRight)
        {
            flip();
        } else if (move < 0 && faceRight)
        {
            flip();
        }
        animator.SetFloat("walkSpeed", move);
        animator.SetBool("ground", isGround);
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
        KillCharacter();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            Destroy(enemy.gameObject);
        }

        if (collision.gameObject.CompareTag("coin"))
        {
            collision.gameObject.SetActive(false);
            count = count + 100;
            countText.text = "$ " + count.ToString();
        }

        if (collision.tag =="goal")
        {
            winText.text = " YOU WIN";
        }
    }

    void KillCharacter()
    {
        if (rb.position.y < -3)
        {
            Destroy(rb.gameObject);
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
