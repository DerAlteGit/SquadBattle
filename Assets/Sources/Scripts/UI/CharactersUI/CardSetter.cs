using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CardSetter : MonoBehaviour
{
    [SerializeField]private List<Character> characters;
    [SerializeField] private CharacterSet setter;
    [SerializeField]private CharacterCard cardPref;
    [SerializeField] private GameObject cardContainer;

    //public void Init(List<Character> characters)
    //{
    //    foreach (Character character in characters)
    //    {
    //        this.characters.Add(character);
    //    }

    //}

    public void Init()
    {
        foreach (Character item in characters)
        {
            CharacterCard card = Instantiate(cardPref, cardContainer.transform);
            card.Init(item,setter);
        }
    }
}
