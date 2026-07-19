using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    [SerializeField] Animator animator;

    
    void Update()
    {
        if ( Input.GetAxis ( "Horizontal" ) > 0.0 )
        {
            animator.SetFloat ( "walk", Input.GetAxis ( "Horizontal" ) );
        }    
    }
}
