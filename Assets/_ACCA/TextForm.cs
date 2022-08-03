using TMPro;
using UnityEngine;

public class TextForm : MonoBehaviour
{
    [SerializeField] private TMP_InputField content;

    public TextData GetData()
    {
        //return new TextData(content.text);
        return new TextData("Dios");
    }
}
