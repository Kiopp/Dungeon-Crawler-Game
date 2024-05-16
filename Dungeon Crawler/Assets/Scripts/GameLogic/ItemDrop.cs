using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    /* Written by Jesper Wentzell */

    [SerializeField] private Item item;
    [SerializeField] private float dropChance;

    public Item GetItem() { return item; }
    public float GetDropChance() { return dropChance; }

    private void Start()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = item.GetIcon;
    }

    /// <summary>
    /// Activates the item pickup object.
    /// </summary>
    public void Drop()
    {
        transform.gameObject.SetActive(true);
    }
}
