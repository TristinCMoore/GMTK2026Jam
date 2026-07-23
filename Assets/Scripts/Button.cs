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
}
