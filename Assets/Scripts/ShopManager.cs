using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    public GameObject itemInShopPrefab, itemInShopGrid, itemInCartPrefab, itemInCartGrid, _ItemInfoGO, waitScreen;
    public static GameObject ItemInfoGO;
    private Dictionary<int, int> goodsIDList = new Dictionary<int, int>();
    private List<ItemInCart> itemsInCart = new List<ItemInCart>();
    [SerializeField]
    private TextMeshProUGUI totalPriceTMP;
    private int totalPrice = 0;
    [SerializeField]
    public static GameObject draggableObject;


    void Start()
    {
        GlobalData.shopManager = this;
        ItemInfoGO = _ItemInfoGO;
        StartCoroutine(SendGetGoodsRequest());
    }
    public void RenoveAllItemsFromCart()
    {
        while (itemInCartGrid.transform.childCount > 0)
        {
            DestroyImmediate(itemInCartGrid.transform.GetChild(0).gameObject);
        }
        goodsIDList = new Dictionary<int, int>();
        itemsInCart = new List<ItemInCart>();
        ChangeTotalPrice(-totalPrice);
    }
    public void RemoveItemFromCart(ItemInCart item)
    {

        foreach (var itemInCart in itemsInCart)
        {

            if (itemInCart.id == item.id)
            {
                if (goodsIDList[item.id] > 1)
                {
                    goodsIDList[item.id]--;
                    itemInCart.SetCount(goodsIDList[item.id]);
                    itemInCart.UpdatePrice();
                }
                else
                {
                    goodsIDList.Remove(item.id);
                    itemsInCart.Remove(item);
                    Destroy(itemInCart.gameObject);
                }
                break;
            }
        }
        ChangeTotalPrice(-item.price);
    }

    public void AddItemToCard(ItemInShop item)
    {
        if (goodsIDList.ContainsKey(item.id)) {
            goodsIDList[item.id]++;
            foreach(var itemInCart in itemsInCart)
            {
                if (itemInCart.id == item.id)
                {
                    itemInCart.SetCount(goodsIDList[item.id]);
                    itemInCart.UpdatePrice();
                    break;
                }
            }
        }
        else
        {
            GameObject itemObject = Instantiate(itemInCartPrefab, itemInCartGrid.transform);
            itemObject.GetComponent<ItemInCart>().SetItemProperties(item.name, 1, item.price, item.image.sprite, item.id);
            goodsIDList.Add(item.id, 1);
            itemsInCart.Add(itemObject.GetComponent<ItemInCart>());
        }
        ChangeTotalPrice(item.price);
    }

    private void ChangeTotalPrice(int value)
    {
        totalPrice += value;
        totalPriceTMP.text = "$" + totalPrice.ToString();
    }

    private IEnumerator SendGetGoodsRequest()
    {
        waitScreen.SetActive(true);
        UnityWebRequest request = UnityWebRequest.Get(GlobalData.getGoodsURL);
        yield return request.SendWebRequest();
        ItemListStruct responce = JsonUtility.FromJson<ItemListStruct>(request.downloadHandler.text);
        waitScreen.SetActive(false);
        foreach (ItemStruct item in responce.chairs)
        {
            yield return new WaitForSeconds(0.125f);
            GameObject itemObject = Instantiate(itemInShopPrefab, itemInShopGrid.transform);
            itemObject.GetComponent<ItemInShop>().UpdateItemProperties(item.name, item.description, item.price, item.filename, item.id);
        } 
    }
    public void StartSendGoodsCheckoutRequestCoroutine()
    {
        StartCoroutine(SendGoodsCheckoutRequest(goodsIDList));
    }
    public IEnumerator SendGoodsCheckoutRequest(Dictionary<int, int> goodsIDList)
    {
        waitScreen.SetActive(true);
        WWWForm form = new WWWForm();
        string json = JsonUtility.ToJson(goodsIDList);
        UnityWebRequest request = UnityWebRequest.Post(GlobalData.goodsCheckoutURL,form);
        byte[] postBytes = Encoding.UTF8.GetBytes(json);
        UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);
        request.uploadHandler = uploadHandler;
        yield return request.SendWebRequest();
        Debug.Log("Успешно доставлено");
        waitScreen.SetActive(false);
    }
}
