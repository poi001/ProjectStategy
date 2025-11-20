//using System;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//public class TestEditorTeamSetting : BaseTestEditorWindow
//{
//    [MenuItem("??Test Func/Open Editor - Buff")]
//    public static void Open()
//    {
//        var window = GetWindow<TestEditorTeamSetting>();
//        window.titleContent = new GUIContent("Buff Test Tool");
//        window.Show();
//    }

//    protected override void OnGUI()
//    {
//        base.OnGUI();

//        DrawTitle("Buff Test Tool");
//        DrawSectionTitle("Buff List");

//        BeginScroll();

//        DrawStat();
//        DrawBlockSpace();
//        DrawBuffButton();

//        EndScroll();
//    }

//    private void DrawBuffButton()
//    {
//        List<(string, Action)> gridButtons = new();

//        for (int i = 1; i < Enum.GetValues(typeof(BuffType)).Length; i++)
//        {
//            BuffType type = (BuffType)Enum.GetValues(typeof(BuffType)).GetValue(i);

//            string baseName = Enum.GetNames(typeof(BuffType))[i];
//            gridButtons.Add((baseName, () => ActiveBuff(type)));
//        }

//        DrawGridButtons(gridButtons, 2);
//    }

//    private void ActiveBuff(BuffType type)
//    {
//        BuffManager.Instance.AddBuff(type);
//    }

//    private void DrawStat()
//    {
//        if (!Application.isPlaying || Game.Object.Player == null) return;

//        for (int i = 1; i < Enum.GetValues(typeof(BuffType)).Length; i++)
//        {
//            BuffType type = (BuffType)Enum.GetValues(typeof(BuffType)).GetValue(i);

//            Stat stat = Game.Object.Player.Stat.GetStatByBuffType(type);
//            string statName = Enum.GetNames(typeof(BuffType))[i];
//            DrawLabel($"{statName} : {stat.GetCalculationString()}");
//        }
//    }
//}
