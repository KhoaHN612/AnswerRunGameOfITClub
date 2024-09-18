using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    [TextArea]
    public string questionText;
    public string[] answers = new string[4]; 
    public int correctAnswerIndex;

    public Gate.OperationType rightOperation; // Operation for the correct answer
    public int rightValue; // Value for the correct answer
    public Gate.OperationType falseOperation; // Operation for the incorrect answers
    public int falseValue; // Value for the incorrect answers
}
