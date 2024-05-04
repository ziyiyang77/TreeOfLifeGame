using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.enabled = false;
    }

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
        animator.enabled = true;
        animator.SetBool("fadeout", true);
        //  animation.Play("FadeOut");
        Debug.Log("fadeout");
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("load scene success");
    }
    // Update is called once per frame
    
}
