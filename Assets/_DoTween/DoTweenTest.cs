using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.Collections.LowLevel.Unsafe;
/// <summary>
/// DoTweenの機能を実験するクラス
/// 個人的にまとめてみる
/// </summary>
public class DoTweenTest : MonoBehaviour
{
    [SerializeField] Color m_setColor;

    // Start is called before the first frame update
    void Start()
    {
        //DOTweenMove();

        //色の変更、Material、Sprite、Light、uGUI Image,CanvasGroup,uGUI Textなどに適応できる
        //DOfade,DOColor
        var material = GetComponent<MeshRenderer>().material;
        material.DOColor(m_setColor, 2f);

    }

    private void DOTweenMove()
    {
        this.transform.Translate(5, 0, 0);//瞬間移動
        this.transform.DOMoveX(5, 1f);//1秒間で目的地まで直進

        this.transform.DOMoveX(5, 1f).SetEase(Ease.InSine);
        //SetEase関数；動きの緩急をどのようにつけるか以下参考リンク
        //https://easings.net/ja

        this.transform.DOMoveX(5, 1f).OnComplete(() => Debug.Log("移動完了"));//終了時実行

        this.transform.DOMoveX(5, 1f).SetDelay(0.4f);//遅延実行

        //上記のメソッドを組み合わせる
        this.transform.DOMoveX(5, 1f).SetDelay(0.4f).SetEase(Ease.InExpo).OnComplete(() => Debug.Log("OK"));

        //相対移動；現在位置から足された位置に移動する
        this.transform.DOMoveX(5, 1f).SetRelative();

        //Sequence ・・・ AppendとJoin
        //メソッドチェインを使い、DoTweenによる動きをつなげる
        //Appendは終了後, Joinは同時に実行

        DOTween.Sequence()
             .Append(this.transform.DOMoveX(5, 1f).SetRelative())
             .Append(this.transform.DOMoveX(-5, 1f).SetRelative())//ここと
             .Join(this.transform.DORotate(new Vector3(0, 360, 0), 1f).SetRelative())//ここが同時に実行
             .Play();

        //Set Loopで回数指定をして動きを繰り返す
        //Set Loop(-1)で動きを無限に繰り返す(*この場合OnCompleteは呼ばれない)

        DOTween.Sequence()
             .Append(this.transform.DOMoveX(5, 1f).SetRelative())
             .Append(this.transform.DOMoveX(-5, 1f).SetRelative())//ここと
             .Join(this.transform.DORotate(new Vector3(0, 360, 0), 1f).SetRelative())//ここが同時に実行
             .SetLoops(5)
             .Play();
    }
}
