using System.Collections;

using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public void changeScene(string Scenename)
    {
        Application.LoadLevel (Scenename);
    } 
       
    }

