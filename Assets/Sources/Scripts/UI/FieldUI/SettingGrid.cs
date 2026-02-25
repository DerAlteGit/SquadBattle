using Unity.VisualScripting;
using UnityEngine;

public class SettingGrid : MonoBehaviour
{
    [SerializeField] private Transform leftUpPoint;
    [SerializeField] private Transform rightDownPoint;
    [Range(1,12f)][SerializeField] private int columnCount;
    [Range(1, 10f)][SerializeField] private int rowCount;
    [SerializeField] private Vector2[,] gridCells;
    [SerializeField] private GameObject gridPref;
    [SerializeField] private GameObject gridContainer;

    [SerializeField] private float margin;

    public void Init()
    {
        InitGrid();
        InstanceVisual();
        gridContainer.SetActive(false);
    }



    private void InstanceVisual()
    {
        for(int i = 0; i < rowCount; i++)
        {
            for(int j = 0; j < columnCount; j++)
            {
                GameObject cell = Instantiate(gridPref, gridCells[i, j], Quaternion.identity);
                cell.transform.SetParent(gridContainer.transform);

                float distanceX = (rightDownPoint.position.x - leftUpPoint.position.x) / (columnCount - 1);
                float distanceY = (leftUpPoint.position.y - rightDownPoint.position.y) / (rowCount - 1);

                if(distanceX <= distanceY)
                    cell.transform.localScale = new Vector3(distanceX-margin, distanceX-margin, 1);
                else 
                    cell.transform.localScale = new Vector3(distanceY - margin, distanceY - margin, 1);

            }
        }
    }
    public void SetActiveGrid(bool active)
    {
        gridContainer.SetActive(active);
    }
    private void InitGrid()
    {
        gridCells = new Vector2[rowCount, columnCount];
        float distanceX = (rightDownPoint.position.x - leftUpPoint.position.x)/(columnCount-1);
        float distanceY = (leftUpPoint.position.y - rightDownPoint.position.y)/(rowCount-1);
        
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                gridCells[i, j] = new Vector2(distanceX * j + leftUpPoint.position.x, leftUpPoint.position.y - distanceY * i);
                
            }
        }
    }
    public Vector2 GetNearestCell(Transform character)
    {
        float distance = 10000;
        Vector2 cell = new Vector2();
        for (int i = 0; i < rowCount; i++)
        {
            for (int j = 0; j < columnCount; j++)
            {
                if (Vector2.Distance(character.position, gridCells[i,j]) < distance)
                {
                    cell = gridCells[i, j];
                    distance = Vector2.Distance(character.position, gridCells[i, j]);
                }
            }
        }
        return cell;
        
    }
}
