using UnityEngine;

public class Enemy : MonoBehaviour {
    public Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


}
