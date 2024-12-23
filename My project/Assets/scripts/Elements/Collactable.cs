using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor.Build.Content;
using System;
using DG.Tweening;


public class Collactable : MonoBehaviour
{
    void Start()
    {
        StartAnimation();
        //örnek kod
    }

    private void StartAnimation()
    {
        transform.DOMoveY(transform.position.y + 1, .5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
        transform.DORotate(Vector3.up * 90, .5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }
}
