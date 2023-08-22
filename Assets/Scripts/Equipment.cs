using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private EquipmentData equipmentData;

    public EquipmentData EquipmentData { get { return equipmentData; } }

}
