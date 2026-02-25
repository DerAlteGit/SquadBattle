using UnityEngine;

public class BaseCharacterAI : MonoBehaviour
{
    private IMovement movement;
    [SerializeField] private Transform target;
    [SerializeField] private float speed;
    [SerializeField] private float deltaDistance;
    [SerializeField] private float distanceForRetreat;
    PathFindTester anchorsField;
    public void Init()
    {
        //movement = new CharacterMovement(transform,speed);
        
    }
    private void Start()
    {
        Init();
    }
    private void Update()
    {
        //smovement.Move();
    }
}
