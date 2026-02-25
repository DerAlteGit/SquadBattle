using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    [SerializeField] private string _name;

    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _attackSpeed;

    public void Init(Character character)
    {
        _name = character.Name;
        _health = character.Health;
        _speed = character.Speed;
        _damage = character.Damage;
        _attackSpeed = character.AttackSpeed;
    }

}
