using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LSManager : MonoBehaviour
{

    public LSPlayer thePlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadLevel()
    {
        StartCoroutine(LoadLevelCo());
    }

    public IEnumerator LoadLevelCo()
    {
        LSUIController.instance.FadeToBlack();
        yield return new WaitForSeconds((3f/LSUIController.instance.fadeSpeed) * 0.5f);

        SceneManager.LoadScene(thePlayer.currentPoint.levelToLoad);
    }
}
