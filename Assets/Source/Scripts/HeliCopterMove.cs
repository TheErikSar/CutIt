using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HeliCopterMove : MonoBehaviour
{

    public Transform target;
    public float duration;
    void Start()
    {
        var Seq = DOTween.Sequence();
        Seq.Append(transform.DOMove(target.position, duration, false));
    }
}
