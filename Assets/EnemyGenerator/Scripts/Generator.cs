using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] private GameObject _generatedObject;

    [SerializeField] private GameObject _firstGenerator;
    [SerializeField] private GameObject _secondGenerator;
    [SerializeField] private GameObject _thirdGenerator;

    private float _secondCount;

    private void Start()
    {
        _secondCount = 0;
    }

    private void Update()
    {
        int second = Mathf.FloorToInt(Time.time);
        int necessarySecondsNumber = 2;

        int firstPointIndex = 1;
        int secondPointIndex = 2;
        int thirdPointIndex = 3;

        int minimalPointNumber = 1;
        int maximalPointNumber = 4;

        if (second > _secondCount)
        {
            Debug.Log(second);
            _secondCount++;

            if (second % necessarySecondsNumber == 0)
            {
                int index = Random.Range(minimalPointNumber, maximalPointNumber);

                if (index == firstPointIndex)
                {
                    GenerateEnemy(_firstGenerator);
                }
                else if (index == secondPointIndex)
                {
                    GenerateEnemy(_secondGenerator);
                }
                else if (index == thirdPointIndex)
                {
                    GenerateEnemy(_thirdGenerator);
                }
            }
        }
    }

    private void GenerateEnemy(GameObject gameObject)
    {
        GameObject enemy = Instantiate(_generatedObject, gameObject.transform.position, Quaternion.identity);
        enemy.AddComponent<Move>();
    }
}
