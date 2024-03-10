using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Presets;


public class BoardController : MonoBehaviour
{
    [Header("Train Configuration")]
    public List<Presets.Letters> trainLetters;
    public int repeatTimesTrain;
    public float flickerFrequencyMinTrainRow;
    public float flickerFrequencyOffsetTrainRow;
    public float flashDurationTrainRow;
    public float flashIntervalTrainRow;
    public float flickerFrequencyMinTrainColumn;
    public float flickerFrequencyOffsetTrainColumn;
    public float flashDurationTrainColumn;
    public float flashIntervalTrainColumn;


    [Header("Test Configuration ")]
    public int repeatTimesTest;
    public float flickerFrequencyMinTestRow;
    public float flickerFrequencyOffsetTestRow;
    public float flashDurationTestRow;
    public float flashIntervalTestRow;
    public float flickerFrequencyMinTestColumn;
    public float flickerFrequencyOffsetTestColumn;
    public float flashDurationTestColumn;
    public float flashIntervalTestColumn;


    // Start is called before the first frame update
    [Header("Letter Controller")]
    public LetterController A;
    public LetterController B;
    public LetterController C;
    public LetterController D;
    public LetterController E;
    public LetterController F;
    public LetterController G;
    public LetterController H;
    public LetterController I;
    public LetterController J;
    public LetterController K;
    public LetterController L;
    public LetterController M;
    public LetterController N;
    public LetterController O;
    public LetterController P;
    public LetterController Q;
    public LetterController R;
    public LetterController S;
    public LetterController T;
    public LetterController U;
    public LetterController V;
    public LetterController W;
    public LetterController X;
    public LetterController Y;
    public LetterController Z;
    public LetterController Zero;
    public LetterController One;
    public LetterController Two;
    public LetterController Three;
    public LetterController Four;
    public LetterController Five;
    public LetterController Six;
    public LetterController Seven;
    public LetterController Eight;
    public LetterController Nine;

    [Header("Board Grid")]
    public LetterController[,] boardControllers = new LetterController[6, 6];


    [Header("Board Buttons")]
    public Button ContinueButton;

    [Header("Game Manager")]
    public GameManager gameManager;

    // a list of list
    List<List<int>> flashingSequence  = new List<List<int>>() {
        // first element indicate the row and column, the second element indicate the index
        new List<int> { 1, 0 },
        new List<int> { 1, 1 },
        new List<int> { 1, 2 },
        new List<int> { 1, 3 },
        new List<int> { 1, 4 },
        new List<int> { 1, 5 },

        new List<int> { 2, 0 },
        new List<int> { 2, 1 },
        new List<int> { 2, 2 },
        new List<int> { 2, 3 },
        new List<int> { 2, 4 },
        new List<int> { 2, 5 },

    };


    // create the Presets.Letters AND LetterController dictionary
    public Dictionary<Presets.Letters, LetterController> letterControllerDict = new Dictionary<Presets.Letters, LetterController>();


    [Header("Train Test IEnumerator")]
    public IEnumerator trainCoroutine;
    public IEnumerator testCoroutine;





