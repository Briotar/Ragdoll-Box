using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Damageble _player;
    [SerializeField] private CameraFollower _camera;

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
        _camera.enabled = false;
    }
}
