using UnityEngine;

[CreateAssetMenu(fileName = "New Input Config", menuName = "InputConfig", order = 51)]
public class SetInputConfig : ScriptableObject
{
    [field: SerializeField]public KeyCode CancelChouse { get; private set; }
    [field: SerializeField] public KeyCode SetCharacter {  get; private set; }
    [field: SerializeField] public KeyCode RemoveCharacter {  get; private set; }
}
