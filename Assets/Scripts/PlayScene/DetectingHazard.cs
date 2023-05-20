using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private Player player;
    public GameObject wither;
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
            StartCoroutine("deathAction");
        }
    }

    public IEnumerator deathAction()
    {
        Instantiate(wither, player.transform.position, player.transform.rotation);
        player.enabled = false;
        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        player.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        player.transform.position = player.getPlayerRespawnPoint();
        player.GetComponent<Renderer>().enabled = true;
        player.enabled = true;
    }
}
