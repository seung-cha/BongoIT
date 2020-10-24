using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveEditor : MonoBehaviour
{
    public void OnLeaveClick()
    {
        SceneChanger.SceneProcessor.ChangeScene(0);
    }
}
