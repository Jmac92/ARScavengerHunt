using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;

public class SpawnOnARMap : MonoBehaviour
{
    [SerializeField]
    GameObject _mapGameObject;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    Vector2d _location;

    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    GameObject _markerPrefab;

    private GameObject _spawnedObject;

    void Awake()
    {

        Collectible collectible = GameManager.Instance.GetCourseItem(GameManager.Instance.CurrentItemId);

        var locationString = collectible.LatLong;
        _location = Conversions.StringToLatLon(locationString);

        GameObject instance = Instantiate(_markerPrefab);
        instance.transform.SetParent(_mapGameObject.transform);
        instance.transform.localPosition = _map.GeoToWorldPosition(_location, true);
        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        instance.transform.rotation *= Quaternion.Euler(0f, 0f, 180f);

        if (collectible != null)
        {
            _spawnedObject = instance;
        }
    }

    private void Update()
    {
        if (_spawnedObject != null)
        {
            _spawnedObject.transform.localPosition = _map.GeoToWorldPosition(_location, true);
            _spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
            var pos = _spawnedObject.transform.localPosition;
            _spawnedObject.transform.localPosition = pos;
        }
    }
}
