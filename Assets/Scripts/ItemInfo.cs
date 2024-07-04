using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfo : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI name, price, description;
    public void FillInfo(string name, int price, string description)
    {
        this.name.text = name;
        this.price.text = "$" + price.ToString();
        this.description.text = description;
    }
}
