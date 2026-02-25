using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BaseMovement
{
    private float speed;
    private Transform target;
    private Transform character;
    private float deltaDistance = 2f;
    float distanceForRetreat;

    public BaseMovement(Transform character, Transform target, float speed, float deltaDistance,float distanceForRetreat)
    {
        this.character = character;
        this.target = target;
        this.speed = speed;
        this.deltaDistance = deltaDistance;
        this.distanceForRetreat = distanceForRetreat;
    }
    

    public void Move()
    {
        Vector2 direction = (target.position - character.position).normalized;
        if (Vector2.Distance(character.position, target.position) <= deltaDistance)
        {
            if (Vector2.Distance(character.position, target.position) <= distanceForRetreat)
            {
                character.Translate(direction * -speed * Time.deltaTime);
            }
            return;
        }

        character.Translate(direction * speed * Time.deltaTime);
        
            
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
