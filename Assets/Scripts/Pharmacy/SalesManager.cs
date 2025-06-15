using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SalesManager : MonoBehaviour
{
    [Header("UI and sprites that need to be filled in on card + line")]
    [SerializeField] private Image idPhoto;
    [SerializeField] private TextMeshProUGUI idName;
    [SerializeField] private TextMeshProUGUI idGender;
    [SerializeField] private TextMeshProUGUI idAge;
    [SerializeField] private TextMeshProUGUI[] idPerscriptions; //Current max is 3, should be greater than maximum num perscriptions owned by one customer
    [SerializeField] private SpriteRenderer customer;

    [Header("Customers")]
    [SerializeField] private CustomerBase[] allCustomers;
    public Queue<CustomerBase> currentLine;
    int numTotalCustomers;

    private void Start()
    {
        currentLine = new Queue<CustomerBase>();
        numTotalCustomers = allCustomers.Length;
        //Testing
        List<int> _lineIdx = new List<int>();
        // CreateLine(_lineIdx, 2);
        int[] arr = new int[numTotalCustomers];
        for (int i = 0; i < numTotalCustomers; i++)
            arr[i] = i;

        CreateLinePt2(arr, 3);
        FillInInfo(currentLine.Dequeue());
    }

    private void Update()
    {
        //Testing
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(currentLine.Peek() != null)
                FillInInfo(currentLine.Dequeue());
            
        }
    }

    /// <summary>
    /// Fill in card info and character sprite for character at front of line
    /// </summary>
    /// <param name="_customer">Customer information to be displayed</param>
    public void FillInInfo(CustomerBase _customer)
    {
        idPhoto.sprite = _customer.IDPhoto;
        idName.text = _customer.idName;
        idGender.text = _customer.gender.ToString();
        idAge.text = _customer.age.ToString();

        int _numPersc = _customer.order.Length;

        for(int i = 0; i < _numPersc; i++)
        {
            string amPm = "";
            if(_customer.order[i].doseTime.am)
            {
                amPm = "AM";
            }
            else
            {
                amPm = "PM";
            }
            string _fullPercInfo = _customer.order[i].drugName.ToString() + " " + _customer.order[i].dosage.ToString() + "mg " + _customer.order[i].doseTime.hour.ToString() + ":" + _customer.order[i].doseTime.minute.ToString() + amPm + " " + _customer.order[i].dosageRate.ToString();
            idPerscriptions[i].text = _fullPercInfo;
        }

        customer.sprite = _customer.characterSprite;
    } //END FillInInfo()


   

    /// <summary>
    /// Fill in card info and character sprite for character at front of line
    /// </summary>
    void CreateLinePt2(int[] arr, int n) //Causing allocation error but seems to work, may cause issues in build though
    {
        int[] output = new int[n];  
        int[] visited = new int[n]; 
                                   
        for (int i = 0; i < n; i++)
        {
            visited[i] = 0;
        }
        // Perform the shuffle algorithm
        for (int i = 0; i < n; i++)
        {
            System.Random rand = new System.Random();
            int j = rand.Next() % n; 
            while (visited[j] == 1)
            { 
                j = rand.Next() % n;
            }
            output[i] = arr[j]; 
            visited[j] = 1;     
        }
        
        for (int i = 0; i < n; i++)
        {
            arr[i] = output[i];
            currentLine.Enqueue(allCustomers[arr[i]]);
            Debug.Log("Put in line " + allCustomers[arr[i]]);
        }
    } //END CreatelinePt2()

}
