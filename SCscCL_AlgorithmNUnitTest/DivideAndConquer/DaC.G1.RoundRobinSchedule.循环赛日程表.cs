using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer {
  //循环赛（Round-Robin）是一种常见的比赛形式，其中每个参赛者都要与其他所有参赛者进行一次比赛。这种赛制在体育比赛中非常常见，例如足球联赛、篮球联赛等。

  //在C#中，可以使用简单的算法来生成循环赛的日程表。以下是一个示例算法，它将生成一个完整的循环赛日程表：
  internal partial class DaC {
    /// <summary>
    /// 
    /// </summary>
    /// <param name="numTeams">参赛队伍数量</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static List<List<(int, int)>> GenerateSchedule(int numTeams) {
      if(numTeams<2) {
        throw new ArgumentException("至少需要两个队伍");
      }

      List<List<(int, int)>> schedule = new List<List<(int, int)>>();
      int[] teams = new int[numTeams];

      // 初始化队伍数组
      for(int i = 0; i<numTeams; i++) {
        teams[i]=i;
      }

      // 生成轮次
      for(int round = 0; round<numTeams-1; round++) {
        List<(int, int)> currentRound = new List<(int, int)>();

        // 固定第一个队伍
        for(int i = 1; i<numTeams/2+1; i++) {
          currentRound.Add((teams[0], teams[i]));
          currentRound.Add((teams[numTeams-i], teams[numTeams-1-i+1]));
        }

        schedule.Add(currentRound);

        // 旋转队伍
        int last = teams[numTeams-1];
        for(int i = numTeams-1; i>0; i--) {
          teams[i]=teams[i-1];
        }
        teams[1]=last;
      }

      return schedule;
    }
    public static void PrintSchedule(List<List<(int, int)>> schedule) {
      for(int round = 0; round<schedule.Count; round++) {
        Console.WriteLine($"第 {round+1} 轮:");
        foreach(var match in schedule[round]) {
          Console.WriteLine($"{match.Item1} vs {match.Item2}");
        }
        Console.WriteLine();
      }
    }
    //算法思路
    //初始化：假设我们有 n 个队伍，编号为 0 到 n-1。
    //固定第一个队伍：将第一个队伍（编号 0）固定在第一列。
    //旋转其他队伍：每次将剩余的队伍顺时针旋转一个位置，直到所有队伍都与第一个队伍比赛过。
    //生成轮次：每一轮中，每个队伍都会有一个对手。
    [Test]
    public void 循环赛日程表() {
      System.Console.WriteLine(@$"UT Excuted {nameof(DaC)}_{nameof(循环赛日程表)}");
      int numTeams = 6; // 假设有6个队伍
      var schedule = GenerateSchedule(numTeams);
      PrintSchedule(schedule);
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }
  }
}
