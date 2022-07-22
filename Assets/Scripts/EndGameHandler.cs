using System.Collections;
using UnityEngine;
using Cinemachine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Damageble _player;
    [SerializeField] private CinemachineVirtualCamera _camera;

    private float _fieldOfView = 35f;
    private float _lerpSpeed = 3f;

    private void OnEnable()
    {
        _player.Died += () =>
        {
            EndGame();
        };
    }

    private void OnDisable()
    {
        _player.Died -= () =>
        {
            EndGame();
        };
    }

    private void EndGame()
    {
        _camera.Follow = null;

        StartCoroutine(FieldOFViewLerp());
    }

    private IEnumerator FieldOFViewLerp()
    {
        while(_camera.m_Lens.FieldOfView != _fieldOfView)
        {
            _camera.m_Lens.FieldOfView = Mathf.Lerp(_camera.m_Lens.FieldOfView, _fieldOfView, Time.deltaTime * _lerpSpeed);

            yield return new WaitForEndOfFrame();
        }
    }
}
