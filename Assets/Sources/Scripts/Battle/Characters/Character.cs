using UnityEngine;

public class Character : MonoBehaviour
{
    private IMovement movementBehaviour;
    //private IAttack attackBehaviour;
    private CharacterStats currentStats;
    public void SetMovementBehaviour(IMovement movementBehaviour)
    {
        this.movementBehaviour = movementBehaviour;
    }
    public void SetAttackBehaviour(IMovement movementBehaviour)
    {
        
    }
    public void SetStats(CharacterTemplate template)
    {
        currentStats = new CharacterStats(template);
        Debug.Log(currentStats.Health);
        Debug.Log(currentStats.Speed);
        Debug.Log(currentStats.AttackDistance);
    }


}
