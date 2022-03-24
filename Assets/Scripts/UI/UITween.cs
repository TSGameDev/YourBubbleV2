using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using System.Threading.Tasks;

namespace TSGameDev.UI
{
    public class UITween : MonoBehaviour
    {
        #region Private Variables

        [Header("Start Values")]
        [Space(10)]
        [Tooltip("The position for this gameobject to start from aka its disappearing tween location")]
        [SerializeField] GameObject startPos;
        [Tooltip("The rotation for this gameobject to start from aka its disapparing tween rotation")]
        [SerializeField] Quaternion startRot = new Quaternion(0, 0, 0, 0);
        [Tooltip("The scale for this gameobject to start from aka its disapparing tween scale")]
        [SerializeField] Vector3 startScale = new Vector3(1, 1, 1);

        [Header("Tween Values")]
        [Space(10)]
        [Tooltip("The position for the object ot tween to aka its visible tween location")]
        [SerializeField] GameObject tweenLocation;
        [Tooltip("The rotation for the object to tween to aka its visible tween rotation")]
        [SerializeField] Quaternion tweenRotation = new Quaternion(0, 0, 0, 0);
        [Tooltip("The scale for the object to tween to aka its visible tween scale")]
        [SerializeField] Vector3 tweenScale = new Vector3(1, 1, 1);

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

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public async void BeginTween()
        {
            if (tweenLocation != null)
            {
                Sequence ReadyingSeq = DOTween.Sequence();
                ReadyingSeq.Join(transform.DOMove(startPos.transform.position, 0))
                .Join(transform.DORotateQuaternion(startRot, 0))
                .Join(transform.DOScale(startScale, 0));

                await ReadyingSeq.AsyncWaitForCompletion();
                gameObject.SetActive(true);

                Sequence tweenSeq = DOTween.Sequence();
                tweenSeq.Join(transform.DOMove(tweenLocation.transform.position, moveTweenTime))
                .Join(transform.DORotateQuaternion(tweenRotation, rotationTweenTime))
                .Join(transform.DOScale(tweenScale, scaleTweenTime))
                .OnComplete(() => OnTweenComplete.Invoke());

                await Task.Yield();
            }
            else
            {
                Sequence ReadyingSeq = DOTween.Sequence();
                ReadyingSeq.Join(transform.DORotateQuaternion(startRot, 0))
                .Join(transform.DOScale(startScale, 0));
                ReadyingSeq.Play();

                await ReadyingSeq.AsyncWaitForCompletion();
                gameObject.SetActive(true);

                Sequence tweenSeq = DOTween.Sequence();
                tweenSeq.Join(transform.DORotateQuaternion(tweenRotation, rotationTweenTime))
                .Join(transform.DOScale(tweenScale, scaleTweenTime))
                .OnComplete(() => OnTweenComplete.Invoke());

                await Task.Yield();
            }
        }

        public async void ReturnTween()
        {

            if (startPos != null)
            {
                Sequence ReadyingSeq = DOTween.Sequence();
                ReadyingSeq.Join(transform.DOMove(tweenLocation.transform.position, 0))
                .Join(transform.DORotateQuaternion(tweenRotation, 0))
                .Join(transform.DOScale(tweenScale, 0));

                await ReadyingSeq.AsyncWaitForCompletion();

                Sequence tweenSeq = DOTween.Sequence();
                tweenSeq.Join(transform.DOMove(startPos.transform.position, moveTweenTime))
                .Join(transform.DORotateQuaternion(startRot, rotationTweenTime))
                .Join(transform.DOScale(startScale, scaleTweenTime))
                .OnComplete(() => OnTweenReturn.Invoke());

                await tweenSeq.AsyncWaitForCompletion();

                gameObject.SetActive(false);

                await Task.Yield();
            }
            else
            {
                Sequence ReadyingSeq = DOTween.Sequence();
                ReadyingSeq.Join(transform.DORotateQuaternion(tweenRotation, 0))
                .Join(transform.DOScale(tweenScale, 0));
                ReadyingSeq.Play();

                await ReadyingSeq.AsyncWaitForCompletion();

                Sequence tweenSeq = DOTween.Sequence();
                tweenSeq.Join(transform.DORotateQuaternion(startRot, rotationTweenTime))
                .Join(transform.DOScale(startScale, scaleTweenTime))
                .OnComplete(() => OnTweenReturn.Invoke());

                await tweenSeq.AsyncWaitForCompletion();

                gameObject.SetActive(false);

                await Task.Yield();
            }
        }

    }
}