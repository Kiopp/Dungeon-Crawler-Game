using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName ="Item/Create New Item")]

public class Item : ScriptableObject
{
    private int id;
    private string itemName;
    private int value;
    private Sprite icon;
    [TextArea]
    private string description;

    public string GetName
    {
        get { return itemName; }
    }

    public Sprite GetIcon
    {
        get { return icon; }
    }
}