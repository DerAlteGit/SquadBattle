using UnityEngine;

public class CharacterStats
{

    [SerializeField] private string _name;

    [SerializeField] public float Health { get; private set; }
    [SerializeField] public float Speed { get; private set; }
    [SerializeField] public float Damage { get; private set; }
    [SerializeField] public float AttackSpeed { get; private set; }
    [SerializeField] public float AttackDistance { get; private set; }

    public CharacterStats(CharacterTemplate character)
    {
        _name = character.Name;
        Health = character.Health;
        Speed = character.Speed;
        Damage = character.Damage;
        AttackSpeed = character.AttackSpeed;
        AttackDistance = character.AttackDistance;
    }

}
