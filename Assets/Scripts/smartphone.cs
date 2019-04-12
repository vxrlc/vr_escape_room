using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class smartphone : MonoBehaviour
{
    public Camera smartphoneCamera;
    public GameObject cameraScreen;
    public GameObject lockScreen;
    private Interactable interactable;
    public GameObject key;
    public GameObject ARMaze;
    public Collider MazeCollider;
    private Interactable ARInteractable;
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }
  
    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand)
        {
           
            cameraScreen.SetActive(true);
            lockScreen.SetActive(true);
            RaycastHit hit;
            Ray ray = smartphoneCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.collider.name);
                if (hit.collider.name == "AR Book")
                {
                    key.SetActive(true);
                } else if (hit.collider.name == "AR Postcard")
                {
                    ARInteractable = hit.collider.transform.parent.GetComponent<Interactable>();
                    if (ARInteractable.attachedToHand)
                    {
                        ARMaze.SetActive(true);
                        //MazeCollider.enabled = false;
                    }
                }
                
            }
        } else
        {
            cameraScreen.SetActive(false);
            lockScreen.SetActive(true);
            ARMaze.SetActive(false);
            MazeCollider.enabled = true;
        }
        
    }
}
