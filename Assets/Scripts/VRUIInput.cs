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

   
    private void OnEnable()
    {
        laserPointer = GetComponent<SteamVR_LaserPointer>();
        laserPointer.PointerIn -= HandlePointerIn;
        laserPointer.PointerIn += HandlePointerIn;
        laserPointer.PointerOut -= HandlePointerOut;
        laserPointer.PointerOut += HandlePointerOut;
       laserPointer.PointerClick -= HandlePointerClick;
       laserPointer.PointerClick += HandlePointerClick;

        //trackedController = GetComponent<SteamVR_TrackedController>();
       // if (trackedController == null)
       // {
        //    trackedController = GetComponentInParent<SteamVR_TrackedController>();
       // }
       //trackedController.TriggerClicked -= HandleTriggerClicked;
       // trackedController.TriggerClicked += HandleTriggerClicked;
    }

    // private void HandleTriggerClicked(object sender, ClickedEventArgs e)
    // {
    //if (EventSystem.current.currentSelectedGameObject != null)
    // {
    //      ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, new PointerEventData(EventSystem.current), ExecuteEvents.submitHandler);
    // }
    // }
    private void Update()
    {
        if (PointerActivate.GetState(handType))
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