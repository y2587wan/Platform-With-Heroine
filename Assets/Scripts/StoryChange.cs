using UnityEngine;
using UnityEngine.UI;

public class StoryChange : MonoBehaviour {
    public Sprite[] sprite;
    public int i = 0;
    public void changeSprite()
    {
        Debug.Log(i);
        if (i < sprite.Length)
        {
            GetComponent<Image>().sprite = sprite[i++];
        }

    }
}
