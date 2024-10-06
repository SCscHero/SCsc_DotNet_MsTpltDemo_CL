using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCscCL_AlgorithmNUnitTest.DivideAndConquer {
  public class Point {
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y) {
      X=x;
      Y=y;
    }
    public override string ToString() {
      return $"({X}, {Y})";
    }
  }
  //C#最接近点问题的算法
  internal partial class DaC {
    private static Random random = new Random();

    // 计算两点之间的欧几里得距离
    private static double Distance(Point p1, Point p2) {
      return Math.Sqrt((p1.X-p2.X)*(p1.X-p2.X)+(p1.Y-p2.Y)*(p1.Y-p2.Y));
    }

    // 分治法求解最近点对
    public static (Point, Point, double) FindClosestPair(List<Point> points) {
      if(points.Count<2) {
        throw new ArgumentException("至少需要两个点");
      }

      // 按 x 坐标排序
      List<Point> sortedByX = points.OrderBy(p => p.X).ToList();
      return FindClosestPairRecursive(sortedByX);
    }

    private static (Point, Point, double) FindClosestPairRecursive(List<Point> points) {
      int n = points.Count;
      if(n<=3) {
        // 对于小规模问题，使用暴力方法
        double minDist = double.MaxValue;
        Point p1 = null, p2 = null;

        for(int i = 0; i<n; i++) {
          for(int j = i+1; j<n; j++) {
            double dist = Distance(points[i], points[j]);
            if(dist<minDist) {
              minDist=dist;
              p1=points[i];
              p2=points[j];
            }
          }
        }

        return (p1, p2, minDist);
      }

      // 分成两半
      int mid = n/2;
      var leftPoints = points.GetRange(0, mid);
      var rightPoints = points.GetRange(mid, n-mid);

      // 递归求解左右两半
      var (leftP1, leftP2, leftMinDist)=FindClosestPairRecursive(leftPoints);
      var (rightP1, rightP2, rightMinDist)=FindClosestPairRecursive(rightPoints);

      // 合并结果
      double d = Math.Min(leftMinDist, rightMinDist);
      Point midPoint = points[mid-1];
      var strip = points.Where(p => Math.Abs(p.X-midPoint.X)<d).OrderBy(p => p.Y).ToList();

      (Point, Point, double) closestPair = (leftP1, leftP2, leftMinDist);
      if(rightMinDist<leftMinDist) {
        closestPair=(rightP1, rightP2, rightMinDist);
      }

      // 检查跨越中间线的点对
      for(int i = 0; i<strip.Count; i++) {
        for(int j = i+1; j<strip.Count&&(strip[j].Y-strip[i].Y)<d; j++) {
          double dist = Distance(strip[i], strip[j]);
          if(dist<closestPair.Item3) {
            closestPair=(strip[i], strip[j], dist);
          }
        }
      }

      return closestPair;
    }

    //分治法解题
    [Test]
    public void 最接近点问题() {
      System.Console.WriteLine(@$"UT Excuted {nameof(DaC)}_{nameof(最接近点问题)}");
      List<Point> points = new List<Point>
 {
            new Point(2, 3),
            new Point(12, 30),
            new Point(40, 50),
            new Point(5, 1),
            new Point(12, 10),
            new Point(3, 4)
        };

      var (p1, p2, minDist)=FindClosestPair(points);
      Console.WriteLine($"最近的点对: {p1} 和 {p2}");
      Console.WriteLine($"最小距离: {minDist}");
      System.Console.WriteLine(@$"Finished local time is {DateTime.Now.ToString("HH:mm:ss")};");
    }

  }
}
