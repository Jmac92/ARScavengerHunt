using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;
using System;

public class SpawnOnARMap : MonoBehaviour
{
    [SerializeField]
    GameObject _mapGameObject;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    Vector2d _location;

    [SerializeField]
    float _spawnScale = 0.1f;

    [SerializeField]
    GameObject _markerPrefab;

    private GameObject _spawnedObject;

    void Awake()
    {
        GameObject instance = Instantiate(_markerPrefab);

        Collectible collectible = GameManager.Instance.GetCourseItem(Convert.ToInt32(instance.name));

        var locationString = collectible.LatLong;
        _location = Conversions.StringToLatLon(locationString);

        instance.transform.SetParent(_mapGameObject.transform);
        instance.transform.localPosition = _map.GeoToWorldPosition(_location, true);
        instance.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        instance.name = GameManager.Instance.CurrentItemId.ToString();

        

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
