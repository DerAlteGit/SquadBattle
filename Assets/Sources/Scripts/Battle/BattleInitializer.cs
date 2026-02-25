using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BattleInitializer : MonoBehaviour
{
    [SerializeField] private CharacterHealthBar healthBarPrefab;
    private Character[] characters;
    private Canvas canvas;
    [SerializeField] private Vector2 healthBarOffset;
    

    public void Init()
    {
        characters = FindObjectsByType<Character>(FindObjectsSortMode.None);
        canvas = FindAnyObjectByType<Canvas>();
        InstanceHealthBars(characters);
    }
    private void InstanceHealthBars(Character[] characters)
    {
        if (characters != null)
        {
            foreach (Character character in characters)
            {
                CharacterHealthBar healthbar = Instantiate(healthBarPrefab, canvas.transform);
                healthbar.InitHealthBar(character.gameObject);
            }
        }
    }
}
