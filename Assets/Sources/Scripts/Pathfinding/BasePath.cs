using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BasePath : IPath
{
    private List<Anchor> anchors = new();
    private int currentAnchorIndex = -1;
    public override void InitPath(List<Anchor> anchors)
    {
        foreach(Anchor a in anchors)
        {
            this.anchors.Add(a);
        }
        if(anchors.Count > 0)currentAnchorIndex = 0;
    }




    public override Anchor GetCurrent()
    {
        return anchors[currentAnchorIndex];
    }

    public override Anchor GetNext()
    {
        if(currentAnchorIndex + 1 < anchors.Count)
        {
            currentAnchorIndex++;
        }
        return GetCurrent();
    }

    public override Anchor GetPrevious()
    {
        if (currentAnchorIndex > 0)
        {
            currentAnchorIndex--;
        }
        return GetCurrent();
    }

    public override List<Anchor> GetPathAnchors()
    {
        List<Anchor> anchors = new();
        foreach (var item in this.anchors)
        {
            anchors.Add(item);
        }
        return anchors;
    }
}
