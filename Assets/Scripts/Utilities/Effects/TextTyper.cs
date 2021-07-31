using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextTyper : MonoBehaviour
{
    [SerializeField]
    float _textSpeed = .2f;

    TextMeshPro _textMesh;
    string _text = "";
    int _currentCharacterIndex = 0;

    // Start is called before the first frame update
    void Awake()
    {
        _textMesh = GetComponent<TextMeshPro>();
        Clear();
    }

    public void UpdateText(string text)
    {
        Clear();
        _text = text;
        StartCoroutine(PrintCharacters());
    }

    private IEnumerator PrintCharacters()
    {
        while (_currentCharacterIndex < _text.Length) 
        {
            yield return new WaitForSeconds(_textSpeed);
            if(_currentCharacterIndex >= _text.Length)
            {
                break;
            }
            _textMesh.text += _text[_currentCharacterIndex];
            _currentCharacterIndex++;
        }
    }

    public void Clear()
    {
        _currentCharacterIndex = 0;
        _text = "";
        _textMesh.text = _text;
    }
}
