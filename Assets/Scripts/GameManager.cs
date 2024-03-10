using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public Presets.GameState gameState;

    [Header("Train Configuration")]
    public List<Presets.Letters> trainLetters;
    public int repeatTimesTrain;
    public float flashDurationTrainRow;
    public float flashIntervalTrainRow;
    public float flashDurationTrainColumn;
    public float flashIntervalTrainColumn;

    [Header("Test Configuration")]
    public int repeatTimesTest;
    public float flashDurationTestRow;
    public float flashIntervalTestRow;
    public float flashDurationTestColumn;
    public float flashIntervalTestColumn;

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


    [Header("Event Marker LSL Outlet Controller")]
    public EventMarkerLSLOutletController eventMarkerLSLOutletController;

    [Header("Prediction LSL Inlet Controller")]
    public PredictionLSLInletController predictionLSLInletController;


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
        InterruptButtonPresssed();


    }

    public void TrainButtonClicked()
    {
        SetTrainState();
        boardController.SetBoardTrainConfig(trainLetters, repeatTimesTrain, flashDurationTrainRow, flashDurationTrainColumn, flashIntervalTrainRow,flashIntervalTrainColumn);

    }


    public void TestButtonClicked()
    {
        SetTestState();
        boardController.SetBoardTestConfig(repeatTimesTest, flashDurationTestRow, flashDurationTestColumn, flashIntervalTestRow,flashIntervalTestColumn);


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



    public void InterruptButtonPresssed()
    {

        // check if the esc button been pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // check if the game state is in training state
            if (gameState == Presets.GameState.TrainState || gameState == Presets.GameState.TestState)
            {
                boardController.InterruptBoard();
            }

            SetIdleState();
        }

    }


}
