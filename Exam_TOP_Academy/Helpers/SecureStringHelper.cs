using System.Runtime.InteropServices;
using System.Security;

namespace Exam_TOP_Academy.Helpers;
public static class SecureStringHelper
{
    public static bool IsStringNullOrEmpty(SecureString value)
    {
        if (value == null)
            return true;

        IntPtr bstr = IntPtr.Zero;

        try
        {
            bstr = Marshal.SecureStringToBSTR(value);
            return Marshal.PtrToStringBSTR(bstr) == string.Empty;
        }
        finally
        {
            if (bstr != IntPtr.Zero)
                Marshal.ZeroFreeBSTR(bstr);
        }
    }
}
