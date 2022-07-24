using UnityEngine;
[System.Serializable]
public class ColorToScript
{
    // public enum BLOCK_TYPE{
	// 	EMPTY(0,0,0),
	// 	PLATFORM(2,225,18),
	// 	DECORATION(231,37,37),
	// 	OUT_PORTAL(231,231,37),
	// 	IN_PORTAL(255,255,255);
		
	// 	private int color;
		
	// 	private BLOCK_TYPE(int r, int g, int b){
	// 		color = r << 24 | g << 16 | b << 8 | 0xff;
	// 	}
		
	// 	public boolean sameColor(int color){
	// 		return this.color == color;
	// 	}
	// }
    public Color color;
    public GameObject prefab; 

    //add the level on the screeen for decoration
    public int z;
}
