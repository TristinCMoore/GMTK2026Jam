using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Button Settings")]
    [SerializeField] private int pressesRequired = 1;
    [SerializeField] private Sprite _offSprite;
    [SerializeField] private Sprite _onSprite;
    [SerializeField] private GameObject[] _objectsToToggle;
    [SerializeField] private AudioClip _buttonPressSound;
    [SerializeField] private bool canBeTurnedBackOff = false;
    // Private variables
    private int currentPresses = 0;
    private SpriteRenderer _spriteRenderer;
    private bool isPressed = false;
    private AudioSource _audioSource;


    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
    }

    

    public void buttonPressed()
    {
        Debug.Log("Button pressed! Current presses: " + currentPresses);
        if (isPressed && !canBeTurnedBackOff)
            return;

        currentPresses++;
        _audioSource.PlayOneShot(_buttonPressSound);

        if (currentPresses >= pressesRequired)
        {
            if(!isPressed)
            {
                isPressed = true;
                _spriteRenderer.sprite = _onSprite;
                currentPresses = 0;
            }
            else
            {
                isPressed = false;
                _spriteRenderer.sprite = _offSprite;
                currentPresses = 0;
            }
            // Toggle the objects
            foreach (GameObject obj in _objectsToToggle)
            {
                obj.GetComponent<ButtonTarget>().ActivateTarget();
            }
        }
    }
}
