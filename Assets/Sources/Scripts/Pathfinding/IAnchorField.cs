using UnityEngine;

public interface IAnchorField
{
    public abstract Anchor GetRandomAnchor();
    public abstract Anchor GetNearestAnchor(Vector2 point);
    public abstract void Instance();
}
