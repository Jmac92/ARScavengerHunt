﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Mapbox.Unity.Map;
using Mapbox.Utils;
using Mapbox.Unity.Utilities;

public class AROverviewMap : MonoBehaviour {
	[SerializeField]
	AbstractMap _map;

	[SerializeField]
	GameObject _markerPrefab;

    [SerializeField]
    GameObject _playerPrefab;

	Vector2d[] _locations;

    string[] _locationStrings;

	List<GameObject> _spawnedObjects;

    GameObject _playerInstance;

	// Use this for initialization
	void Start () {
		_locations = Transitions.locations;
        _locationStrings = Transitions.locationStrings;
        
		_spawnedObjects = new List<GameObject>();
        for (int i = 0; i < _locations.Length; i++) {   
            GameObject instance = Instantiate(_markerPrefab);
            instance.name = _locationStrings[i];
            instance.transform.SetParent(_map.transform);

            _spawnedObjects.Add(instance);
        }

        _playerInstance = Instantiate(_playerPrefab);
        _playerInstance.transform.SetParent(_map.transform);

        _map.Initialize(CalculateCentroid(_locations), 16);
        _map.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if (_spawnedObjects != null && _map.gameObject.activeSelf) {
            int count = _spawnedObjects.Count;
            for (int i = 0; i < count; i++)
            {
                var spawnedObject = _spawnedObjects[i];
                var location = _locations[i];
                if (!GameManager.Instance.HasItemBeenCollected(spawnedObject.name))
                    spawnedObject.transform.localPosition = Conversions.GeoToWorldPosition(location, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
            }

            _playerInstance.transform.localPosition = Conversions.GeoToWorldPosition(Transitions.playerPosition, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
        }
	}

	private Vector2d CalculateCentroid (Vector2d[] points) {
        Vector2d centroid = Vector2d.zero;
        var numPoints = points.Length;

        foreach(Vector2d point in points) {
            centroid += point;
        }

        centroid /= numPoints;

        return centroid;
    }
}
