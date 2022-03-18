using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class UITween : MonoBehaviour
{
    #region Private Variables

    [SerializeField] GameObject startPos;
    [SerializeField] Quaternion startRot = new Quaternion(0,0,0,0);
    [SerializeField] Vector3 startScale = new Vector3(0,0,0);

    [Header("Tween Values")]
    [Space(10)]
    [Tooltip("The position for the object ot tween to")]
    [SerializeField] GameObject tweenLocation;
    [Tooltip("The rotation for the object to tween to")]
    [SerializeField] Quaternion tweenRotation = new Quaternion(0,0,0,0);
    [Tooltip("The scale for the object to tween to")]
    [SerializeField] Vector3 tweenScale = new Vector3(1,1,1);

    [Header("Tween Times")]
    [Space(10)]
    [Tooltip("The time it takes to complete the move section of the tween")]
    [SerializeField] float moveTweenTime = 0f;
    [Tooltip("The time it takes to complete the rotation section of the tween")]
    [SerializeField] float rotationTweenTime = 0f;
    [Tooltip("The time it takes to omplete the scale section of the tween")]
    [SerializeField] float scaleTweenTime = 0f;

    [Space(10)]
    [Tooltip("Callbacks to be performed when a tween is completed")]
    [SerializeField] UnityEvent OnTweenComplete;

    [Space(10)]
    [Tooltip("Callbacks to be performed when a tween is returned to starting positions")]
    [SerializeField] UnityEvent OnTweenReturn;

    #endregion


    public void ReturnTween()
    {
        Sequence BeginTween = DOTween.Sequence();
        Vector3 tweenPos = tweenLocation.transform.position;

        BeginTween.Join(transform.DOMove(tweenPos, 0))
            .Join(transform.DORotateQuaternion(tweenRotation, 0))
            .Join(transform.DOScale(tweenScale, 0));

        BeginTween.Play();

        Sequence ReturnTween = DOTween.Sequence();
        Vector3 returnPos = startPos.transform.position;

        ReturnTween.Join(transform.DOMove(returnPos, moveTweenTime))
            .Join(transform.DORotateQuaternion(startRot, rotationTweenTime))
            .Join(transform.DOScale(startScale, scaleTweenTime))
            .OnComplete(() => OnTweenReturn.Invoke());

        ReturnTween.Play();
    }

    public void BeginTween()
    {
        Sequence ReturnTween = DOTween.Sequence();
        Vector3 returnPos = startPos.transform.position;

        ReturnTween.Join(transform.DOMove(returnPos, 0))
            .Join(transform.DORotateQuaternion(startRot, 0))
            .Join(transform.DOScale(startScale, 0));

        ReturnTween.Play();

        Sequence BeginTween = DOTween.Sequence();
        Vector3 tweenPos = tweenLocation.transform.position;

        BeginTween.Join(transform.DOMove(tweenPos, moveTweenTime))
            .Join(transform.DORotateQuaternion(tweenRotation, rotationTweenTime))
            .Join(transform.DOScale(tweenScale, scaleTweenTime))
            .OnComplete(() => OnTweenComplete.Invoke());

        BeginTween.Play();

    }
}