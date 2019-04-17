using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SafeCombo : MonoBehaviour
{
    public float RandomNumberStart;
    public float RandomNumberEnd;
    private int[] ComboNumArray = new int[4];
    public int[] GuessNumbersArray = new int[4];
    private bool Match = false;
    public Text GuessNumberDisplay;
    public MeshCollider handle;
    public string Combo;
    public AudioSource errorSound;
    public AudioSource unlockSound;

    // Start is called before the first frame update
    void Awake()
    {
        // intitalize randomize combination
        for (int i = 0; i <ComboNumArray.Length; i++)
        {
            ComboNumArray[i] = ComboRandomNumber();
            Combo += ComboNumArray[i].ToString();
            Debug.Log(ComboNumArray[i]);
        }
        
    }

public int ComboRandomNumber()
    {
        return Mathf.RoundToInt(Random.Range(RandomNumberStart, RandomNumberEnd));
    }
    // function to clear the guesses
    public void ClearGuess()
    {
        GuessNumberDisplay.text = "";
        for (int i = 0; i < GuessNumbersArray.Length; i++)
        {
            GuessNumbersArray[i] = 0;
            //Debug.Log(GuessNumbersArray[i]);
        }
    }
    // function to submit the combo guess
    public void SubmitGuess()
    {
        for (int i = 0; i < ComboNumArray.Length; i++)
        {
            // determine if each index of the guessed array matches the combo arary
            if (ComboNumArray[i] == GuessNumbersArray[i])
            {
                Match = true;
            } else
            {
                errorSound.Play();
                // if no match, clear the guess and stop the for loop
                Match = false;
                ClearGuess();
                break;
            }
            
        }
        // if all numbers match, enable the safe handle
        if (Match)
        {
            unlockSound.Play();
            handle.enabled = true;
        }
    }
    // function that is called to store guessed numbers
    public void NumberGuess(int NumberKey)
    {
        for (int i = 0; i < GuessNumbersArray.Length; i++)
        {
            if (GuessNumbersArray[i] == 0)
            {
                GuessNumbersArray[i] = NumberKey;
                GuessNumberDisplay.text += GuessNumbersArray[i] + " ";
              // Debug.Log("Combo: " + ComboNumArray[i] + "Guess: " + GuessNumbersArray[i]);
                break;
            }
        }
    }
}
