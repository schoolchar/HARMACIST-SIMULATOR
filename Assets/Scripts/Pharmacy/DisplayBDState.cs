using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayBDState : MonoBehaviour
{
    [SerializeField] private Sprite[] stateSprites;
    [SerializeField] private Image belladonnaStress;
    CharacterStates characterStates;


    private void Start()
    {
        characterStates = FindAnyObjectByType<CharacterStates>();

        DisplayStressSprite();
    }

    /// <summary>
    /// Choose which sprite to show for Belladonna in pharmacy based on stress
    /// </summary>
    public void DisplayStressSprite()
    {
        //Use stress level to pick sprite to show
        try
        {
            belladonnaStress.sprite = stateSprites[characterStates.stressLevel];
        }
        catch
        {
            belladonnaStress.sprite = stateSprites[stateSprites.Length - 1];
        }
      
        

    } //END DisplayStressSprites()


}
