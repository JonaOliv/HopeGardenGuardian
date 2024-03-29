using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSoul : MonoBehaviour
{
    public GameObject soulCollected;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.souls++;
            Instantiate(soulCollected,gameObject.transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
