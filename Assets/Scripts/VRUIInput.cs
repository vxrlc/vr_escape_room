using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Valve.VR.Extras;
using Valve.VR;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class VRUIInput : MonoBehaviour
{
    private SteamVR_LaserPointer laserPointer;
    public SteamVR_Input_Sources handType;
    public SteamVR_Action_Boolean PointerActivate;
    public GameManager gameManager;


    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerOut += HandlePointerOut;
        laserPointer.PointerClick -= HandlePointerClick;
        laserPointer.PointerClick += HandlePointerClick;

    }
    private void Update()
    {
        if (PointerActivate.GetState(handType) && !gameManager.isHolding)
        {
            laserPointer.holder.SetActive(true);
        }
        else
        {
            laserPointer.holder.SetActive(false);
        }
    }
    private void HandlePointerClick(object sender, PointerEventArgs e)
    {
       
        Debug.Log("HandlePointerIn" + e.target.gameObject.name);
        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.Invoke();
        }
        

    }
    private void HandlePointerIn(object sender, PointerEventArgs e)
    {
        //Debug.Log("HandlePointerIn" + e.target.gameObject.name);
        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            button.OnSelect(null);
        }
    }

    private void HandlePointerOut(object sender, PointerEventArgs e)
    {

        var button = e.target.GetComponent<Button>();
        if (button != null)
        {
            button.OnDeselect(null);
           // Debug.Log("HandlePointerOut", e.target.gameObject);
        }
    }
}