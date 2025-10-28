public class ItemCounter 
{
    private PickupItem[] _items;

    public ItemCounter(PickupItem[] items)
    {
        _items = items;
    }

    public bool IsGameItemsCollected()
    {
        if (GetActiveItemsCount() <= 0)
            return true;

        return false;
    }

    public int GetActiveItemsCount()
    {
        int countActiveItems = 0;

        foreach (var item in _items)
        {
            if (item.gameObject.activeSelf)
                countActiveItems++;
        }

        return countActiveItems;
    }
}
