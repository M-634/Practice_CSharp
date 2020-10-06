using UnityEngine;
using UnityEngine.UI;

public class UIOneLine : Graphic
{
    [SerializeField] private Vector2 _position1;
    [SerializeField] private Vector2 _position2;
    [SerializeField] private float _weight;

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        // （１）☆この行を追加！！過去にAddした頂点を全部削除!
        vh.Clear();
        // （２）あとは同じ。頂点を頂点リストに追加
        AddVert(vh, new Vector2(_position1.x, _position1.y - _weight / 2));
        AddVert(vh, new Vector2(_position1.x, _position1.y + _weight / 2));
        AddVert(vh, new Vector2(_position2.x, _position2.y - _weight / 2));
        AddVert(vh, new Vector2(_position2.x, _position2.y + _weight / 2));
        // （３）頂点リストを元にメッシュを貼る
        vh.AddTriangle(0, 1, 2);
        vh.AddTriangle(1, 2, 3);
    }

    private void AddVert(VertexHelper vh, Vector2 pos)
    {
        var vert = UIVertex.simpleVert;
        vert.position = pos;
        vert.color = color;
        vh.AddVert(vert);
    }

    float m_timer;

    private void Update()
    {
        m_timer += Time.deltaTime;
        if (m_timer > 1f)
        {
            _position2.x += 100;
            //これを呼ばないとOnPopulateMesh()が更新されないuGuiのわな
            //Dirty Flagの概念がUGUIには存在していることに注意する
            SetVerticesDirty();
            m_timer = 0;
        }
    }
}