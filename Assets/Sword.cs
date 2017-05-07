using UnityEngine;

public class Sword : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GetComponent<AudioSource>().Play();
            Enemy enemy = collision.GetComponentInParent<Enemy>();
            Destroy(enemy.gameObject);
        }
    }

}
