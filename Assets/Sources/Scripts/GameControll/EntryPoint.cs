using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private SettingGrid grid;
    [SerializeField]private CardSetter cardSetter;
    [SerializeField]private BattleInitializer battleInitializer;
    [SerializeField] private UITrigger uiTriger;
    [SerializeField]

    private void InitGrid()
    {
        grid.Init();
    }
    private void GenerateSetUI()
    {
        cardSetter.Init();

    }
    private void StartMenu()
    {

    }
    private void Awake()
    {
        StartSquadBuilder();
    }
    private void StartSquadBuilder()
    {
        InitGrid();
        GenerateSetUI();
    }
    public void StartBattle()
    {
        uiTriger.ActivateBattleUI();
        battleInitializer.Init();
        

    }
}
