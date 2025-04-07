using System.Security.Principal;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfWinAuth;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
  public MainWindow()
  {
    InitializeComponent();
  }

  protected override void OnInitialized(EventArgs e)
  {
    base.OnInitialized(e);

    //## 必需登入 Windows 整合身分驗證
    StringBuilder msg = new();

    msg.AppendLine($"idName: {AuthUser.Instance.IdName}");
    msg.AppendLine($"isAdmin: {AuthUser.Instance.IsAdmin}");
    msg.AppendLine("claim lsit: ");
    foreach (var c in AuthUser.Instance.ClaimList.OrderBy(c => c.ValueType))
      msg.AppendLine($"\t{c.Value} # {c.ValueType}");

    this.messageBox.Text = msg.ToString();
  }

  private void Button_Click(object sender, RoutedEventArgs e)
  {
    MessageBox.Show("Show me the money.", "訊息", MessageBoxButton.OK, MessageBoxImage.Information);
  }
}