using UnityEngine;

public class CharacterMovement : IMovement
{
    private PathBuilder<BasePath> pathBuilder;
    private IPath currentPath;

    private Anchor current;
    private Transform character;

    private float minDistance = 0.2f;
    private float speed;
    private IAnchorField anchorsField;

    public CharacterMovement(Transform character, float speed, IAnchorField anchorsField)
    {
        pathBuilder = new PathBuilder<BasePath>();
        this.character = character;
        this.speed = speed;
        this.anchorsField = anchorsField;
        current = anchorsField.GetNearestAnchor(character.position); // temp
    }
    public void Move()
    {
        if(Vector2.Distance(character.position, current.transform.position) <= minDistance)
        {
            if (currentPath.GetNext() == current) Debug.Log("End of path");
            else
            {
                current = currentPath.GetCurrent();
            }
        }
        Vector2 direction = (current.transform.position - character.position).normalized;
        character.Translate(direction * speed * Time.deltaTime);

    }

    public void SetTarget(Anchor target)
    {
        currentPath = pathBuilder.FindPath(current, target);
        Debug.Log("Entry");
        
    }
    public Anchor GetCurrentAnchor()
    {
        return current;
    }
    
}
