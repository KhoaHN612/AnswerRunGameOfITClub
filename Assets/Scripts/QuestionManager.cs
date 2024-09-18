using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionManager : MonoBehaviour
{
    public List<QuestionData> questionDataList;
    private void Start()
    {
        Question[] questions = FindObjectsOfType<Question>();
        Debug.Log(questions.Length);

        if (questionDataList.Count < questions.Length)
        {
            Debug.LogError("Not enough QuestionData to assign to all Questions.");
            return;
        }

        Shuffle(questionDataList);

        for (int i = 0; i < questions.Length; i++)
        {
            questions[i].questionData = questionDataList[i];
            questions[i].SetupGates();
        }
    }

    private void Shuffle(List<QuestionData> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            QuestionData temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
