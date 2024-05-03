using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//当门开启后播放淡出的动画
public class FadeOutController : MonoBehaviour
{
    public Animator animator;
    public GameObject block;
    public string sceneName;
    
    void Update()
    {
        if (block.activeInHierarchy==false)
        {
            Debug.Log("block ");
            StartCoroutine(Loadscene(sceneName));
        }
        else
        {
            Debug.Log("no  ");
        }
        
    }
    IEnumerator Loadscene(string sceneName)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
