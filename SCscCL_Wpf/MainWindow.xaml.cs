using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SCscCL_Wpf {
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window {
    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

    const uint SWP_NOMOVE = 0x0002;
    const uint SWP_NOSIZE = 0x0001;
    IntPtr HWND_TOPMOST = new IntPtr(-1);
    private DispatcherTimer timer;

    public MainWindow() {
      InitializeComponent();

      // 初始化定时器  
      timer=new DispatcherTimer();
      timer.Tick+=Timer_Tick; // 设置Tick事件处理函数  
      timer.Interval=TimeSpan.FromSeconds(1); // 设置时间间隔为1秒  
      timer.Start(); // 启动定时器  

      // 初始显示时间  
      UpdateTimeDisplay();

      // 设置窗口为顶层  
      //SetWindowPos(new WindowInteropHelper(this).Handle, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE|SWP_NOSIZE);
    }
    private void Timer_Tick(object sender, EventArgs e) {
      // 每秒更新时间显示  
      UpdateTimeDisplay();
    }

    private void UpdateTimeDisplay() {
      // 获取当前时间，并格式化为字符串  
      string currentTime = DateTime.Now.ToString("HH:mm:ss");
      timeTextBlock.Text=currentTime; // 更新TextBlock的Text属性
      timeTextState.Text=$"{获取下个节点的分钟数()}";
    }

    private string 获取下个节点的分钟数() {
      DateTime now = DateTime.Now;
      DateTime today0600 = DateTime.Today.AddHours(6);// 6:00 AM toady
      DateTime today0900 = DateTime.Today.AddHours(9);// 9:00 AM toady
      DateTime today1130 = DateTime.Today.AddHours(11.9); // 11:54 AM today
      DateTime today1330 = DateTime.Today.AddHours(13.5); // 1:30 PM today
      DateTime today1800 = DateTime.Today.AddHours(18);   // 6:00 PM today
      DateTime today2200 = DateTime.Today.AddHours(22);   // 10:00 PM today
      DateTime tomorrow0600 = today0600.AddDays(1);
      if(now<today0900) {
        TimeSpan diff = today0900-now;
        return $"距离上班时间还有：{(int)diff.TotalMinutes}分钟";
      } else if(now<today1130) {
        TimeSpan diff = today1130-now;
        return $"距离午休还有：{(int)diff.TotalMinutes}分钟";
      } else if(now<today1330) {
        TimeSpan diff = today1330-now;
        return $"距离下午上班还有：{(int)diff.TotalMinutes}分钟";
      } else if(now<today1800) {
        TimeSpan diff = today1800-now;
        return $"距离下班还有：{(int)diff.TotalMinutes}分钟";
      } else if(now<today2200) {
        TimeSpan diff = today2200-now;
        return $"距离晚上睡觉还有：{(int)diff.TotalMinutes}分钟";
      } else if(now<tomorrow0600) {
        TimeSpan diff = tomorrow0600-now;
        return $"距离起床睡觉还有：{(int)diff.TotalMinutes}分钟";
      }
      return $"未知错误";
    }

    // 窗口关闭时停止定时器（可选）  
    protected override void OnClosed(EventArgs e) {
      timer.Stop();
      base.OnClosed(e);
    }


  }
}