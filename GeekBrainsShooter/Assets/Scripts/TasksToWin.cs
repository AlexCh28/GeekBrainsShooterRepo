using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TasksToWin : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI task1;
    [SerializeField] 
    private TextMeshProUGUI task2;

    public void RedrawTask1(int value){
        task1.text = "Defeat " + value + " enemies";
        if (value == 0){
            task1.color = Color.grey;
            task1.fontStyle = FontStyles.Strikethrough;
        }   
    }

    public void RedrawTask2(int value){
        task2.text = "Jump " + value + " times";
        if (value == 0){
            task2.color = Color.grey;
            task2.fontStyle = FontStyles.Strikethrough;
        }  
    }
}
