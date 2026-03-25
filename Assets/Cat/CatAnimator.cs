using System;
using System.Collections;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Cat
{
    public class CatAnimator : MonoBehaviour
    {
        //Sprite Animator
        [SerializeField] private Animator animator;
        private Coroutine co_Animator;
        public bool isSpriteAnimation => co_Animator != null;
        
        //Sprite Animation Id
        public static string CATDIRECTION_FRONT_ID = "CatFront";
        public static string CATDIRECTION_RIGHT_ID = "CatRight";
        public static string CATDIRECTION_BACK_ID = "CatBack";
        public static string CATDIRECTION_LEFT_ID = "CatLeft";
        
        //Tween Animator
        private Tween tw_Animator = null;
        public bool isTweenAnimation => tw_Animator != null;

        private void Start()
        {
            PlayTweenAnimation(TwBobing());
        }
        
        public void PlaySpriteStateAnimation(string animationID)
        {
            animator.Play(animationID);
        }

        public void PlaySpriteAnimationOnce(string returnAnimationId, string animationID, float animationLength)
        {
            if (isSpriteAnimation)
                co_Animator = null;
            
            animator.Play(animationID);
            co_Animator = StartCoroutine(PlayingSpriteAnimation(returnAnimationId, animationLength));
        }

        public IEnumerator PlayingSpriteAnimation(string returnAnimationId, float animationLength)
        {
            yield return new WaitForSeconds(animationLength);
            animator.Play(returnAnimationId);
            
            co_Animator = null;
        }
        
        public void PlayTweenAnimation(Tween animation)
        {
            if (isTweenAnimation)
            {
                tw_Animator.Kill();
                tw_Animator = null;
            }
            
            tw_Animator = animation;
            tw_Animator.onComplete += () =>
            {
                tw_Animator.Kill();
                tw_Animator = null;
            };
        }

        public Tween TwBobing()
        {
            Tween animation = transform.DOScale(new Vector3(1.01f, 1.05f, 1.01f), 0.5f);
            animation.SetLoops(-1, LoopType.Yoyo);
            return animation;
        }
    }
}