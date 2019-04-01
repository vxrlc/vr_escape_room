using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayCombo : MonoBehaviour
{
    public GameObject safe;
    public Text comboText;


    private SafeCombo ComboScript;


    // Start is called before the first frame update
    void Start()
    {
        ComboScript = safe.GetComponent<SafeCombo>();
        Debug.Log("Combo: " + ComboScript.Combo);
        comboText.text = ComboScript.Combo;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
