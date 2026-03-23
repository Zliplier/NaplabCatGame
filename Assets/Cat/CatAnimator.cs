using System;
using DG.Tweening;
using Player;
using UnityEngine;

namespace Cat
{
    public class CatAnimator : MonoBehaviour
    {
        //Sprite Animator
        [SerializeField] private Animator animator;
        
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
        
        public void PlaySpriteAnimation(string animationID) => animator.Play(animationID);

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