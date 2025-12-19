using System.Collections.Generic;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public static InventoryData Instance;
    public List<InventoryItemDefinition> InventoryItems = new List<InventoryItemDefinition>();

    void Awake()
    {
      if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}