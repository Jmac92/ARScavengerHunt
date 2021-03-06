﻿using UnityEngine;
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
        instance.name = GameManager.Instance.CurrentItemId;

        Collectible collectible = GameManager.Instance.GetCourseItem(GameManager.Instance.CurrentItemId);

        var locationString = collectible.LatLong;
        _location = Conversions.StringToLatLon(locationString);

        if (collectible != null)
        {
            _spawnedObject = instance;
        }
    }

    private void Update()
    {
        if (_spawnedObject != null)
        {
            _spawnedObject.name = GameManager.Instance.CurrentItemId;
            _spawnedObject.transform.SetParent(_mapGameObject.transform);
            _spawnedObject.transform.localPosition = _map.GeoToWorldPosition(_location, true);
            _spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
        }
    }
}
