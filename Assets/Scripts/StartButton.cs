using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartButton: MonoBehaviour {
    public void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  }

