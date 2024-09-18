using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Gate : MonoBehaviour
{
    public enum OperationType
    { 
        addition,
        difference,
        multiplication,
        division
    }

    [Header("Operation")]
    [SerializeField] public OperationType gateOperation;
    [SerializeField] public int value;
    [SerializeField] private string textAnswer;
    [SerializeField] public bool isUnknown = false;
    public UnityEvent onActive;

    [Header("References")]
    [SerializeField] private TextMeshPro operationText;
    [SerializeField] private MeshRenderer forceField;
    [SerializeField] private Material[] operationTypeMaterial;

    private void Awake()
    {
        AssignOperation();
    }
    public void AssignTextAnswer(string text)
    {
        textAnswer = text;
        operationText.text = textAnswer;
    }
    public void AssignOperation()
    {
        string finalText = "";

        if (gateOperation == OperationType.addition)
            finalText += "+";
        if (gateOperation == OperationType.difference)
            finalText += "-";
        if (gateOperation == OperationType.multiplication)
            finalText += "x";
        if (gateOperation == OperationType.division)
            finalText += "÷";

        finalText += value.ToString();
        operationText.text = textAnswer;

        if (isUnknown == true)
        {
            forceField.material = operationTypeMaterial[2];
        } else
        {
            if (gateOperation == OperationType.addition || gateOperation == OperationType.multiplication)
                forceField.material = operationTypeMaterial[0];
            else
                forceField.material = operationTypeMaterial[1];
        }

    }

    public void ExecuteOperation()
    {
        if (gateOperation == OperationType.addition)
            GameEvents.instance.playerSize.Value += value;
        if (gateOperation == OperationType.difference)
            GameEvents.instance.playerSize.Value -= value;
        if (gateOperation == OperationType.multiplication)
            GameEvents.instance.playerSize.Value *= value;
        if (gateOperation == OperationType.division)
            GameEvents.instance.playerSize.Value /= value;

        onActive?.Invoke();
        GetComponent<BoxCollider>().enabled = false;
        forceField.gameObject.SetActive(false);
    }
}