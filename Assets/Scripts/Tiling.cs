/*
*	Copyright (c) Alex
*/

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SpriteRenderer))]

public class Tiling : MonoBehaviour {

    #region Variables
    public int offsetX = 2; // the offset so that we dont get any weird errors

    // these are used for checking if we need to instantiate stuff
    public bool hasARightBuddy = false;
    public bool hasALeftBuddy = false;

    public bool reverseScale = false;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        cam = Camera.main;
        myTransform = transform;
    }
    void Start () 
	{
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x;

	}
	
	void Update () 
	{
		if(hasALeftBuddy == false || hasARightBuddy == false)
        {
            // calculate the cameras extend (half the width) of what the camera can see in world coordinates
            float camHorizontalExend = cam.orthographicSize * Screen.width / Screen.height;

            // calculate 
            float edgeVisiblePostionRight = (myTransform.position.x + spriteWidth / 2) - camHorizontalExend;

            float edgeVisiblePositionLeft = (myTransform.position.x - spriteWidth / 2) + camHorizontalExend;

            //
            if (cam.transform.position.x >= edgeVisiblePostionRight - offsetX && hasARightBuddy == false)
            {
                MakeNewBuddy(1);
                hasARightBuddy = true;
            }
            else if (cam.transform.position.x <= edgeVisiblePositionLeft + offsetX && hasALeftBuddy == false)
            {
                MakeNewBuddy(-1);
                hasALeftBuddy = true;
            }
        }
	}
	
    // a function that creates a buddy on the side required
    void MakeNewBuddy (int rightOrLeft)
    {
        // calculating the new position for our new buddy
        Vector3 newPosition = new Vector3(myTransform.position.x + spriteWidth * rightOrLeft, myTransform.position.y, myTransform.position.z);
        // instantating our new body and storing him in a variable
        Transform newBuddy = Instantiate (myTransform, newPosition, myTransform.rotation) as Transform;

        // if not tilable let's reverse the x size of our object to get rid of seams
        if (reverseScale == true)
        {
            newBuddy.localScale = new Vector3(newBuddy.localScale.x * -1, newBuddy.localScale.y, newBuddy.position.z);
        }

        newBuddy.parent = myTransform.parent;
        if(rightOrLeft > 0)
        {
            newBuddy.GetComponent<Tiling>().hasALeftBuddy = true;
        }
        else
        {
            newBuddy.GetComponent<Tiling>().hasARightBuddy = true;
        }
    }
	#endregion
}
