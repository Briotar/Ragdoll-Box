using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _pointerIcon;
    [SerializeField] private float _distanceToScreenEdge = 1f;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector3 fromPlayerToEnemy = transform.position - _player.position;
        Ray ray = new Ray(_player.position, fromPlayerToEnemy);
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

        float minDistance = Mathf.Infinity;
        int index = 0;

        for (int i = 0; i < 4; i++)
        {
            if(planes[i].Raycast(ray, out float distance))
            {
                if (distance < minDistance)
                {
                    minDistance = distance;
                    index = i;
                }
            }
        }

        if(fromPlayerToEnemy.magnitude < minDistance)
            _pointerIcon.gameObject.SetActive(false);
        else
            _pointerIcon.gameObject.SetActive(true);

        Vector3 worldPostion = ray.GetPoint(minDistance - _distanceToScreenEdge);

        _pointerIcon.position = _camera.WorldToScreenPoint(worldPostion);
        //RotatePointer(index);
    }

    private void RotatePointer(int index)
    {
        switch(index)
        {
            case 0:
                _pointerIcon.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;
            case 1:
                _pointerIcon.rotation = Quaternion.Euler(0f, 0f, -90f);
                break;
            case 2:
                _pointerIcon.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;
            case 3:
                _pointerIcon.rotation = Quaternion.Euler(0f, 0f, 0f);
                break;
            default:
                _pointerIcon.rotation = Quaternion.identity;
                break;
        }
    }
}
