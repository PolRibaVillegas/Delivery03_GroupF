using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory System/Items/Generic")]
public class ItemBase : ScriptableObject
{
    public string Name;
    public Sprite ImageUI;
    public bool IsStackable;
    public int coinCost;
    public ItemType itemType;
}

public enum ItemType
{
    Food,
    Potion,
    Weapon
}