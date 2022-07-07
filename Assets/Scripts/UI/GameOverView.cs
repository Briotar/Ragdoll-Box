using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _text;

    private void OnEnable()
    {
        _player.OnDied += () =>
        {
            ShowEndGameScreen();
        };
    }

    private void OnDisable()
    {
        _player.OnDied -= () =>
        {
            ShowEndGameScreen();
        };
    }

    private void ShowEndGameScreen()
    {
        _text.SetActive(true);
    }
}
