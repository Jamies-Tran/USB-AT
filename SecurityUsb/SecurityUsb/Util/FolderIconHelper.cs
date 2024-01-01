using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

public class FolderIconHelper
{
    private const uint SHGFI_ICON = 0x100;
    private const uint SHGFI_LARGEICON = 0x0;
    private const uint SHGFI_SMALLICON = 0x1;

    [DllImport("shell32.dll")]
    private static extern IntPtr SHGetFileInfo(
        string pszPath,
        uint dwFileAttributes,
        ref SHFILEINFO psfi,
        uint cbSizeFileInfo,
        uint uFlags
    );

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    private struct SHFILEINFO
    {
        public IntPtr hIcon;
        public IntPtr iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    public static Icon GetFolderIcon(string folderPath, bool largeIcon = true)
    {
        SHFILEINFO shFileInfo = new SHFILEINFO();
        uint flags = SHGFI_ICON | (largeIcon ? SHGFI_LARGEICON : SHGFI_SMALLICON);

        IntPtr result = SHGetFileInfo(
            folderPath,
            0,
            ref shFileInfo,
            (uint)Marshal.SizeOf(shFileInfo),
            flags
        );

        if (result != IntPtr.Zero)
        {
            Icon icon = Icon.FromHandle(shFileInfo.hIcon);
            return icon;
        }

        return null;
    }
}
