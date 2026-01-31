using UnityEngine;

[CreateAssetMenu(fileName = "Faction-", menuName = "Game Stuff/Faction")]
public class FactionSO : ScriptableObject
{
    [SerializeField]
    string factionName;
}
