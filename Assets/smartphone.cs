using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class smartphone : MonoBehaviour
{
    public Camera smartphoneCamera;
    public GameObject screen;
    private Interactable interactable;
    public GameObject key;
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
            screen.SetActive(true);
            RaycastHit hit;
            Ray ray = smartphoneCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            if (Physics.Raycast(ray, out hit))
            {
               
                if (hit.collider.name == "AR Book")
                {
                    key.SetActive(true);
                }
                
            }
        } else
        {
            screen.SetActive(false);
        }
        
    }
}
