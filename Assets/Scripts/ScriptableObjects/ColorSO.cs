using UnityEngine;

[CreateAssetMenu(fileName = "Color-", menuName = "Game Stuff/Color")]
public class ColorSO : ScriptableObject
{
    [SerializeField]
    string colorName;

    [SerializeField]
    Color color;

    public Color Color { get => color; }
    public string ColorName { get => colorName; }
}
