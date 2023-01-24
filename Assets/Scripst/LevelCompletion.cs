using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletion : MonoBehaviour
{
    [SerializeField] float timeToCompleteLevel;

    StageTime stageTime;
    PauseManager pauseManager;

    [SerializeField] GameWinPannel levelCompletePannel;
    private void Awake()
    {
        stageTime = GetComponent<StageTime>();
        pauseManager = FindObjectOfType<PauseManager>();
        levelCompletePannel = FindObjectOfType<GameWinPannel>(true);
    }

    private void Update()
    {
        if (stageTime.time > timeToCompleteLevel)
        {
            pauseManager.PauseGame();
            levelCompletePannel.gameObject.SetActive(true);
        }
    }
}
