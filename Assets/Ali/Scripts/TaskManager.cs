using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
     public TextMeshProUGUI openCurtainsTask;
    public TextMeshProUGUI takeMedicineTask;
    public TextMeshProUGUI turnOnLightTask;

    private bool curtainsOpened = false;
    private bool medicineTaken = false;
    private bool lightTurnedOn = false;

    void Start()
    {
        UpdateTaskList();
    }

    void UpdateTaskList()
    {
        openCurtainsTask.text = curtainsOpened ? "✔ Open Curtains" : "Open Curtains";
        takeMedicineTask.text = medicineTaken ? "✔ Take Medicine" : "Take Medicine";
        turnOnLightTask.text = lightTurnedOn ? "✔ Turn On Light" : "Turn On Light";
    }

    public void CompleteTask(TaskType taskType)
    {
        switch(taskType)
        {
            case TaskType.OpenCurtains:
                curtainsOpened = true;
                break;
            case TaskType.TakeMedicine:
                medicineTaken = true;
                break;
            case TaskType.TurnOnLight:
                lightTurnedOn = true;
                break;
        }
        UpdateTaskList();
    }
}

public enum TaskType
{
    OpenCurtains,
    TakeMedicine,
    TurnOnLight
}

