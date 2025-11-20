using UnityEditor;
using UnityEngine;
using System;
using System.Collections.Generic;

public abstract class BaseTestEditorWindow : EditorWindow
{
    protected int spaceBlockValue = 10;
    protected int spaceValue = 5;
    protected GUIStyle titleStyle;
    protected GUIStyle sectionTitleStyle;
    protected GUIStyle foldoutStyle;

    protected Vector2 scrollPos;
    protected int currentTab = 0;
    protected string[] tabNames = new string[] { "Tab 1", "Tab 2", "Tab 3" };

    protected virtual void OnGUI()
    {
        EnsureStyles();
    }

    #region << =========== STYLE INIT =========== >>

    protected void EnsureStyles()
    {
        if (titleStyle == null)
        {
            titleStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 20,
                alignment = TextAnchor.MiddleCenter
            };
        }

        if (sectionTitleStyle == null)
        {
            sectionTitleStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                fontSize = 14,
                normal = { textColor = Color.cyan }
            };
        }

        if (foldoutStyle == null)
        {
            foldoutStyle = new GUIStyle(EditorStyles.foldout)
            {
                fontStyle = FontStyle.Bold,
                fontSize = 12
            };
        }
    }

    #endregion

    #region << =========== LAYOUT HELPERS =========== >>

    protected void DrawTitle(string title) { GUILayout.Label(title, titleStyle); GUILayout.Space(spaceValue); }
    protected void DrawSectionTitle(string title) { GUILayout.Space(15); DrawLine(); GUILayout.Label(title, sectionTitleStyle); GUILayout.Space(spaceValue); }
    protected void DrawLabel(string label) { GUILayout.Label(label, EditorStyles.label); }
    protected void DrawBoxSection(Action drawContent) { GUILayout.BeginVertical("box"); drawContent?.Invoke(); GUILayout.EndVertical(); DrawBlockSpace(); }
    protected void DrawLine()
    {
        GUILayout.Space(spaceValue);
        GUILayout.Box("", GUILayout.ExpandWidth(true), GUILayout.Height(1));
        GUILayout.Space(spaceValue);
    }
    protected void DrawBlockSpace() => GUILayout.Space(spaceBlockValue);
    protected void DrawItemSpace() => GUILayout.Space(spaceValue);
    protected void DrawHelpBox(string message, MessageType type = MessageType.Info) { EditorGUILayout.HelpBox(message, type); }

    #endregion

    #region << =========== COMMON UI ELEMENTS =========== >>

    protected bool DrawButton(string label, int width = 140, int height = 30) { return GUILayout.Button(label, GUILayout.Width(width), GUILayout.Height(height)); }

    protected void DrawHorizontalButtons(params (string label, Action onClick)[] buttons)
    {
        GUILayout.BeginHorizontal();
        foreach (var (label, onClick) in buttons)
        {
            if (GUILayout.Button(label, GUILayout.Height(30))) { onClick?.Invoke(); }
        }
        GUILayout.EndHorizontal();
    }

    protected void DrawVerticalButtons(params (string label, Action onClick)[] buttons)
    {
        GUILayout.BeginVertical();
        foreach (var (label, onClick) in buttons)
        {
            if (GUILayout.Button(label, GUILayout.Height(30))) { onClick?.Invoke(); }
        }
        GUILayout.EndVertical();
    }

    protected void DrawGridButtons(List<(string label, Action onClick)> buttons, int columnCount = 3, int buttonWidth = 100, int buttonHeight = 30)
    {
        int total = buttons.Count;
        int rowCount = Mathf.CeilToInt((float)total / columnCount);
        int buttonIndex = 0;

        for (int row = 0; row < rowCount; row++)
        {
            GUILayout.BeginHorizontal();
            for (int col = 0; col < columnCount; col++)
            {
                if (buttonIndex >= total) break;

                var (label, onClick) = buttons[buttonIndex];
                if (GUILayout.Button(label, GUILayout.Height(buttonHeight))) { onClick?.Invoke(); }
                buttonIndex++;
            }
            GUILayout.EndHorizontal();
        }
    }

    protected bool DrawFoldout(ref bool foldoutState, string title)
    {
        foldoutState = EditorGUILayout.Foldout(foldoutState, title, true, foldoutStyle);
        return foldoutState;
    }

    protected void DrawSliderWithLabel(ref float value, float min, float max, string label = null)
    {
        GUILayout.BeginHorizontal();
        if (!string.IsNullOrEmpty(label)) GUILayout.Label(label, GUILayout.Width(100));
        value = GUILayout.HorizontalSlider(value, min, max);
        GUILayout.Label(value.ToString("F0"), GUILayout.Width(40));
        GUILayout.EndHorizontal();
    }

    protected void DrawSliderWithLabel(ref int value, int min, int max, string label = null)
    {
        GUILayout.BeginHorizontal();
        if (!string.IsNullOrEmpty(label)) GUILayout.Label(label, GUILayout.Width(100));
        value = (int)GUILayout.HorizontalSlider(value, min, max);
        GUILayout.Label(value.ToString(), GUILayout.Width(40));
        GUILayout.EndHorizontal();
    }

    protected void DrawToggle(ref bool value, string label) { value = EditorGUILayout.Toggle(label, value); }

    protected void DrawDropdown<T>(ref int selectedIndex, string label, List<T> options)
    {
        List<string> labels = options.ConvertAll(o => o.ToString());
        selectedIndex = EditorGUILayout.Popup(label, selectedIndex, labels.ToArray());
    }

    protected void DrawDropdownEnum<T>(ref T selected, string label) where T : Enum { selected = (T)EditorGUILayout.EnumPopup(label, selected); }
    protected void DrawColorPicker(ref Color color, string label = "Color") { color = EditorGUILayout.ColorField(label, color); }
    protected void DrawVector3Field(ref Vector3 value, string label = "Vector3") { value = EditorGUILayout.Vector3Field(label, value); }
    protected void DrawIntField(ref int value, string label = "Value") { value = EditorGUILayout.IntField(label, value); }
    protected void DrawFloatField(ref float value, string label = "Value") { value = EditorGUILayout.FloatField(label, value); }

    #endregion

    #region << =========== TABS / SCROLL =========== >>

    protected void DrawTabs()
    {
        currentTab = GUILayout.Toolbar(currentTab, tabNames);
        GUILayout.Space(spaceBlockValue);
    }

    protected void BeginScroll()
    {
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
    }

    protected void EndScroll()
    {
        EditorGUILayout.EndScrollView();
    }

    #endregion

    #region << =========== UTILITIES =========== >>

    protected void FocusOut()
    {
        GUI.FocusControl(null);
    }

    #endregion
}
