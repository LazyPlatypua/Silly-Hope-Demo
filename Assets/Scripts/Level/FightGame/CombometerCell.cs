using System.Collections.Generic;
using UnityEngine;

namespace Level.FightGame
{
    public struct CombometerCell
    {
        private bool isFull;
        private List<bool> combometerPoints;

        public CombometerCell(int neededPoints)
        {
            isFull = false;
            combometerPoints = new List<bool>();
            for (var index = 0; index < neededPoints; index++)
            {
                combometerPoints.Add(false);
            }
        }

        public bool IsFull()
        {
            return isFull;
        }

        public bool AddPoint()
        {
            for (var index = 0; index < combometerPoints.Count; index++)
            {
                if (!combometerPoints[index])
                {
                    combometerPoints[index] = true;
                    Debug.Log($"CombometerCell.AddPoint(): Combometer Cell point {index} is added");
                    return false;
                }
            }
            DeletePoints();
            isFull = true;
            return true;
        }

        private void DeletePoints()
        {
            Debug.Log($"CombometerCell.DeletePoints(): Clearing cell points");
            for (var index = 0; index < combometerPoints.Count; index++)
            {
                combometerPoints[index] = false;
            }
        }

        public void SetFalse()
        {
            Debug.Log($"CombometerCell.SetFalse()");
            isFull = false;
        }
    }
}
