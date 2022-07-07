using UnityEngine;

public class EndGameHandler : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private CameraFollower _camera;

    private void OnEnable()
    {
        _player.OnDied += () =>
        {
            EndGame();
        };
    }

    private void OnDisable()
    {
        _player.OnDied -= () =>
        {
            EndGame();
        };
    }

    private void EndGame()
    {
        _camera.enabled = false;
    }
}
