using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCard : MonoBehaviour
{
    [SerializeField] private CharacterSet charSet; // Для передачи текущего персонажа в сеттер при нажатии

    [SerializeField] private CharacterTemplate character;
    [SerializeField] private Image characterSprite;
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text maxHealth;
    [SerializeField] private TMP_Text damage;
    [SerializeField] private TMP_Text speed;

    public void Init(CharacterTemplate character, CharacterSet setter)
    {
        this.character = character;
        characterSprite.sprite = character.Sprite;
        characterName.text = character.Name;
        maxHealth.text = character.Health.ToString();
        damage.text = character.Damage.ToString();
        speed.text = character.Speed.ToString();

        charSet = setter;
        
    }

    public void OnCardClick()
    {
        charSet.SetCharacter(character);
    }
    
}
