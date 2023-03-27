using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    public Animator anim;
    int vertical;
    int horizontal;

    public bool canRotate;

    public void Init()
    {
        anim = GetComponent<Animator>();

        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Hozizontal");
    }

    public void UpdateAnimatorValues(float verticalMove, float horizontalMove) 
    {
        #region Vertical
        float v = 0;

        if (verticalMove > 0 && verticalMove < 0.55f) v = 0.5f;
        else if (verticalMove > 0.55f) v = 1f;
        else if (verticalMove < 0 && verticalMove > -0.55f) v = -0.5f;
        else if (verticalMove < -0.55f) v = -1;
        else v = 0;
        #endregion

        #region Horizontal
        float h = 0;

        if (horizontalMove > 0 && horizontalMove < 0.55f) h = 0.5f;
        else if (horizontalMove > 0.55f) h = 1f;
        else if (horizontalMove < 0 && horizontalMove > -0.55f) h = -0.5f;
        else if (horizontalMove < -0.55f) h = -1;
        else h = 0;
        #endregion

        anim.SetFloat( vertical, v, 0.1f, Time.deltaTime);
        anim.SetFloat( horizontal, h, 0.1f, Time.deltaTime);

    }

    public void CanRotation()
    {
        canRotate = true;
    }

    public void StopRotation()
    {
        canRotate = false;
    }
}
