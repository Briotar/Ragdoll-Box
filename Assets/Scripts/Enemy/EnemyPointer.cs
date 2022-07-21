using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    [SerializeField] private Damageble _stickman;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _pointerIcon;
    [SerializeField] private float _distanceToScreenEdge = 1f;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnEnable()
    {
        _stickman.Died += () =>
        {
            DeactivatePointer();
        };
    }

    private void OnDisable()
    {
        _stickman.Died -= () =>
        {
            DeactivatePointer();
        };
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
    }

    private void DeactivatePointer()
    {
        _pointerIcon.gameObject.SetActive(false);
    }
}
