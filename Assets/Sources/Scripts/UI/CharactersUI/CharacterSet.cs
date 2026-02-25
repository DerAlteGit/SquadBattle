using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterSet : MonoBehaviour
{
    [SerializeField] private SettingGrid grid;
    private GameObject currentCharacter;
    private GameObject currentCell;
    [SerializeField]private LayerMask gridMask;

    [SerializeField] private SetInputConfig inputConfig;
    public void SetCharacter(GameObject obj)
    {
        Cancel();
        if(obj != null)
        {
            grid.SetActiveGrid(obj);
            currentCharacter = obj;
        }
    }


    
    private void InsertCharacter()
    {
        
        GridCell cell = GetClickCell();
        
        if(cell != null)InstanceCharacter(cell);

    }
    public void Cancel()
    {
        currentCharacter = null;
        grid.SetActiveGrid(false);
    }
    private void RemoveCharacter()
    {
        GridCell cell = GetClickCell();

        if (cell != null) cell.Remove();
    }
    
    
    private void Update()
    {
        if (Input.GetKeyUp(inputConfig.SetCharacter)) InsertCharacter();

        if (Input.GetKeyUp(inputConfig.RemoveCharacter)) RemoveCharacter();

        if (Input.GetKeyUp(inputConfig.CancelChouse)) Cancel();
        
    }

    private GridCell GetClickCell()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        GridCell cell = null;
        RaycastHit2D[] results = Physics2D.RaycastAll(new Vector3(mousePos.x, mousePos.y, -10), Vector3.forward, 30, gridMask);

        foreach (RaycastHit2D r in results)
        {

            if (r.transform.GetComponent<GridCell>())
            {
                cell = r.transform.GetComponent<GridCell>();

                break;
            }

        }
        return cell;
    }
    private void InstanceCharacter(GridCell cell)
    {
        if (currentCharacter != null && !cell.IsFull)
        {
            GameObject character = Instantiate(currentCharacter, cell.transform.position, Quaternion.identity);
            cell.Insert(character);
        }
    }
}
