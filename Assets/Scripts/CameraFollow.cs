using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class CameraFollow : MonoBehaviour {

    public float xMax = 13;
    public float yMax = 13;

    public float xMin = -13;
    public float yMin = -13;
    public Transform target;

	void Start () 
	{
        target = GameObject.Find("Player").transform;
	}
	
	void Update () 
	{
        if (target == null)
        {
            //target = GameObject.Find("General Background").transform;
            StartCoroutine(PlayEndGameAnimation(0));
        }
	}

    void LateUpdate()
    {
        if (target == null)
        {
            //target = GameObject.Find("General Background").transform;
            StartCoroutine(PlayEndGameAnimation(0));
        }else
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
        }
        
    }

    IEnumerator PlayEndGameAnimation(int x)
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + x);
    }
}
