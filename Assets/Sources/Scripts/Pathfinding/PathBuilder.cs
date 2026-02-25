using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PathBuilder<T> where T : IPath, new()
{
    private Anchor end;

    public T FindPath(Anchor start, Anchor end)
    {
        this.end = end;
        List<Anchor> path = new();
        List<Anchor> reachable = new();
        List<Anchor> explored = new();
        Anchor current = null;
        reachable.Add(start);
        while(reachable.Count != 0)
        {
            current = ChouseAnchor(reachable);
            path.Add(current);
            if(current == end)
            {
                return BuildPath(path);
            }
            reachable.Remove(current);
            explored.Add(current);
            foreach(Anchor anchor in current.GetAnchors())
            {
                if(anchor != null)
                {
                    if (!explored.Contains(anchor))
                    {
                        reachable.Add(anchor);
                    }
                }
            }
        }
        return null;
    }
    private T BuildPath(List<Anchor> result)
    {
        T path = new T();
        path.InitPath(result);
        return path;
    }
    private Anchor ChouseAnchor(List<Anchor> reachable)
    {
        float minDistance = float.PositiveInfinity;
        Anchor best = null;
        foreach (var item in reachable)
        {
            if(Vector2.Distance(item.transform.position,end.transform.position) < minDistance)
            {
                minDistance = Vector2.Distance(item.transform.position, end.transform.position);
                best = item;
            }
        }
        return best;
    }
}
