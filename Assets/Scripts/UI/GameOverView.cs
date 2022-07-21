using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Damageble _player;
    [SerializeField] private GameObject _gameoverScreen;
    [SerializeField] private GameObject _scrollView;

    private void OnEnable()
    {
        _player.Died += () =>
        {
            ShowEndGameScreen();
        };
    }

    private void OnDisable()
    {
        _player.Died -= () =>
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
