using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playVideo : MonoBehaviour
{
    public GameObject videoScreen;
    public Transform endPos;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y == endPos.transform.position.y)
            videoScreen.SetActive(true);

    }
}
