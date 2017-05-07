using System.Collections;

using UnityEngine;

public class StartButton: MonoBehaviour {

    public void changeScene(string Scenename)
    {
        Application.LoadLevel (Scenename);
    } 
       
  }

