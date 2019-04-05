using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unscrew : MonoBehaviour
{
    private bool screwdriver = false;
    public Rigidbody rigidBody;
    public GameManager gameManager;
    private bool screwOut = false;
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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       // Debug.Log(screwdriver);
        if (screwdriver)
        {
            transform.Rotate(Vector3.up * -10);
            transform.localPosition = new Vector3(transform.localPosition.x + 0.005f, transform.localPosition.y, transform.localPosition.z);
        }
        
        if (transform.localPosition.x >= 0.13f && !screwOut)
        {
            
            rigidBody.useGravity = true;
            gameManager.screwsUnscrewed = gameManager.screwsUnscrewed + 1;
            screwOut = true;
        }
    }
}
