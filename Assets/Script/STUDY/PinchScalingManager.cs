﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;


//STUDYとして拾ってきたスクロリプト
//スクロールやピンチインアウトの処理ができるはず。代わりの無料アセットを発見したので保留。
//もってきただけなのでエラーがでている。
//http://kohki.hatenablog.jp/entry/Unity-uGUI-Pinch-Scaling-forMobile
//https://qiita.com/HT32/items/1cddd19b39254c74a364
//https://qiita.com/a_nishimura/items/c10a10e95f0ea1a27009
//https://blog.narumium.net/2016/12/22/%E3%80%90unity%E3%80%91%E3%82%B9%E3%83%AF%E3%82%A4%E3%83%97%E6%93%8D%E4%BD%9C%E3%81%A7%E7%89%A9%E4%BD%93%E3%81%AE%E5%9B%9E%E8%BB%A2%E3%83%BB%E6%8B%A1%E5%A4%A7%E7%B8%AE%E5%B0%8F/
//http://baba-s.hatenablog.com/entry/2018/05/28/090000
//http://narudesign.com/devlog/unity-pinch-in-out/
//https://blog.negativemind.com/2015/06/02/unity-free-asset-touchscrip/

public class PinchScalingManager : MonoBehaviour
{

    [SerializeField]
    private GridLayoutGroup content;    //拡大縮小するコンテンツ
    [SerializeField]
    private Transform wrapper;          //コンテンツのラッパー

    //コンテンツのRectTransformの参照
    private RectTransform contentRect;

    [SerializeField]
    private float scale;    //現在の拡大率

    [System.Serializable]
    struct RangeClass
    {
        public float min, max;
    }

    [SerializeField]
    private RangeClass RangeScale;          //拡大縮小の範囲
    [SerializeField]
    private RangeClass RangeLimitedScale;   //収束する範囲

    [SerializeField]
    private float TweenSecond;      //収束するまでにかかる時間

    private bool isPinch = false;       //ピンチ中であればtrue
    private Vector3 center;             //現在の中心座標
    private Vector2 defauldCellSize;    //拡大率が1の時のコンテンツの大きさ

#if UNITY_IOS || UNITY_ANDROID
    private float max_distance = 0;     //ピンチ開始時の指間の距離
#endif


    void Start()
    {

        contentRect = content.GetComponent<RectTransform>();    //参照を設定

        defauldCellSize = content.cellSize;
        center = contentRect.localPosition / scale;

        //状態の初期化
        UpdateScaling();

        //表示されている画面の中心を拡大率に合わせて調整する
        contentRect.anchoredPosition *= scale;
    }


    void Update()
    {

#if UNITY_EDITOR
        EditorControl();
#endif

#if !UNITY_EDITOR
        MobileControl();
#endif

    }


#if UNITY_EDITOR
    private void EditorControl()
    {
        //タッチ中の処理
        if (isPinch)
        {
            //タッチ終了を感知し、終了処理をする
            if (Input.GetAxisRaw("Vertical") == 0)
            {
                isPinch = false;
                StartTweenCoroutine();
                return;
            }
            scale += Input.GetAxisRaw("Vertical") * 1f * Time.deltaTime;
            SetNewScale(scale);
            UpdateScaling();
            return;
        }
        //タッチ開始時を感知し、初期化処理をする
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            center = contentRect.localPosition / scale;
            isPinch = true;
        }
    }
#endif


#if UNITY_IOS || UNITY_ANDROID
    private void MobileControl(){
        //タッチ中の処理
        if (isPinch) {
            //タッチ終了を感知し、終了処理をする
            if (Input.touchCount < 2) {
                isPinch = false;
                StartTweenCoroutine ();
                return;
            }
            float distance = Vector2.Distance (Input.touches [0].position, Input.touches [1].position);
            SetNewScale (distance / max_distance);
            UpdateScaling ();
            return;
        }
        //タッチ開始時を感知し、初期化処理をする
        if (Input.touchCount == 2) {
            center = contentRect.localPosition / scale;
            isPinch = true;
            float distance = Vector2.Distance (Input.touches [0].position, Input.touches [1].position);
            max_distance = distance / scale;
        }
    }
#endif


    /// <summary>
    /// 新しい拡大率のバリデートと更新をする
    /// </summary>
    private void SetNewScale(float new_scale)
    {

        // min < 新しい拡大率 < max に設定する
        new_scale = Mathf.Min(new_scale, RangeScale.max);
        new_scale = Mathf.Max(new_scale, RangeScale.min);

        scale = new_scale;

    }


    /// <summary>
    /// 収束させる拡大率を求め、コルーチンを開始する
    /// </summary>
    private void StartTweenCoroutine()
    {

        // min < 収束させる拡大率 < max に設定する
        float limited_scale = scale;
        limited_scale = Mathf.Min(limited_scale, RangeLimitedScale.max);
        limited_scale = Mathf.Max(limited_scale, RangeLimitedScale.min);

        StartCoroutine(TweenLimitedScale(limited_scale));

    }


    /// <summary>
    /// 拡大率を設定された値に収束させる
    /// </summary>
    IEnumerator TweenLimitedScale(float limited_scale)
    {

        if (scale == limited_scale)
            yield break;

        float timer = 0;
        float def_scale = scale - limited_scale;

        //scaleをTweenSecond秒以内にlimited_rateにする
        while (timer < TweenSecond)
        {
            timer += Time.deltaTime;
            scale -= def_scale * Time.deltaTime * (1f / TweenSecond);
            UpdateScaling();
            yield return 0;
        }

    }


    /// <summary>
    /// 設定された拡大率に基づいてオブジェクトの大きさを更新する
    /// </summary>
    private void UpdateScaling()
    {
        content.cellSize = defauldCellSize * scale;         //想定するコンテンツの大きさを更新する
        contentRect.localPosition = center * scale;         //拡大率が変わった時に中心座標がずれないように再設定する
        wrapper.localScale = new Vector3(scale, scale, 1);  //全体を拡大縮小する
    }

}

