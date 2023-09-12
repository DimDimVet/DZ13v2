using Unity.Mathematics;
using UnityEngine;
using Zenject;

public class AnimPlayer : MonoBehaviour
{
    [Inject] private IUserInput userInput;//получим данные в структуре

    //anim
    private float speed;
    private string animSpeed;
    private string animJamp;
    private string animDead;

    private Animator animator;
    public AnimSettings AnimSettings;

    private float refDistance = 0.01f;
    private float2 distans;

    void Start()
    {
        animator=gameObject.GetComponent<Animator>();

        speed = AnimSettings.Speed;
        animSpeed = AnimSettings.AnimSpeed;
        animJamp = AnimSettings.AnimJamp;
        animDead = AnimSettings.AnimDead;
    }

    void Update()
    {
        if (animator != null)
        {
            distans.x = Mathf.Abs(userInput.InputData.Move.x);
            distans.y = Mathf.Abs(userInput.InputData.Move.y);

            if (distans.x >= refDistance | distans.y >= refDistance)
            {
                animator.SetFloat(animSpeed, speed * math.distancesq(distans.x, -distans.y));
            }
            else
            {
                animator.SetFloat(animSpeed, 0);
            }

            //pull
            //реакция на изменеия, запустим анимацию 
            if (userInput.InputData.Pull > 0f)
            {
                animator.SetBool(animJamp, true);
            }
            else
            {
                animator.SetBool(animJamp, false);
            }

            ////dead
            //if (healt.Dead)
            //{
            //    animator.SetBool(AnimDead, true);
            //}
        }
        else
        {
            Debug.LogError("Нет компонента Аниматор");
        }

    }
}
