using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{   
    [SerializeField] private int chestIndex;

    private void OnMouseDown() => StoreManager.Instance.ShowStore(chestIndex);
}
