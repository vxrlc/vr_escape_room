using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lockmanager : MonoBehaviour
{
    public Animator lockOpen;
    public GameObject key;
    public BoxCollider trigger;
    // Start is called before the first frame update
    void Start()
    {
        lockOpen.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.tag == other.tag)
        {
            other.gameObject.SetActive(false);
            key.SetActive(true);
            trigger.enabled = false;
        }
    }
   public void Unlock()
    {
        lockOpen.enabled = true;
        Invoke("HideLock", 1f);
    }
    void HideLock()
    {
        this.gameObject.SetActive(false);
    }
}
