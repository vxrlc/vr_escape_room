using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeCombo : MonoBehaviour
{
    public float RandomNumberStart;
    public float RandomNumberEnd;
    private int[] ComboNumArray = new int[4];
    public int[] GuessNumbersArray = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        // intitalize randomize combination
        for (int i = 0; i <ComboNumArray.Length-1; i++)
        {
            ComboNumArray[i] = ComboRandomNumber();
       
        }
    }

public int ComboRandomNumber()
    {
        return Mathf.RoundToInt(Random.Range(RandomNumberStart, RandomNumberEnd));
    }
public void NumberGuess(int NumberKey)
    {
        for (int i = 0; i < GuessNumbersArray.Length - 1; i++)
        {
            if (GuessNumbersArray[i] == 0)
            { }
            GuessNumbersArray[i] = NumberKey;
            break;
        }
    }
}
