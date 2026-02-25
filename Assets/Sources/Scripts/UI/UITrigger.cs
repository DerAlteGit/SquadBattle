using System.Collections.Generic;
using UnityEngine;

public class UITrigger : MonoBehaviour
{
    [SerializeField]private List<GameObject> nonBattleObjects;
    [SerializeField]private List<GameObject> battleObjects;

    public void ActivateBattleUI()
    {
        DeactivateUIGroup(nonBattleObjects);
        ActivateUIGroup(battleObjects);
    }
    public void ActivateBuilderUI()
    {
        DeactivateUIGroup(battleObjects);
        ActivateUIGroup(nonBattleObjects);
    }
    private void DeactivateUIGroup(List<GameObject> uiGroup)
    {
        foreach (var item in uiGroup)
        {
            item.SetActive(false);
        }
    }
    private void ActivateUIGroup(List<GameObject> uiGroup)
    {
        foreach (var item in uiGroup)
        {
            item.SetActive(false);
        }
    }
}
