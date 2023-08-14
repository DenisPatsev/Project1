using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private Enemy _generatedObject;

    GameObject[] _generators;

    private float _secondCount;

    private int minimalPointNumber;
    private int maximalPointNumber;

    private bool _isWorking;

    private void Start()
    {
        _generators = GameObject.FindGameObjectsWithTag("Spawner");

        minimalPointNumber = 0;
        maximalPointNumber = _generators.Length;

        _isWorking = true;

        var coroutine = StartCoroutine(Generate(2f));

        _secondCount = 0;
    }

    private void Update()
    {
        int second = Mathf.FloorToInt(Time.time);

        if (second > _secondCount)
        {
            Debug.Log(second);
            _secondCount++;
        }
    }

    private IEnumerator Generate(float secondsNumber)
    {
        var wait = new WaitForSeconds(secondsNumber);

        while (_isWorking)
        {
            int index = Random.Range(minimalPointNumber, maximalPointNumber);

            for (int i = 0; i < _generators.Length; i++)
            {
                if (i == index)
                {
                    GenerateEnemy(_generators[i]);
                }
            }

            yield return wait;
        }
    }

    private void GenerateEnemy(GameObject gameObject)
    {
        var enemy = Instantiate(_generatedObject, gameObject.transform.position, Quaternion.identity);
        enemy.gameObject.AddComponent<Move>();
    }
}
