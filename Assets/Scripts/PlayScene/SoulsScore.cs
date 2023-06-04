using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SoulsScore : MonoBehaviour
{
    public Text score;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        score = transform.GetComponent<Text>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Souls: " + player.souls;
    }
}