    void Start()
    {
        ContinueButton.onClick.AddListener(ContinueButtonClicked);
        // get all children of this object
        boardControllers[0,0] = A;
        boardControllers[0,1] = B;
        boardControllers[0,2] = C;
        boardControllers[0,3] = D;
        boardControllers[0,4] = E;
        boardControllers[0,5] = F;

        boardControllers[1,0] = G;
        boardControllers[1,1] = H;
        boardControllers[1,2] = I;
        boardControllers[1,3] = J;
        boardControllers[1,4] = K;
        boardControllers[1,5] = L;

        boardControllers[2,0] = M;
        boardControllers[2,1] = N;
        boardControllers[2,2] = O;
        boardControllers[2,3] = P;
        boardControllers[2,4] = Q;
        boardControllers[2,5] = R;

        boardControllers[3,0] = S;
        boardControllers[3,1] = T;
        boardControllers[3,2] = U;
        boardControllers[3,3] = V;
        boardControllers[3,4] = W;
        boardControllers[3,5] = X;

        boardControllers[4,0] = Y;
        boardControllers[4,1] = Z;
        boardControllers[4,2] = Zero;
        boardControllers[4,3] = One;
        boardControllers[4,4] = Two;
        boardControllers[4,5] = Three;

        boardControllers[5,0] = Four;
        boardControllers[5,1] = Five;
        boardControllers[5,2] = Six;
        boardControllers[5,3] = Seven;
        boardControllers[5,4] = Eight;
        boardControllers[5,5] = Nine;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                LetterController letterController = boardControllers[i, j];
                letterControllerDict.Add(letterController.letter, letterController);
            }
        }

    }


    public void SetBoardTrainConfig(
        List<Presets.Letters> trainLetters,
        int repeatTimesTrain,
        float flickerFrequencyMinTrainColumn,
        float flickerFrequencyMinTrainRow,
        float flickerFrequencyOffsetTrainColumn,
        float flickerFrequencyOffsetTrainRow,
        float flashDurationTrainRow,
        float flashDurationTrainColumn,
        float flashIntervalTrainRow,
        float flashIntervalTrainColumn)
    {
        // copy the trainLetters

        this.trainLetters = new List<Presets.Letters>(trainLetters);
        this.repeatTimesTrain = repeatTimesTrain;
        this.flickerFrequencyMinTrainColumn = flickerFrequencyMinTrainColumn;
        this.flickerFrequencyMinTrainRow = flickerFrequencyMinTrainRow;
        this.flickerFrequencyOffsetTrainColumn = flickerFrequencyOffsetTrainColumn;
        this.flickerFrequencyOffsetTrainRow = flickerFrequencyOffsetTrainRow;
        this.flashDurationTrainRow = flashDurationTrainRow;
        this.flashIntervalTrainRow = flashIntervalTrainRow;
        this.flashDurationTrainColumn = flashDurationTrainColumn;
        this.flashIntervalTrainColumn = flashIntervalTrainColumn;

    }

    public void SetBoardTestConfig(
        int repeatTimesTest,
        float flickerFrequencyMinTestColumn,
        float flickerFrequencyMinTestRow,
        float flickerFrequencyOffsetTestColumn,
        float flickerFrequencyOffsetTestRow,
        float flashDurationTestRow,
        float flashDurationTestColumn,
        float flashIntervalTestRow,
        float flashIntervalTestColumn)
    {
        this.repeatTimesTest = repeatTimesTest;
        this.flickerFrequencyMinTestColumn = flickerFrequencyMinTestColumn;
        this.flickerFrequencyMinTestRow = flickerFrequencyMinTestRow;
        this.flickerFrequencyOffsetTestColumn = flickerFrequencyOffsetTestColumn;
        this.flickerFrequencyOffsetTestRow = flickerFrequencyOffsetTestRow;
        this.flashDurationTestRow = flashDurationTestRow;
        this.flashIntervalTestRow = flashIntervalTestRow;
        this.flashDurationTestColumn = flashDurationTestColumn;
        this.flashIntervalTestColumn = flashIntervalTestColumn;
    }


    // Update is called once per frame
    void Update()
    {



    }


    /// <summary>
    /// This function is called when the continue button is clicked
    /// The function will start the train or test IEnumerator based on the game state
    /// </summary>
    public void ContinueButtonClicked()
    {


        if (gameManager.gameState == Presets.GameState.TrainState)
        {

            if (trainLetters.Count == 0)
            {
                gameManager.SetIdleState();

                // send the train marker to trigger train epochs function
                gameManager.eventMarkerLSLOutletController.SendTrainMarker();

                return;
            }
            else
            {
                Presets.Letters targetLetter = trainLetters[0];
                trainCoroutine = TrainIEnumerator(targetLetter);

                StartCoroutine(trainCoroutine);

                // remove the fist letter from the list
                trainLetters.RemoveAt(0);

            }

        }
        else if (gameManager.gameState == Presets.GameState.TestState)
        {
            testCoroutine = TestIEnumerator();
            StartCoroutine(testCoroutine);
        }
        DeactivateContinueButton();
    }



    /// <summary>
    /// This IEnumerator will flash the board based on the train configuration set in the game manager
    /// </summary>
    /// <param name="targetLetter"></param>
    /// <returns></returns>
    public IEnumerator TrainIEnumerator(Presets.Letters targetLetter)
    {
        // send the train trail start marker
        gameManager.eventMarkerLSLOutletController.SendFlashingTrailStartMarker((float)Presets.TrailMarker.TrainMarker);

        SetAllLettersOffColor();

        LetterController targetLetterController = letterControllerDict[targetLetter];

        Debug.Log("TrainIEnumerator Start");
        yield return new WaitForSeconds(Presets.BoardEnableWaitTime);
        Debug.Log("Flash Start");

        int repeatTimes = repeatTimesTrain;

        // turn on the target letter hint
        targetLetterController.SetLetterTrainHintHighlightColor();
        yield return new WaitForSeconds(Presets.LetterTrainHintHighlightDuration);
        targetLetterController.SetLetterOffColor();

        SetAllLettersOffColor();

        yield return new WaitForSeconds(Presets.WaitDurationBeforeStartFlashing);

        for (int i = 0; i < repeatTimes; i++)
        {
            List<List<int>> flashingSequenceCopy = new List<List<int>>(flashingSequence);
            Utils.Shuffle(flashingSequenceCopy);

            foreach (List<int> index in flashingSequenceCopy)
            {
                int rowOrColumnIndicator = index[0];
                int indexIndicator = index[1];

                // Choose the appropriate flash duration, interval, and frequency based on row/column
                float currentFlashDuration = rowOrColumnIndicator == 1 ? flashDurationTrainRow : flashDurationTrainColumn;
                float currentFlashInterval = rowOrColumnIndicator == 1 ? flashIntervalTrainRow : flashIntervalTrainColumn;
                float currentFlickerOffset = rowOrColumnIndicator == 1 ? flickerFrequencyOffsetTrainRow : flickerFrequencyOffsetTrainColumn;
                float minFlashFrequency = rowOrColumnIndicator == 1 ? flickerFrequencyMinTrainRow : flickerFrequencyMinTrainColumn;
                float currentFlashFrequency = minFlashFrequency + currentFlickerOffset * indexIndicator;

                StartCoroutine(
                            flicker(rowOrColumnIndicator, indexIndicator, currentFlashFrequency, currentFlashDuration, targetLetter));

                yield return new WaitForSeconds(currentFlashDuration);
                SetAllLettersOffColor();
                yield return new WaitForSeconds(currentFlashInterval);
            }
        }

    yield return new WaitForSeconds(1.0f);
    // send the train trail end marker
    gameManager.eventMarkerLSLOutletController.SendFlashingTrailEndMarker((float)Presets.TrailMarker.TrainMarker);

        yield return new WaitForSeconds(Presets.FlashEndRestDuration);
        ResetBoardGUI();
    }

    /// <summary>
    /// This IEnumerator will flash the board based on the test configuration set in the game manager
    /// </summary>
    /// <returns></returns>


