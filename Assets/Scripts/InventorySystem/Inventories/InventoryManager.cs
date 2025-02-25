using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public Inventory playerInventory;
    public Inventory shopInventory;
    public int playerCoins = 1000; 
    public Slider lifeBar;
    public int playerLife = 100; 
    public int maxPlayerLife = 100;

    public ItemBase selectedItem;
    public bool isItemFromPlayer; 

    public Text coinsText;

    void Start()
    {
        UpdateCoinsUI();
        UpdateLifeBar();
    }

    public void BuyItem()
    {
        if (selectedItem == null) return;

        // Para comprar, el �tem debe provenir del shop
        if (!isItemFromPlayer && playerCoins >= selectedItem.coinCost)
        {
            playerCoins -= selectedItem.coinCost;
            playerInventory.AddItem(selectedItem);
            shopInventory.RemoveItem(selectedItem);
            UpdateCoinsUI();
        }
    }

    public void SellItem()
    {
        if (selectedItem == null) return;

        // Para vender, el �tem debe provenir del inventario del jugador
        if (isItemFromPlayer)
        {
            playerCoins += selectedItem.coinCost;
            shopInventory.AddItem(selectedItem);
            playerInventory.RemoveItem(selectedItem);
            UpdateCoinsUI();
        }
    }

    public void UseItem()
    {
        if (selectedItem == null || !isItemFromPlayer) return;

        // Solo se pueden usar items consumibles (Food o Potion)
        if (selectedItem.itemType == Item.ItemType.Food || selectedItem.itemType == Item.ItemType.Potion)
        {
            // Restaurar vida seg�n el valor lifeRestore
            playerLife = Mathf.Min(playerLife + selectedItem.lifeRestore, maxPlayerLife);
            UpdateLifeBar();
            // Eliminar el �tem consumido del inventario
            playerInventory.RemoveItem(selectedItem);
        }
    }

    void UpdateCoinsUI()
    {
        if (coinsText != null)
        {
            coinsText.text = "Coins: " + playerCoins.ToString();
        }
    }

    void UpdateLifeBar()
    {
        if (lifeBar != null)
        {
            lifeBar.maxValue = maxPlayerLife;
            lifeBar.value = playerLife;
        }
    }

    // M�todo para recibir da�o al presionar el mouse sobre la Life Bar
    public void DamagePlayer()
    {
        playerLife = Mathf.Max(playerLife - 10, 0); // Ejemplo: 10 puntos de da�o
        UpdateLifeBar();
    }
}
