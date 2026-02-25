using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindTester : IAnchorField
{
    private int rowCount;
    private int columnCount;
    private Vector2 leftUp;
    private float step;
    private Anchor anchorPref;
    private Anchor[,] anchors;
    private PathBuilder<BasePath> builder;
    public PathFindTester()
    {
        
    }
    public void Instance()
    {
        anchors = new Anchor[rowCount, columnCount];
        for(int i = 0; i < rowCount; i++)
        {
            for(int j = 0; j < columnCount; j++)
            {
                Anchor anchor = GameObject.Instantiate(anchorPref, new Vector2(leftUp.x + j*step, leftUp.y - (i * step)),Quaternion.identity);
                anchors[i,j] = anchor;
                
            }
        }
        SetConnection();
        
    }
    private void SetConnection()
    {
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount - 1; j++)
            {
                anchors[i, j].ConnectAnchor(anchors[i, j].Left, anchors[i, j + 1], anchors[i, j].Up, anchors[i, j].Down);
                anchors[i, j + 1].ConnectAnchor(anchors[i, j], anchors[i, j + 1].Right, anchors[i, j + 1].Up, anchors[i, j + 1].Down);

            }
        }
        for (int i = 0; i < rowCount - 1; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                anchors[i, j].ConnectAnchor(anchors[i, j].Left, anchors[i, j].Right, anchors[i, j].Up, anchors[i+1, j]);
                anchors[i+1, j].ConnectAnchor(anchors[i+1, j].Left, anchors[i+1, j].Right, anchors[i, j], anchors[i+1, j].Down);
            }
        }
    }
    public Anchor GetRandomAnchor()
    {
        int row = Random.Range(0,anchors.GetLength(0));
        int column = Random.Range(0, anchors.GetLength(1));
        return anchors[row, column];
        
    }
    public Anchor GetNearestAnchor(Vector2 point)
    {
        Vector2 leftUpPos = leftUp;

        int stepsX = (int)((point.x - leftUpPos.x) / step); // the top left anchor of all possible
        int stepsY = (int)((leftUpPos.y - point.y) / step);
        stepsX = Mathf.Clamp(stepsX, 0, anchors.GetLength(1)-1);
        stepsY = Mathf.Clamp(stepsY, 0, anchors.GetLength(0) - 1);

        List<Anchor> anchorList = new();
        //Проверка сущестсования элементов
        if(anchors.GetLength(0) > stepsY && anchors.GetLength(1) > stepsX) 
            anchorList.Add(anchors[stepsY, stepsX]); 
        if (anchors.GetLength(0) > stepsY+1 && anchors.GetLength(1) > stepsX)
            anchorList.Add(anchors[stepsY+1, stepsX]); 
        if (anchors.GetLength(0) > stepsY && anchors.GetLength(1) > stepsX+1)
            anchorList.Add(anchors[stepsY, stepsX+1]);
        if (anchors.GetLength(0) > stepsY+1 && anchors.GetLength(1) > stepsX+1) 
            anchorList.Add(anchors[stepsY=1, stepsX=1]);
        float minDistance = float.PositiveInfinity;
        Anchor result = null;
        foreach (var item in anchorList)
        {
            if(Vector2.Distance(item.transform.position,point) < minDistance)
            {
                result = item;
                minDistance = Vector2.Distance(item.transform.position, point);
            }
        }
        return result;



    }
   

    

}
