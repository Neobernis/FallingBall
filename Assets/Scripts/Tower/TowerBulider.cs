using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulider : MonoBehaviour
{
    [SerializeField] private float _levelCount;
    [SerializeField] private float _additionalScale;
    [SerializeField] private GameObject _beam;
    [SerializeField] private Platforms _spawnPlatform;
    [SerializeField] private FinishPlatform _finishPlatform;
    [SerializeField] private Platforms[] _platforms;
 

    private float _startAndFinishAdditionalScale = 0.5f;
    public float beamStartY => _levelCount /2f + _startAndFinishAdditionalScale + _additionalScale/2f;

   
    private void Awake ()
    {
        Build();
    }

    private void Build()
    {
        GameObject beam = Instantiate(_beam, transform);
        beam.transform.localScale = new Vector3(1, beamStartY, 1);
        

        Vector3 spawnPosition = beam.transform.position;
        spawnPosition.y += beam.transform.localScale.y - _additionalScale;


        SpawnPlatform(_spawnPlatform, ref spawnPosition, beam.transform);

        for (int i = 0; i < _levelCount; i++)
        {
           SpawnPlatform(_platforms[Random.Range(0, _platforms.Length)], ref spawnPosition, beam.transform);
        }

        SpawnPlatform(_finishPlatform, ref spawnPosition, beam.transform);

    }
    private void SpawnPlatform(Platforms platform, ref Vector3 spawnPosition, Transform parent)
{
        Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
       //platform.transform.localScale.y = 0.1f;
        spawnPosition.y -= 1;
}
}
