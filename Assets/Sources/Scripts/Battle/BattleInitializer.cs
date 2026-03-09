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

    [SerializeField]private int navRowCount;
    [SerializeField]private int navColumnCount;
    [SerializeField]private int navStep;
    [SerializeField]private Vector2 leftUpPos;
    [SerializeField] private Anchor anchorPref;

    public void Init()
    {
        characters = FindObjectsByType<Character>(FindObjectsSortMode.None);
        canvas = FindAnyObjectByType<Canvas>();
        InstanceHealthBars(characters);
        InstanceNavigation();
    }
    private void InstanceNavigation()
    {
        IAnchorField anchorField = new PathFindTester(navRowCount,navColumnCount,navStep,leftUpPos,anchorPref);
        anchorField.Instance();
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
