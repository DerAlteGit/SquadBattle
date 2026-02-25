using NUnit.Framework;
using System.Collections.Generic;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CharacterDrag : MonoBehaviour,  IDragHandler,IBeginDragHandler,IEndDragHandler
{
    private Transform currentParent;
    [SerializeField] private LayerMask mask;
    [SerializeField]private GameObject characterPref;
    [SerializeField] private GameObject visual;
    private GameObject character;
    [SerializeField] private GraphicRaycaster raycaster;

    [SerializeField]private SettingGrid grid;
    [SerializeField] private float magnitDistance;



    public void OnBeginDrag(PointerEventData eventData)
    {
        if(IsUI(eventData))currentParent = transform.parent;
        transform.SetParent(currentParent.parent);
        grid.SetActiveGrid(true);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = eventData.position;

        if (IsUI(eventData))
        {
            if(character != null) character.SetActive(false);
            visual.SetActive(true);
            
        }
        else
        {
            
            visual.SetActive(false);
            if (character == null)
            {
                
                character = Instantiate(characterPref, new Vector3(pos.x,pos.y,0),Quaternion.identity);
            }
            else
            {
                character.SetActive(true);
            }
            if (Vector2.Distance(pos, grid.GetNearestCell(character.transform)) < magnitDistance)
            {
                
                CellMagnit();
            }
            else
            {
                character.transform.position = new Vector3(pos.x, pos.y, 0);
              
            }
            
        }
        


    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(currentParent);
        grid.SetActiveGrid(false);
    }

    private void CellMagnit()
    {
        if(character != null)
        {
            if (character.activeSelf)
            {
                character.transform.position = grid.GetNearestCell(character.transform);
            }
        }
    }
    private bool IsUI(PointerEventData eventData)
    {
        List<RaycastResult> results = new();
        raycaster.Raycast(eventData, results);
        foreach (var result in results)
        {
            if(result.gameObject.layer == System.Math.Log(mask.value, 2))
            {
                return true;
            }
        }
        return false;
    }
}
