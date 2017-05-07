using UnityEngine;

public class Information : MonoBehaviour {



    public GameObject Page;

    public Transform curPage;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(Page, curPage.position, Quaternion.identity);
    }
}
