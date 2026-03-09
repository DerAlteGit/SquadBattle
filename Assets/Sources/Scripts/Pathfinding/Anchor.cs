using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    //[SerializeField]private bool isObstacle;


    [SerializeField]private  Anchor leftAnchor;
    [SerializeField] private Anchor rightAnchor;
    [SerializeField] private Anchor upAnchor;
    [SerializeField] private Anchor downAnchor;

    public Anchor Left {  get { return leftAnchor; } }
    public Anchor Right { get { return rightAnchor;} }
    public Anchor Up { get { return upAnchor; } }
    public Anchor Down { get { return downAnchor; } }
    public bool IsObstacle;

    public void ConnectAnchor(Anchor left, Anchor right, Anchor up, Anchor down)
    {
        this.leftAnchor = left;
        this.rightAnchor = right;
        this.upAnchor = up;
        this.downAnchor = down;
        CheckConnection();
    }
    private void CheckConnection()
    {
        foreach(var item in GetAnchors())
        {
            if(item != null)
            {
                if (item.IsObstacle)
                {
                    Disconnect(item);
                }
            }
        }
    }
    private void Disconnect(Anchor anchor)
    {
        if (leftAnchor == anchor) leftAnchor = null;
        if (rightAnchor == anchor) rightAnchor = null;
        if (upAnchor == anchor) upAnchor = null;
        if(downAnchor == anchor) downAnchor = null;
   
    }
   
    public List<Anchor> GetAnchors()
    {
        return new List<Anchor>() {Left,Right,Up,Down };
    }

    
}
