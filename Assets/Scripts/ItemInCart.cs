using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInCart : Item
{
    [SerializeField]
    private TextMeshProUGUI nameTMP, priceTMP, countTMP;
    public SpriteRenderer image;
    public Collider2D boxCollider;
    private int count;
    private void OnMouseDown()
    {
        GlobalData.shopManager.RemoveItemFromCart(this);
    }
    public void SetItemProperties(string name, int count, int price, Sprite sprite, int id)
    {
        this.name = name;
        this.price = price;
        this.id = id;
        SetCount(count);
        SetName(name);
        SetPrice(price);
        SetImage(sprite);
    }
    void SetImage(Sprite sprite)
    {
        image.sprite = sprite;
        //Изображение по какой-то причине сдвигается, возвращаем его на место
        image.transform.localPosition = new Vector3(-1.75f, -1.1f, 0);
    }
    void SetName(string newName)
    {
        nameTMP.text = newName;
    }
    public void SetCount(int newCount)
    {
        count = newCount;
        countTMP.text = "x"+newCount.ToString();
    }
    public void UpdateCount(int difference)
    {
        countTMP.text = difference.ToString();
    }
    void SetPrice(int newPrice)
    {
        priceTMP.text = "Total: $" + (count * newPrice).ToString();
    }
    public void UpdatePrice()
    {
        priceTMP.text = "Total: $" + (count * price).ToString();
    }
}
