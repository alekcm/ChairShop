using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public struct ItemStruct
{
    public int id;
    public string name, description, filename;
    public int price;
}

[System.Serializable]
public struct ItemListStruct
{
    public List<ItemStruct> chairs;
}
[Serializable]
public class Item: MonoBehaviour
{
    public int id;
    public new string name;
    public string description, filename;
    public int price;

    public static Sprite ConvertTextureToSprite(Texture2D texture, float PixelsPerUnit = 100.0f, SpriteMeshType spriteType = SpriteMeshType.Tight)
    {

        Sprite NewSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0, 0), PixelsPerUnit, 0, spriteType);

        return NewSprite;
    }

    public static Texture2D LoadTexture(string FilePath)
    {
        Texture2D Tex2D;
        byte[] FileData;

        if (File.Exists(FilePath))
        {
            FileData = File.ReadAllBytes(FilePath);
            Tex2D = new Texture2D(2, 2);           
            if (Tex2D.LoadImage(FileData))          
                return Tex2D;                 
        }
        return null;                    
    }

}

