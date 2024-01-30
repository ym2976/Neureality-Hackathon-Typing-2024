using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
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


    [Header("Train Configuration")]
    public List<Presets.Letters> trainLetters;
    public int repeatTimesTrain;
    public float flashDurationTrain;
    public float flashIntervelTrain;

    [Header("Test Configuration")]
    public int repeatTimesTest;
    public float flashDurationTest;
    public float flashIntervelTest;

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


    public void SetBoardTrainConfig(List<Presets.Letters> trainLetters, int repeatTimesTrain, float flashDurationTrain, float flashIntervelTrain)
    {
        // copy the trainLetters


        this.trainLetters = new List<Presets.Letters>(trainLetters);
        this.repeatTimesTrain = repeatTimesTrain;
        this.flashDurationTrain = flashDurationTrain;
        this.flashIntervelTrain = flashIntervelTrain;

    }

    public void SetBoardTestConfig(int repeatTimesTest, float flashDurationTest, float flashIntervelTest)
    {
        this.repeatTimesTest = repeatTimesTest;
        this.flashDurationTest = flashDurationTest;
        this.flashIntervelTest = flashIntervelTest;

    }


    // Update is called once per frame
    void Update()
    {



    }



    public void ContinueButtonClicked()
    {

        if (gameManager.gameState == Presets.GameState.TrainState)
        {

            if (trainLetters.Count == 0)
            {
                gameManager.SetIdleState();
                return;

            }
            else
            {
                Presets.Letters targetLetter = trainLetters[0];
                StartCoroutine(TrainIEnumerator(targetLetter));

                // remove the fist letter from the list
                trainLetters.RemoveAt(0);

            }

        }
        else if (gameManager.gameState == Presets.GameState.TestState)
        {
            StartCoroutine(TestIEnumerator());
        }

        DeactivateContinueButton();
    }













    // flash settings
    public IEnumerator TrainIEnumerator(Presets.Letters targetLetter)
    {


        SetAllLettersOffColor();

        LetterController targetLetterController = letterControllerDict[targetLetter];

        Debug.Log("TrainIEnumerator Start");
        yield return new WaitForSeconds(Presets.BoardEnableWaitTime);
        Debug.Log("Flash Start");

        

        int repeatTimes = repeatTimesTrain;

        // turn on the target letter hint
        targetLetterController.SetLetterTrainHintHighlightColor();
        yield  return new WaitForSeconds(Presets.LetterTrainHintHighlightDuration);
        targetLetterController.SetLetterOffColor();

        SetAllLettersOffColor();

        yield return new WaitForSeconds(Presets.WaitDurationBeforeStartFlashing);

        for(int i = 0; i < repeatTimes; i++)
        {

            // copy   flashingSequence
            List<List<int>> flashingSequenceCopy = new List<List<int>>(flashingSequence);

            Utils.Shuffle(flashingSequenceCopy);

            foreach (List<int> index in flashingSequenceCopy)
            {

                int raw_col_indicator = index[0];
                int index_indicator = index[1];

                if(raw_col_indicator ==1)
                {
                    // turn on the index_indicator row
                    for (int j = 0; j < 6; j++)
                    {
                        LetterController letterController = boardControllers[index_indicator, j];
                        letterController.SetLetterOnColor();
                    }

                }
                else if(raw_col_indicator == 2)
                {
                    // turn on the target column
                    for (int j = 0; j < 6; j++)
                    {
                        LetterController letterController = boardControllers[j, index_indicator];
                        letterController.SetLetterOnColor();
                    }
                }

                // the target is on

                yield return new WaitForSeconds(flashDurationTrain);
                SetAllLettersOffColor();
                yield return new WaitForSeconds(flashIntervelTrain);

            }

            // now the flashing is done, wait for a while and exit


            // set the continue button active

        }
        yield return new WaitForSeconds(Presets.FlashEndRestDuration);
        ActivateContinueButton();
        SetAllLettersOnColor();

    }



    public IEnumerator TestIEnumerator()
    {

        // send event marker

        Debug.Log("TestIEnumerator Start");
        yield return new WaitForSeconds(Presets.BoardEnableWaitTime);
        Debug.Log("Flash Start");





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

}
