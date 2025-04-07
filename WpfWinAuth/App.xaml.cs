using System.Configuration;
using System.Data;
using System.Security.Principal;
using System.Windows;

namespace WpfWinAuth;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
  protected override void OnStartup(StartupEventArgs e)
  {
    base.OnStartup(e);

    //## 必需登入 Windows 整合身分驗證
    var identity = WindowsIdentity.GetCurrent();
    if (identity == null)
    {
      MessageBox.Show("Windows 身分驗證失敗，應用程式將關閉。", "錯誤", MessageBoxButton.OK, MessageBoxImage.Error);
      Shutdown();
      return;
    }
  }
}
