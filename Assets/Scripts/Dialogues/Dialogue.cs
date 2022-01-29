using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField]
    [TextArea(3, 10)]
    private string text;

    public string Text => text;
}