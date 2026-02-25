using UnityEngine;

public interface IMovement
{
    
    //public abstract void Init(Transform character, Transform target, float speed);
    public abstract void Move();
    public abstract void SetTarget(Anchor target);
    public abstract Anchor GetCurrentAnchor();

}
