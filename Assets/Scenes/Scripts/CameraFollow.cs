using UnityEngine;
using System.Collections;
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
		
	}
	
    void LateUpdate()
    {
        transform.position = new Vector3(Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), transform.position.z);
    }
}
