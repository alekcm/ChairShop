using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInShop : Item
{
    [SerializeField]
    private TextMeshProUGUI nameTMP, priceTMP;
    public SpriteRenderer image;
    public Collider2D boxCollider;
    private GameObject itemInfoGO;

    private void OnMouseEnter()
    {
        itemInfoGO = Instantiate(ShopManager.ItemInfoGO, Input.mousePosition, Quaternion.identity, gameObject.transform);
        itemInfoGO.transform.localPosition = new Vector3(1.35f, 0.82f, -5000f);
        itemInfoGO.GetComponent<ItemInfo>().FillInfo(name, price, description);
    }

    private void OnMouseExit()
    {
        Destroy(itemInfoGO);
    }

    private void OnMouseDown()
    {
        GlobalData.shopManager.AddItemToCard(this);
    }

    public void UpdateItemProperties(string name, string description, int price, string spriteName, int id)
    {

        this.name = name;
        this.price = price;
        this.description = description;
        this.id = id;
        SetName(name);
        SetPrice(price);
        SetImage(spriteName);
    }
    void SetImage(string spriteName)
    {
        string filePath = Application.dataPath + "/Images/" + spriteName;
        image.sprite = ConvertTextureToSprite(LoadTexture(filePath));
        //Изображение по какой-то причине сдвигается, возвращаем его на место
        image.transform.localPosition = new Vector3(-1.75f, -1.1f, 0);
    }
    void SetName(string newName)
    {
        nameTMP.text = newName;
    }
    void SetPrice(int newPrice)
    {
        priceTMP.text = "$" + newPrice.ToString();
    }
}
