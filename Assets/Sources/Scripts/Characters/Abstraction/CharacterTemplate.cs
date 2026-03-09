using UnityEngine;
[CreateAssetMenu(fileName = "New Character Template", menuName = "Character Template", order = 51)]
public class CharacterTemplate : ScriptableObject
{
    [SerializeField]private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int id;

    [SerializeField] private int _health;
    [SerializeField] private int _speed;
    [SerializeField] private int _damage;
    [SerializeField] private int _attackSpeed;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite sprite;
    [SerializeField] private float _attackDistance;


    public string Name { get => _name;}
    public int Damage { get => _damage; }
    public string Description { get => _description;}
    public int Health { get => _health; }
    public int Speed { get => _speed; }
    public int AttackSpeed { get => _attackSpeed; }
    public int Cost { get => _cost; }
    public Sprite Sprite { get => sprite; }
    public int ID {  get => id; } 
    public float AttackDistance {  get => _attackDistance; }
}
