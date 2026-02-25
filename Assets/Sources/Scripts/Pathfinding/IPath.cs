using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPath
{

    public abstract void InitPath(List<Anchor> anchors);
    public abstract Anchor GetNext();
    public abstract Anchor GetPrevious();
    public abstract Anchor GetCurrent();
    public abstract List<Anchor> GetPathAnchors();

}
