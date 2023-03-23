using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    public Texture2D worldLevel;

    public ColorToScript[] colorToScriptMap;

    public GameObject landStatus;

    GameObject temp;
    private int worldWidth;
    private int worldHeight;

    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
        Debug.Log("Calling builder");
    }

    void GenerateLevel(){
        worldWidth = worldLevel.width;
        worldHeight = worldLevel.height;

        for (int x = 0; x < worldLevel.width; x++){
            for (int y = 0; y < worldLevel.height; y++){
                GenerateTile(x,y);
            }
        }
    }

    void GenerateTile(int x, int y){
        Color pixelColor = worldLevel.GetPixel(x,y);

        // the pixel is transparent
        if (pixelColor.a == 0){
            return;
        }

        foreach(ColorToScript pixel in colorToScriptMap){
            if(pixel.color.Equals(pixelColor)){
                Vector3 position = new Vector3(x,y,pixel.z);

                if (pixel.prefab.tag.Equals("Player"))
                    position = new Vector3(x, y, pixel.z);

                temp = Instantiate(pixel.prefab,position,Quaternion.identity, transform);
                
                if (pixel.prefab.tag.Equals("Player"))
                {
                    // -(y * 0.07f)
                    Vector3 position2 = new Vector3(x, y, pixel.z);
                    Instantiate(landStatus, position2, Quaternion.identity, temp.transform);
                }
            }
        }
    }

    public int getWorldWidth() { return worldWidth; }
    public int getWorldHeight() { return worldHeight; }
}
