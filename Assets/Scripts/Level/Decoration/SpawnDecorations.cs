//Класс создает случайно расположенные случайные декорации.

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Level.Decoration
{
    public class SpawnDecorations : MonoBehaviour
    {
        public static SpawnDecorations instance;

        public GameObject decorationPrefab;    // Префаб декорации
        public Vector3[] points;    // 2 точки, образующие рамки, в которых будут созданы декорации.
        public float[] additionalPoints;    // Дополнительные точки, отвечающие за номер отображения слоя декорации
        public int[] layers;    // Глубина спрайтов
        [FormerlySerializedAs("numberOfDecorations")] [Range(2, 100)]
        public int decorationDensity;    // Плотность спавна декораций
        public float randomMaxThreshold;    // Максимальное отклонение от сетки установки декорации

        //Функция создает декорации. Принимает список создаваемых декораций
        public void Spawn(List<Sprite> decorations)
        {
            if (decorations.Count == 0)
                throw new ArgumentException("Value cannot be an empty collection.", nameof(decorations));

            float height = points[0].y;
            float xSize = points[1].x - points[0].x;
            float zSize = points[1].z - points[0].z;
            float decorationSize = (xSize) * (zSize) / decorationDensity;
            if (points[0].x >= points[1].x || points[0].z >= points[1].z)
            {
                throw new ArgumentException("First point must coordinates less, than second", nameof(decorations));
            }
            for (float xCoord = points[0].x; xCoord < points[1].x; xCoord += xSize / decorationDensity)
            {
                for (float zCoord = points[0].z; zCoord < points[1].z; zCoord += zSize / decorationDensity)
                {
                    Vector3 spawnPoint = new Vector3(xCoord, height, zCoord);
                    spawnPoint.x += Random.Range(-randomMaxThreshold, randomMaxThreshold);
                    spawnPoint.z += Random.Range(-randomMaxThreshold, randomMaxThreshold);
                    Sprite decorationSprite = decorations[Random.Range(0, decorations.Count)];
                    AddGameObject(spawnPoint, decorationSprite);
                }
            }
        }

        // Функция добавляет одну декорацию в указанную точку
        private void AddGameObject(Vector3 point, Sprite decorationSprite)
        {
            SpriteRenderer newSprite = Instantiate(decorationPrefab, point, Quaternion.identity)
                .GetComponent<SpriteRenderer>();
            newSprite.sprite = decorationSprite;

            for (int i = 0; i < layers.Length; i++)
            {
                if (point.z >= additionalPoints[i])
                {
                    newSprite.sortingOrder = layers[i];
                    break;
                }
            }

            newSprite.color = GetRandomColor();
        }

        // Функция случайным образом устанавливает яркость цвета декорации
        static Color GetRandomColor()
        {
            var newc = Random.Range(200, 255);
            return new Color(newc, newc, newc);
        }
        
        // Функция срабатывает при запуске сценария илм при изменении поля в инспекторе
        private void OnValidate()
        {
            int pointsSize = additionalPoints.Length;
            if (pointsSize != layers.Length)
            {
                Debug.LogWarning("SpawnDecorations: AdditionalPoints and layers must be same array size!");
                Array.Resize(ref layers, pointsSize);
            }
        }
    }
}
