using System.Collections;
using UnityEngine;
using UnityEngine.UI;

//�˽ű���ȫ���׵�Ч��
public class ButtonWhiteLightEffect : MonoBehaviour
{
    public Image whiteLightPlane; // ȫ���׹�Ч����ƽ�����
    public Material whiteLightMaterial; // �׹�Ч���Ĳ���
    public float fadeInTime = 2f; // ���䵽ȫ�׵�ʱ��
    public float fadeOutTime = 0.5f; // �����������ʱ��

    void Start()
    {
        // ȷ���׹�Ч����ʼ״̬Ϊ���ɼ�
        whiteLightPlane.gameObject.SetActive(false);
    }
    void Update()
    {
        if (gemGlow.isfinal)
        {
            whiteLightPlane.gameObject.SetActive(true);
            StartCoroutine(FadeInOut());
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
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeOutTime);
            whiteLightMaterial.color = new Color(1f, 1f, 1f, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        whiteLightPlane.gameObject.SetActive(false);

       
    }
}
