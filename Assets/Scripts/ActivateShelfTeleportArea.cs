using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShelfTeleportArea : MonoBehaviour
{
    public GameObject teleportArea;

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Shelf")
        {
            teleportArea.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
