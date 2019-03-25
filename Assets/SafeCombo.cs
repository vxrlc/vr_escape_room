using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCombo : MonoBehaviour
{
    public float RandomNumberStart;
    public float RandomNumberEnd;
    private int[] ComboNumArray = new int[4];
    public int[] GuessNumbersArray = new int[4];
    private bool Match = false;
    public MeshCollider handle;

    // Start is called before the first frame update
    void Start()
    {
        // intitalize randomize combination
        for (int i = 0; i <ComboNumArray.Length; i++)
        {
            ComboNumArray[i] = ComboRandomNumber();
            Debug.Log(ComboNumArray[i]);
        }
    }

public int ComboRandomNumber()
    {
        return Mathf.RoundToInt(Random.Range(RandomNumberStart, RandomNumberEnd));
    }
public void ClearGuess()
    {
        for (int i = 0; i < GuessNumbersArray.Length; i++)
        {
            GuessNumbersArray[i] = 0;
            Debug.Log(GuessNumbersArray[i]);
        }
    }
    public void SubmitGuess()
    {
        for (int i = 0; i < ComboNumArray.Length; i++)
        {
            if (ComboNumArray[i] == GuessNumbersArray[i])
            {
                Match = true;
            } else
            {
                Match = false;
                ClearGuess();
                break;
            }
            
        }
        if (Match)
        {
            handle.enabled = true;
        }
    }
public void NumberGuess(int NumberKey)
    {
        for (int i = 0; i < GuessNumbersArray.Length; i++)
        {
            if (GuessNumbersArray[i] == 0)
            {
                GuessNumbersArray[i] = NumberKey;
               Debug.Log("Combo: " + ComboNumArray[i] + "Guess: " + GuessNumbersArray[i]);
                break;
            }
        }
    }
}
