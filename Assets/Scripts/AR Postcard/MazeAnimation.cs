using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeAnimation : MonoBehaviour
{

    public Animator mazeAnimation;
    // Start is called before the first frame update
    void Start()
    {
        mazeAnimation.enabled = false;
    }
}
