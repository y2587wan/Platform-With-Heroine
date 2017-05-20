using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    public void changeScene()
    {
        SceneManager.LoadScene(1);
    }
}
