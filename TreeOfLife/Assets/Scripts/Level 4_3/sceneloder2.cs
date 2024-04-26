using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloder2 : MonoBehaviour
{
    public Light pointlight;
    public Animator animator;
    public string sceneName;
    // Start is called before the first frame update

    IEnumerator Loadscene(string sceneName)
    {
        animator.SetBool("fadeout", true);
        animator.SetBool("fadein", false);
        yield return new WaitForSeconds(1);
        SceneManager.LoadSceneAsync(sceneName);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && pointlight.color == Color.green)
        {
            StartCoroutine(Loadscene(sceneName));
        }
    }

}
