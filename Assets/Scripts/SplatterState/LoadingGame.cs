using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingGame : MonoBehaviour
{
    private WaitForSeconds waitForSeconds;
    public static int level;

    private bool loading;

    // Start is called before the first frame update
    void Start()
    {
        waitForSeconds = new WaitForSeconds(5f);
        loading = false; 
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!loading)
        {
            Debug.Log("Loading game before 2");
            loading = true;
            StartCoroutine("loadingNextScene");
        }
    }

    public IEnumerable loadingNextScene()
    {
        Debug.Log("Loading game before");
        yield return waitForSeconds;
        Debug.Log("Loading game");
        SceneManager.LoadSceneAsync("PlayScene");
    }
}
