using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�˽ű���ȫ���׵�Ч��
public class ButtonWhiteLightEffect : MonoBehaviour
{
    public Image whiteLightPlane; // ȫ���׹�Ч����ƽ�����
    public Material whiteLightMaterial; // �׹�Ч���Ĳ���
    public float fadeInTime = 2f; // ���䵽ȫ�׵�ʱ��
    public float fadeOutTime = 0.5f; // �����������ʱ��
    public TextMeshProUGUI text;//��ʾ���Ľ�����
    void Start()
    {
        // ȷ���׹�Ч����ʼ״̬Ϊ���ɼ�
        whiteLightPlane.gameObject.SetActive(false);
        text.gameObject.SetActive(false);
    }
    void Update()
    {
        if (gemGlow.isfinal)
        {
            whiteLightPlane.gameObject.SetActive(true);
            StartCoroutine(GraduallyIncreaseRadius());
        }

    }

    IEnumerator FadeInOut()
    {
        // ���䵽ȫ��
        float elapsedTime = 0f;
        while (elapsedTime < fadeInTime)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / fadeInTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ����һ��ʱ��

        yield return new WaitForSeconds(1.0f);

        // ���������
        elapsedTime = 0f;
        while (elapsedTime < fadeOutTime)
        {
            Debug.Log("zhengchang");
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        whiteLightPlane.gameObject.SetActive(false);

       
    }

    IEnumerator GraduallyIncreaseRadius()
    {
        float elapsedTime = 0f;
        float initialRadius = 0.05f;
        float targetRadius = 1f;

        while (elapsedTime < fadeInTime)
        {
            float newRadius = Mathf.Lerp(initialRadius, targetRadius, elapsedTime / fadeInTime);
            whiteLightMaterial.SetFloat("_TransparencyRadius", newRadius);
            elapsedTime += Time.deltaTime;
            yield return null; // Wait until the next frame
        }
        // Ensure the final value is set exactly to the target
        whiteLightMaterial.SetFloat("_TransparencyRadius", targetRadius);
       
        StartCoroutine(Loadscene("MainScene")); //չʾ����������ص�������
    }

    IEnumerator Loadscene(string sceneName)
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadSceneAsync(sceneName);
        Debug.Log("load scene success");
    }
}
