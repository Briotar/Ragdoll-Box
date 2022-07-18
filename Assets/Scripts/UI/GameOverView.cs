using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private GameObject _gameoverScreen;
    [SerializeField] private GameObject _scrollView;

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
        _scrollView.SetActive(false);
        _gameoverScreen.SetActive(true);
    }
}
