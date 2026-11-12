using UnityEngine;

public class aaaaaa : MonoBehaviour
{
    [Header("Item Groups")]
    [SerializeField] private GameObject[] petRoomItems;
    [SerializeField] private GameObject[] petPlayItems;
    [SerializeField] private GameObject[] petKitchenItems;

    [Header("Current Item")]
    public int itemsInt = 0;

    [Header("Current Group")]
    public int currentGroup = 0;

    private void Start()
    {
        UpdateItem();
    }

    public void NextItem()
    {
        GameObject[] currentItems = GetCurrentItems();

        if (currentItems.Length == 0)
            return;

        itemsInt++;

        if (itemsInt >= currentItems.Length)
            itemsInt = 0;

        UpdateItem();
    }

    public void PreviousItem()
    {
        GameObject[] currentItems = GetCurrentItems();

        if (currentItems.Length == 0)
            return;

        itemsInt--;

        if (itemsInt < 0)
            itemsInt = currentItems.Length - 1;

        UpdateItem();
    }

    public void ChangeGroup(int newGroup)
    {
        currentGroup = newGroup;

        itemsInt = 0;

        UpdateItem();
    }

    public void UpdateItem()
    {
        DisableAllItems();

        GameObject[] currentItems = GetCurrentItems();

        if (currentItems.Length == 0)
            return;

        itemsInt = Mathf.Clamp(itemsInt, 0, currentItems.Length - 1);

        currentItems[itemsInt].SetActive(true);
    }

    private GameObject[] GetCurrentItems()
    {
        switch (currentGroup)
        {
            case 0:
                return petPlayItems;

            case 1:
                return petKitchenItems;

            case 2:
                return petRoomItems;

            default:
                return petPlayItems;
        }
    }

    private void DisableAllItems()
    {
        DisableItems(petRoomItems);
        DisableItems(petPlayItems);
        DisableItems(petKitchenItems);
    }

    private void DisableItems(GameObject[] items)
    {
        foreach (GameObject item in items)
        {
            if (item != null)
                item.SetActive(false);
        }
    }
}
