using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    /* Written by Jesper Wentzell */

    [SerializeField] private Item item;
    [SerializeField] protected float dropChance;

    public Item GetItem() { return item; }
    public float GetDropChance() { return dropChance; }

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = item.GetIcon;
        }
        
    }

    /// <summary>
    /// Activates the item pickup object.
    /// </summary>
    public virtual void Drop()
    {
        transform.gameObject.SetActive(true);
    }
}
