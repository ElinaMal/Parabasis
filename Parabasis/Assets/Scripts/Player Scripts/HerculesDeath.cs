using UnityEngine;
using UnityEngine.SceneManagement;

public class HerculesDeath : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
        SceneManager.LoadSceneAsync(4);
    }
}
