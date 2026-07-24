using UnityEngine;

public class ButtonTarget : MonoBehaviour
{
    [Header("Functions")]
    [SerializeField] private bool doesWinGame = false;
    [SerializeField] private bool doesDissapear = false;
    [SerializeField] private bool doesEffectTime = false;
    [Header("Additional Settings")]
    [SerializeField] private float timeEffectAmount = 1f;

    public void ActivateTarget()
    {
        if(doesWinGame)
        {
            Debug.Log("You win!");
            // Implement win game logic here
        }
        if(doesDissapear)
        {
            gameObject.SetActive(gameObject.activeSelf ? false : true);
        }
        if(doesEffectTime)
        {
            //Implement time effect logic here, e.g., slowing down or speeding up time
        }
    }
}
