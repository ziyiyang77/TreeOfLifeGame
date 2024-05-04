using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//���ſ����󲥷ŵ����Ķ���
public class FadeOutController : MonoBehaviour
{
    public Animator animator;
    public string sceneName;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {           
            StartCoroutine(Loadscene(sceneName));
           
        }
    }

    IEnumerator Loadscene(string sceneName)
    {
        animator.SetBool("fadeout", true);
     //   animator.SetBool("fadein", false);
        Debug.Log("fadeout");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("load scene success");
    }
}
