using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarPlacer : MonoBehaviour
{
    [SerializeField] private HPBarView[] _hpBar;
    [SerializeField] private float[] _hpBarCoodinate;

    private void Awake()
    {
        _hpBar = GetComponentsInChildren<HPBarView>();
        _hpBarCoodinate = new float[_hpBar.Length];

        for (int i = 0; i < _hpBar.Length; i++)
        {
            _hpBarCoodinate[i] = _hpBar[i].transform.localPosition.y;
            _hpBar[i].SetIndex(i);
        }
    }

    private void OnEnable()
    {
        for (int i = 0; i < _hpBar.Length; i++)
        {
            _hpBar[i].StickmanDied += (int index) =>
            {
                OnStickmanDied(index);
            };
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _hpBar.Length; i++)
        {
            _hpBar[i].StickmanDied -= (int index) =>
            {
                OnStickmanDied(index);
            };
        }
    }

    private void OnStickmanDied(int index)
    {
        for (int i = index; i < _hpBar.Length - 1; i++)
        {
            _hpBar[i + 1].transform.localPosition = new Vector2(_hpBar[i + 1].transform.localPosition.x, _hpBarCoodinate[i]);
        }
    }

}
