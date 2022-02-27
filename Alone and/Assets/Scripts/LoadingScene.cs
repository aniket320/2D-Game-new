using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public Slider loader;
    float load = 0;
    public int LevIndex;

    public Sprite[] sprites;
    public Image images;
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
         images.sprite = sprites[Random.Range(0, sprites.Length)];
         images.enabled = true;     
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(LoadLevel());
        load+=1*0.005f;
        loader.value = load;

        if (loader.value >= 1)
        {
            SceneManager.LoadScene(LevIndex);
        }
    }

   
   IEnumerator LoadLevel()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(LevIndex);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loader.value = progress ;
            yield return null;
        }
    }
}
