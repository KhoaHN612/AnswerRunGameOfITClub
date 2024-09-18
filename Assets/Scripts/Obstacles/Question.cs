using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Question : MonoBehaviour
{
    private List<Gate> gates;
    public QuestionData questionData;
    public TextMeshPro questionText;

    private void Awake()
    {
        gates = new List<Gate>(GetComponentsInChildren<Gate>());
    }

    public void SetupGates()
    {
        if (questionData == null)
        {
            return;
        }

        if (gates.Count != questionData.answers.Length)
        {
            Debug.LogError("The number of gates does not match the number of answers.");
            return;
        }

        if (questionText == null) { return; }

        questionText.text = questionData.questionText;

        for (int i = 0; i < gates.Count; i++)
        {
            Gate gate = gates[i];
            gate.AssignTextAnswer(questionData.answers[i]);

            if (i == questionData.correctAnswerIndex)
            {
                // Set correct answer properties
                gate.isUnknown = true;
                gate.gateOperation = questionData.rightOperation;
                gate.value = questionData.rightValue;
            }
            else
            {
                // Set incorrect answer properties
                gate.isUnknown = true;
                gate.gateOperation = questionData.falseOperation;
                gate.value = questionData.falseValue;
            }

            gate.AssignOperation(); // Update the operation display and materials
        }
    }
}
