using UnityEngine;

public class StickmanDiedHandler : MonoBehaviour
{
    [SerializeField] private GameObject _pointer;

    private Damageble _stickman;

    private void Start()
    {
        _stickman = GetComponent<Damageble>();
    }

    private void OnEnable()
    {
        _stickman.Died += () =>
        {
            DeactivateStickman();
        };
    }

    private void OnDisable()
    {
        _stickman.Died -= () =>
        {
            DeactivateStickman();
        };
    }

    private void DeactivateStickman()
    {
        _stickman.gameObject.SetActive(false);
        _pointer.SetActive(false);
    }

}
