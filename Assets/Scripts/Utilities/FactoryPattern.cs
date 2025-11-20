using System;
using System.Collections.Generic;
using System.Linq;

//public static class SkillFactory
//{
//    public static Dictionary<string, Type> SkillTypes { get; private set; } = new();

//    // static 생성자는 클래스 전체가 처음 사용될 때 한 번만 실행, 직접 호출할 수도, new로 만들 수도 없음
//    // 보통 static 변수 초기화나 싱글톤 초기화에 사용
//    static SkillFactory()
//    {
//        var skillInterface = typeof(ISkill);
//        var types = AppDomain.CurrentDomain.GetAssemblies() // 현재 실행 중인 모든 어셈블리(코드 묶음)를 가져옵니다.
//                         // 각 어셈블리(a) 안에 들어있는 모든 클래스/구조체/인터페이스 타입 목록을 펼쳐서 한 리스트로 만듭니다.
//                        .SelectMany(a => a.GetTypes())
//                         // 이 클래스가 ISkill을 구현했는가?, 인터페이스 자체는 제외하라, 추상 클래스(abstract class)는 제외하라
//                        .Where(t => skillInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

//        foreach (var type in types)
//        {
//            SkillTypes[type.Name] = type;
//        }
//    }

//    public static ISkill CreateSkill(string name)
//    {
//        if (SkillTypes.TryGetValue(name, out var type))
//        {
//            return (ISkill)Activator.CreateInstance(type);
//        }

//        throw new Exception($"Skill not found: {name}");
//    }
//}

public static class MovementFactory
{
    //public static Move CreateEnemy(string type)
    //{
    //    switch (type)
    //    {
    //        case "Goblin":
    //            return new Goblin();
    //        case "Orc":
    //            return new Orc();
    //        case "Troll":
    //            return new Troll();
    //        default:
    //            Debug.LogError("Unknown enemy type!");
    //            return null;
    //    }
    //}
}

public static class AttackActionFactory
{

}

//public class SkillFactory
//{
//    public Dictionary<string, Type> SkillTypes { get; private set; } = new();

//    // static 생성자는 클래스 전체가 처음 사용될 때 한 번만 실행, 직접 호출할 수도, new로 만들 수도 없음
//    // 보통 static 변수 초기화나 싱글톤 초기화에 사용
//    public SkillFactory()
//    {
//        var skillInterface = typeof(ISkill);
//        var types = AppDomain.CurrentDomain.GetAssemblies() // 현재 실행 중인 모든 어셈블리(코드 묶음)를 가져옵니다.
//                                                            // 각 어셈블리(a) 안에 들어있는 모든 클래스/구조체/인터페이스 타입 목록을 펼쳐서 한 리스트로 만듭니다.
//                        .SelectMany(a => a.GetTypes())
//                        // 이 클래스가 ISkill을 구현했는가?, 인터페이스 자체는 제외하라, 추상 클래스(abstract class)는 제외하라
//                        .Where(t => skillInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

//        foreach (var type in types)
//        {
//            SkillTypes[type.Name] = type;
//        }
//    }

//    public ISkill CreateSkill(string name)
//    {
//        if (SkillTypes.TryGetValue(name, out var type))
//        {
//            return (ISkill)Activator.CreateInstance(type);
//        }

//        throw new Exception($"Skill not found: {name}");
//    }
//}

//public class AttackObjectFactory
//{
//    public Dictionary<string, Type> AttackObjectTypes { get; private set; } = new();

//    // static 생성자는 클래스 전체가 처음 사용될 때 한 번만 실행, 직접 호출할 수도, new로 만들 수도 없음
//    // 보통 static 변수 초기화나 싱글톤 초기화에 사용
//    public AttackObjectFactory()
//    {
//        var skillInterface = typeof(IAttackObject);
//        var types = AppDomain.CurrentDomain.GetAssemblies() // 현재 실행 중인 모든 어셈블리(코드 묶음)를 가져옵니다.
//                                                            // 각 어셈블리(a) 안에 들어있는 모든 클래스/구조체/인터페이스 타입 목록을 펼쳐서 한 리스트로 만듭니다.
//                        .SelectMany(a => a.GetTypes())
//                        // 이 클래스가 ISkill을 구현했는가?, 인터페이스 자체는 제외하라, 추상 클래스(abstract class)는 제외하라
//                        .Where(t => skillInterface.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

//        foreach (var type in types)
//        {
//            AttackObjectTypes[type.Name] = type;
//        }
//    }

//    public IAttackObject CreateAttackObject(string name)
//    {
//        if (AttackObjectTypes.TryGetValue(name, out var type))
//        {
//            // Activator: 컴파일 시점에 어떤 클래스인지 정확히 모를 때, 타입 정보를 이용해 객체를 생성
//            return (IAttackObject)Activator.CreateInstance(type);
//        }

//        throw new Exception($"AttackObject not found: {name}");
//    }
//}
