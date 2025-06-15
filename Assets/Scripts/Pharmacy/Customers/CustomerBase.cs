using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class CustomerBase : ScriptableObject
{
    public enum DoseRate
    {
        Daily,
        Weekly,
        Biweekly,
        Bidaily,
        TwiceDaily,
        AsNeeded
    }

    [System.Serializable]
    public struct DoseTime
    {
        public int hour;
        public int minute;
        public bool am;
    }

    [System.Serializable]
    public struct Order
    {
        public string drugName;
        public float dosage;
        public DoseTime doseTime;
        public DoseRate dosageRate;
    }

    public string idName;
    public Sprite characterSprite;
    public Sprite IDPhoto;
    public int age;
    public char gender;
    public Order[] order;

}
