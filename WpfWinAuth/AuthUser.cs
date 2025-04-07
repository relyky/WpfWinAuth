using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace WpfWinAuth;

/// <summary>
/// 登入資訊儲存(singleton)
/// </summary>
internal class AuthUser
{
  private static readonly Lazy<AuthUser> instance = new Lazy<AuthUser>(() => new AuthUser());

  public static AuthUser Instance => instance.Value;

  public string IdName { get; private set; } = string.Empty;
  public bool IsAdmin { get; private set; } = false;
  public List<Claim> ClaimList { get; private set; } = [];
  public bool IsAuthenticated => !string.IsNullOrEmpty(IdName);

  private AuthUser()
  {
    WindowsIdentity identity = WindowsIdentity.GetCurrent();
    WindowsPrincipal principal = new WindowsPrincipal(identity);

    IdName = identity.Name;
    ClaimList = identity.Claims.ToList();
    IsAdmin = principal.IsInRole(WindowsBuiltInRole.Administrator);
  }
}
