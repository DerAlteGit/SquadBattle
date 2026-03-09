using UnityEngine;

public class CharacterCreator
{
    private Character characterPrefab;
    public CharacterCreator(Character characterPrefab)
    {
        this.characterPrefab = characterPrefab;
    }
    public Character CreateCharacter(CharacterTemplate template, Vector2 position)
    {
        Character character = GameObject.Instantiate(characterPrefab, position, Quaternion.identity);
        character.SetStats(template);
        character.GetComponent<SpriteRenderer>().sprite = template.Sprite;
        return character;
    }

}
