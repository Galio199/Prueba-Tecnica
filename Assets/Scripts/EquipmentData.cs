using UnityEngine;

public enum StatType
{
    Daño, defensa, velocidad
}


[CreateAssetMenu(fileName = "New Equipment Data", menuName = "Equipment Data")]
public class EquipmentData : ScriptableObject
{
    [SerializeField] private string equipmentName;
    [SerializeField] private int stat;
    [SerializeField] private StatType type;
    [SerializeField] private int cost;

    public string EquipmentName { get { return equipmentName; } }
    public int Stat { get { return stat; } }
    public StatType Type { get { return type; } }
    public int Cost { get { return cost; } }
}
