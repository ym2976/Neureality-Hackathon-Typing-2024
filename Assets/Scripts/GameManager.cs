using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Presets.GameState gameState;

    [Header("Train Configuration")]
    public List<Presets.Letters> trainLetters;
    public int repeatTimesTrain;
    public float flashDurationTrain;
    public float flashIntervelTrain;

    [Header("Test Configuration")]
    public int repeatTimesTest;
    public float flashDurationTest;
    public float flashIntervelTest;


    [Header("Welcome State GUI")]
    public Button StartTrainButton;
    public Button StartTestButton;
    public GameObject IntroductionTextPanel;

    [Header("Train Test State GUI")]
    public BoardController boardController;
    public Button interruptButton;

    [Header("Train State GUI")]
    public GameObject WelcomeStateGUI;
    public GameObject TrailStateGUI;

    void Start()
    {
        // set the game state to idle
        gameState = Presets.GameState.IdleState;
        WelcomeStateGUI.SetActive(true);
        TrailStateGUI.SetActive(false);

        // connect the button to the function
        StartTrainButton.onClick.AddListener(TrainButtonClicked);
        StartTestButton.onClick.AddListener(TestButtonClicked);

    }



    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void TrainButtonClicked()
    {
        SetTrainState();
        boardController.SetBoardTrainConfig(trainLetters, repeatTimesTrain, flashDurationTrain, flashIntervelTrain);
        
    }


    public void TestButtonClicked()
    {
        SetTestState();
        boardController.SetBoardTestConfig(repeatTimesTest, flashDurationTest, flashIntervelTest);

    }

    public void SetTrainState()
    {
        gameState = Presets.GameState.TrainState;

        WelcomeStateGUI.SetActive(false);
        TrailStateGUI.SetActive(true);
    }


    public void SetTestState()
    {
        gameState = Presets.GameState.TestState;

        WelcomeStateGUI.SetActive(false);
        TrailStateGUI.SetActive(true);
    }


    public void SetIdleState()
    {
        gameState = Presets.GameState.IdleState;

        WelcomeStateGUI.SetActive(true);
        TrailStateGUI.SetActive(false);
    }




}
