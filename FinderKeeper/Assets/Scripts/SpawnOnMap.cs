using UnityEngine;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.MeshGeneration.Factories;
using Mapbox.Unity.Utilities;
using System.Collections.Generic;

public class SpawnOnMap : MonoBehaviour
{
    [SerializeField]
    GameObject _mapGameObject;

    [SerializeField]
    AbstractMap _map;

    [SerializeField]
    [Geocode]
    public string[] _locationStrings;
    Vector2d[] _locations;

    [SerializeField]
    float _spawnScale = 100f;

    [SerializeField]
    GameObject _markerPrefab;

    List<GameObject> _spawnedObjects;

    void Start()
    {
        _locations = new Vector2d[_locationStrings.Length];
        _spawnedObjects = new List<GameObject>();

        for (int i = 0; i < _locationStrings.Length; i++)
        {
            var locationString = _locationStrings[i];
            _locations[i] = Conversions.StringToLatLon(locationString);
            
            GameObject instance = Instantiate(_markerPrefab);
            instance.name = locationString;
            instance.transform.SetParent(_mapGameObject.transform);

            Collectible collectible = instance.GetComponent<Collectible>();
            collectible.Id = locationString;

            collectible.LatLong = locationString;
            if(collectible != null)
                _spawnedObjects.Add(instance);

            if (!GameManager.Instance.GetCourseItems().Contains(collectible))
                GameManager.Instance.AddCourseItem(collectible);
        }
    }

    private void Update()
    {
        int count = _spawnedObjects.Count;
        for (int i = 0; i < count; i++)
        {
            var spawnedObject = _spawnedObjects[i];
            if (spawnedObject != null)
            {
                var location = Conversions.StringToLatLon(spawnedObject.name);
                if (!GameManager.Instance.HasItemBeenCollected(spawnedObject.name))
                {
                    spawnedObject.transform.localPosition = _map.GeoToWorldPosition(location, true);
                    spawnedObject.transform.localScale = new Vector3(_spawnScale, _spawnScale, _spawnScale);
                    var pos = spawnedObject.transform.localPosition;
                    pos.y = 5;
                    spawnedObject.transform.localPosition = pos;
                }
            }
        }
    }
}
