using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Presets
{

    // LabStreamingLayer settings
    public static string EventMarkerLSLOutletStreamName = "P300SpellerEventMarkerLSL";
    public static string EventMarkerLSLOutletStreamType = "EventMarker";
    public static string EventMarkerLSLOutletStreamID = "1";
    public static int EventMarkerChannelNum = 6; // block marker index 0
    public static float EventMarkerNominalSamplingRate = 1;

    public enum EventMarkerChannelInfo
    {
        FlashingBlockStartMarker = 0,
        FlashingMarker = 1,
        FlashingRowOrColumnMarker = 2,
        FlashingRowOrColumnIndexMarker = 3,
        FlashingTargetMarker = 4
    }

    public enum Letters
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9,
        K = 10,
        L = 11,
        M = 12,
        N = 13,
        O = 14,
        P = 15,
        Q = 16,
        R = 17,
        S = 18,
        T = 19,
        U = 20,
        V = 21,
        W = 22,
        X = 23,
        Y = 24,
        Z = 25,
        Zero = 26,
        One = 27,
        Two = 28,
        Three = 29,
        Four = 30,
        Five = 31,
        Six = 32,
        Seven = 33,
        Eight = 34,
        Nine = 35
    }


    public enum GameState
    {
        IdleState = 0,
        TrainState = 1,
        TestState = 2,
    }

    public enum BoardState
    {
        IdelState,
        RuningState,
    }



    public static float BoardEnableWaitTime = 3.0f;
    public static float LetterTrainHintHighlightDuration = 2.0f;
    public static float WaitDurationBeforeStartFlashing = 2.0f;
    public static float FlashEndRestDuration = 3.0f;


    public static float WaitFeedbackDuration = 4.0f;
    public static float HighLightDuration = 2.0f;


    public static Color LetterOffColor = new Color(0.5f, 0.5f, 0.5f, 1);
    public static Color LetterOnColor = new Color(1, 1, 1, 1);

    public static Color LetterTrainHintHighlightColor = new Color(0, 1, 0, 1);
    public static Color LetterPredictionHighlightColor = new Color(1, 0, 0, 1);




    // key settings
    public static KeyCode InterruptKey = KeyCode.Escape;


}
