using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unscrew : MonoBehaviour
{
    private bool screwdriver = false;
    public Rigidbody rigidBody;
    public Collider collider;
    public GameManager gameManager;
    private bool screwOut = false;

    //this is the sound stuff
    public AudioClip clip;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
 
        if (other.transform.name == "drillBit")
        {
            screwdriver = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        screwdriver = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log(screwdriver);
        if (screwdriver)
        {

            transform.Rotate(0, gameManager.drillRotation * -1, 0, Space.Self);     
           transform.localPosition = new Vector3(transform.localPosition.x + (0.05f  * (gameManager.drillTriggerSqueeze/5)), transform.localPosition.y, transform.localPosition.z);
        }
        
        if (transform.localPosition.x >= 0.13f && !screwOut)
        {
            
            rigidBody.useGravity = true;
            collider.enabled = true;
            gameManager.screwsUnscrewed = gameManager.screwsUnscrewed + 1;
            screwOut = true;

            //plays the sound if the screw is out
            audioSource.PlayOneShot(clip, 0.5f);
        }
    }
}
