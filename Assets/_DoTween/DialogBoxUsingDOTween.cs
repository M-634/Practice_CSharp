using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

/// <summary>
/// ダイアログUIのコントロールを制御するクラス
/// </summary>
public class DialogBoxUsingDOTween : MonoBehaviour
{
    [SerializeField] Text m_dialogText;
    [SerializeField] Button m_openButton;
    [SerializeField] Button m_closeButton;

    [SerializeField] Vector3 m_openScale = Vector3.one;
    [SerializeField] float m_openSpeeDuration = 1f;
    [SerializeField] float m_closeSpeeDuration = 1f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.localScale = Vector3.zero;
        RestDialog();
    }

    private void RestDialog()
    {
        gameObject.SetActive(false);
        m_openButton.interactable = true;
        m_closeButton.interactable = false;
    }

    public void OpenBottunClick()
    {
        gameObject.SetActive(true);
        m_openButton.interactable = false;

        DOTween.Sequence()
            .Append(this.transform.DOScale(m_openScale, m_openSpeeDuration))
            .Append(DOVirtual.Float(0f, 100f, 3f, value => { m_dialogText.text = "Count; " + (int)value; })
            .OnComplete(() => m_closeButton.interactable = true));
    }

    public void CloseButtunClick()
    {
        DOTween.Sequence()
           .Append(this.transform.DOScale(Vector3.zero, m_closeSpeeDuration))
           .OnComplete(() => RestDialog());
    }
}
