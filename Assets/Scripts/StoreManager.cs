using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    # region Singleton
    private static StoreManager instance;

    public static StoreManager Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region Resaltar interactuables
    [Header("Resaltar interactuables")]
    [SerializeField] private SpriteRenderer[] chests;
    [SerializeField] private Tilemap doors;

    void Start()
    {
        coinsPlayer.text = Player.Instance.coins.ToString();
        StartCoroutine(HigtlightObjects());
    }

    private IEnumerator HigtlightObjects()
    {
        yield return new WaitForSeconds(1f);
        foreach (SpriteRenderer sr in chests){
            sr.color = Color.yellow;
        }
        doors.color = Color.yellow;
        yield return new WaitForSeconds(1.5f);
        foreach (SpriteRenderer sr in chests)
        {
            sr.color = Color.white;
        }
        doors.color = Color.white;
    }
    #endregion

    [Header("Objetos tienda")]
    [SerializeField] private GameObject[] objectsChest1;
    [SerializeField] private GameObject[] objectsChest2;
    [SerializeField] private GameObject[] objectsChest3;
    [SerializeField] private GameObject[] objsUIStore;
    [SerializeField] private GameObject[] objsUIPlayer;
    [SerializeField] private GameObject panelStore;
    [SerializeField] private GameObject chestsContainer;
    [SerializeField] private TMP_Text coinsPlayer;

    private GameObject[] objsStore = new GameObject[3];

    public void ShowStore(int index)
    {
        chestsContainer.SetActive(false);
        panelStore.SetActive(true);
        switch (index) {
            case 1:
                objsStore = objectsChest1;
                break;            
            case 2:
                objsStore = objectsChest2;
                break;                
            case 3:
                objsStore = objectsChest3;
                break;
        }
        UpdateObjectStore();
    }
    public void HideStore()
    {
        chestsContainer.SetActive(true);
        panelStore.SetActive(false);
    }

    private void UpdateObjectStore()
    {
        coinsPlayer.text = Player.Instance.coins.ToString();
        for (int i = 0; i < 4; i++)
        {
            objsUIStore[i].SetActive(true);
            if (Player.Instance.equipment[i] != objsStore[i]) UpdateUI(objsUIStore[i], objsStore[i]);
            else objsUIStore[i].SetActive(false);

            objsUIPlayer[i].SetActive(true);
            if (Player.Instance.equipment[i] != null) UpdateUI(objsUIPlayer[i], Player.Instance.equipment[i]);
            else objsUIPlayer[i].SetActive(false);
        }
    }

    private void UpdateUI(GameObject uiObject, GameObject equipmentObject)
    {
        Equipment equipment = equipmentObject.GetComponent<Equipment>();
        uiObject.GetComponent<Image>().sprite = equipmentObject.GetComponent<SpriteRenderer>().sprite;
        uiObject.transform.Find("Nombre").GetComponent<TMP_Text>().text = equipment.EquipmentData.EquipmentName;
        uiObject.transform.Find("Valor").GetComponent<TMP_Text>().text = equipment.EquipmentData.Cost.ToString();
        uiObject.transform.Find("Stat").GetComponent<TMP_Text>().text = "+" + equipment.EquipmentData.Stat.ToString() + " " + equipment.EquipmentData.Type.ToString();
    }

    public void BuyEquipment(int index)
    {
        GameObject obj = objsStore[index];
        int price = obj.GetComponent<Equipment>().EquipmentData.Cost;
        if (Player.Instance.equipment[index] != null && Player.Instance.coins + Player.Instance.equipment[index].GetComponent<Equipment>().EquipmentData.Cost >= price) 
            CellEquipment(index, false);
        if (Player.Instance.coins >= price)
        {
            Player.Instance.equipment[index] = obj;
            Player.Instance.coins -= price;
            UpdateObjectStore();
        }
    }

    public void CellEquipment(int index) => CellEquipment(index, true);

    public void CellEquipment(int index, bool up)
    {
        Player.Instance.coins += Player.Instance.equipment[index].GetComponent<Equipment>().EquipmentData.Cost;
        Player.Instance.equipment[index] = null;
        if (up) UpdateObjectStore();
    }

}
