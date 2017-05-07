using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
    public float jumpHeight = 30f;
    public float maxSpeed = 5f;
    public Text countText;
    public Text winText;
    private bool hasEnd = false;
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
        count = 0;
        winText.text = "";
        countText.text = "$ " + count.ToString();
    }


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
        animator.SetFloat("walkSpeed", Mathf.Abs(move));
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
            GetComponent<AudioSource>().Play();
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
            Destroy(collision.gameObject);
            count = count + 100;
            countText.text = "$ " + count.ToString();
        }

        if (collision.tag =="goal")
        {
            winText.text = " YOU WIN";
        }

        if (collision.tag == "sword")
        {
            StartCoroutine(PlayEndGameAnimation(1));
        }
    }

    IEnumerator PlayEndGameAnimation(int x)
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + x);
    }

    void KillCharacter()
    {
        if (rb.position.y < -3)
        {
            StartCoroutine(PlayEndGameAnimation(0));
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