public IEnumerator TestIEnumerator()
{
    // send the test trail start marker
    gameManager.eventMarkerLSLOutletController.SendFlashingTrailStartMarker((float)Presets.TrailMarker.TestMarker);

        SetAllLettersOffColor();

        Debug.Log("TestIEnumerator Start");
        yield return new WaitForSeconds(Presets.BoardEnableWaitTime);
        Debug.Log("Flash Start");

        int repeatTimes = repeatTimesTest;

        // Initial board flash for the test phase, if needed
        SetAllLettersOnColor();
        yield return new WaitForSeconds(Presets.LetterTrainHintHighlightDuration);
        SetAllLettersOffColor();

        yield return new WaitForSeconds(Presets.WaitDurationBeforeStartFlashing);

        for (int i = 0; i < repeatTimes; i++)
        {
            List<List<int>> flashingSequenceCopy = new List<List<int>>(flashingSequence);
            Utils.Shuffle(flashingSequenceCopy);

            foreach (List<int> index in flashingSequenceCopy)
            {
                int rowOrColumnIndicator = index[0];
                int indexIndicator = index[1];

                // Choose the appropriate flash duration and interval based on row/column
                float currentFlashDuration = rowOrColumnIndicator == 1 ? flashDurationTestRow : flashDurationTestColumn;
                float currentFlashInterval = rowOrColumnIndicator == 1 ? flashIntervalTestRow : flashIntervalTestColumn;
                float currentFlickerOffset = rowOrColumnIndicator == 1 ? flickerFrequencyOffsetTestRow : flickerFrequencyOffsetTestColumn;
                float minFlashFrequency = rowOrColumnIndicator == 1 ? flickerFrequencyMinTestRow : flickerFrequencyMinTestColumn;
                float currentFlashFrequency = minFlashFrequency + currentFlickerOffset * indexIndicator;

                StartCoroutine(
                            flicker(rowOrColumnIndicator, indexIndicator, currentFlashFrequency, currentFlashDuration));

                yield return new WaitForSeconds(currentFlashDuration);
                SetAllLettersOffColor();
                yield return new WaitForSeconds(currentFlashInterval);
            }
        }

        yield return new WaitForSeconds(1.0f);
        // send the test trail end marker
        gameManager.eventMarkerLSLOutletController.SendFlashingTrailEndMarker((float)Presets.TrailMarker.TestMarker);

        // Additional logic for handling the end of the test phase, such as displaying results, could be placed here.

    yield return new WaitForSeconds(Presets.FlashEndRestDuration);

    // this will trigger the predict() in PhysioLabXR Scripting Interface
    gameManager.eventMarkerLSLOutletController.SendTestMarker();
    gameManager.predictionLSLInletController.clearBuffer();

    bool predictionReceived = false;

    while (!predictionReceived)
    {
        gameManager.predictionLSLInletController.pullPredictionSample();
        if (gameManager.predictionLSLInletController.frameTimestamp != 0)
        {
            predictionReceived = true;
        }
        yield return new WaitForSeconds(0.2f); // wait for 0.2 second for pulling
    }


    // get the letter controller with predicted letter index in the board
    LetterController predictedLetterController = boardControllers[
        (int)gameManager.predictionLSLInletController.frameDataBuffer[0],
        (int)gameManager.predictionLSLInletController.frameDataBuffer[1]
        ];

    // turn on the predicted char for a second
    predictedLetterController.SetLetterTrainHintHighlightColor();
    yield return new WaitForSeconds(2.0f);
    SetAllLettersOffColor();
    yield return new WaitForSeconds(1.0f);

    ResetBoardGUI();
}

    public IEnumerator flicker(int rowOrColumnIndicator, int indexIndicator, float frequency, float duration)
    {
        Debug.Log((rowOrColumnIndicator == 1 ? "row" : "column") + $" index={indexIndicator}, frequency={frequency}");
        float flickerDuration = (1 / frequency) * 0.6f;
        float flickerInterval = (1 / frequency) * 0.4f;
        float flickerCount = duration / (1 / frequency);

        for (int i = 0; i < flickerCount; i++)
        {
            if (rowOrColumnIndicator == 1)
            {
                // Flashing a row
                for (int j = 0; j < 6; j++)
                {
                    LetterController letterController = boardControllers[indexIndicator, j];
                    letterController.SetLetterRowFlashColor();
                }
            }
            else if (rowOrColumnIndicator == 2)
            {
                // Flashing a column
                for (int j = 0; j < 6; j++)
                {
                    LetterController letterController = boardControllers[j, indexIndicator];
                    letterController.SetLetterColumnFlashColor();
                }
            }

            // Send the flashing marker with additional information on whether the target was flashing
            gameManager.eventMarkerLSLOutletController.SendFlashingMarker((float)rowOrColumnIndicator, (float)indexIndicator, 0.0f);

            yield return new WaitForSeconds(flickerDuration);
            SetAllLettersOffColor();
            yield return new WaitForSeconds(flickerInterval);
        }
    }

    public IEnumerator flicker(int rowOrColumnIndicator, int indexIndicator, float frequency, float duration, Presets.Letters targetLetter)
    {
        LetterController targetLetterController = letterControllerDict[targetLetter];
        bool targetFlashing = false;

        Debug.Log((rowOrColumnIndicator == 1 ? "row" : "column") + $" index={indexIndicator}, frequency={frequency}");
        float flickerDuration = (1 / frequency) * 0.6f;
        float flickerInterval = (1 / frequency) * 0.4f;
        float flickerCount = duration / (1 / frequency);

        for (int i = 0; i < flickerCount; i++)
        {
            if (rowOrColumnIndicator == 1)
            {
                // Flashing a row
                for (int j = 0; j < 6; j++)
                {
                    LetterController letterController = boardControllers[indexIndicator, j];
                    letterController.SetLetterRowFlashColor();
                    if (letterController == targetLetterController) targetFlashing = true;
                }
            }
            else if (rowOrColumnIndicator == 2)
            {
                // Flashing a column
                for (int j = 0; j < 6; j++)
                {
                    LetterController letterController = boardControllers[j, indexIndicator];
                    letterController.SetLetterColumnFlashColor();
                    if (letterController == targetLetterController) targetFlashing = true;
                }
            }

            // Send the flashing marker with additional information on whether the target was flashing
            gameManager.eventMarkerLSLOutletController.SendFlashingMarker((float)rowOrColumnIndicator, (float)indexIndicator, targetFlashing ? 1.0f : 0.0f);

            yield return new WaitForSeconds(flickerDuration);
            SetAllLettersOffColor();
            yield return new WaitForSeconds(flickerInterval);
        }
    }

    public void ResetBoardGUI()
    {
        ActivateContinueButton();
        SetAllLettersOnColor();
    }

    public void ActivateContinueButton()
    {
        ContinueButton.gameObject.SetActive(true);
    }

    public void DeactivateContinueButton()
    {
        ContinueButton.gameObject.SetActive(false);
    }


    public void SetAllLettersOffColor()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                LetterController letterController = boardControllers[i, j];
                letterController.SetLetterOffColor();
            }
        }
    }

    public void SetAllLettersOnColor()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                LetterController letterController = boardControllers[i, j];
                letterController.SetLetterOnColor();
            }
        }
    }


    public void InterruptBoard()
    {
        if (trainCoroutine != null)
        {
            StopCoroutine(trainCoroutine);
            Debug.Log("Train Coroutine Stopped");

            // send interrupt signal
        }
        if (testCoroutine != null)
        {
            StopCoroutine(testCoroutine);
            Debug.Log("Test Coroutine Stopped");
        }

        ResetBoardGUI();

        // send interrupt signal via LSL
        gameManager.eventMarkerLSLOutletController.SendInterruptMarker();

    }

}
