using System.Runtime.InteropServices;

namespace WorkTool.Core.Modules.Windows.Interfaces;

[ComImport]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
[Guid("B2F925B9-5A0F-4D2E-9F4D-2B1507593C10")]
public interface IVirtualDesktopManagerInternal
{
    int             GetCount(IntPtr                      hWndOrMon);
    void            MoveViewToDesktop(IApplicationView   view, IVirtualDesktop desktop);
    bool            CanViewMoveDesktops(IApplicationView view);
    IVirtualDesktop GetCurrentDesktop(IntPtr             hWndOrMon);
    void            GetDesktops(IntPtr                   hWndOrMon, out IObjectArray desktops);
    [PreserveSig]
    int GetAdjacentDesktop(IVirtualDesktop from, int direction, out IVirtualDesktop desktop);
    void SwitchDesktop(IntPtr hWndOrMon, IVirtualDesktop desktop);
    IVirtualDesktop CreateDesktop(IntPtr hWndOrMon);
    void MoveDesktop(IVirtualDesktop desktop, IntPtr hWndOrMon, int nIndex);
    void RemoveDesktop(IVirtualDesktop desktop, IVirtualDesktop fallback);
    IVirtualDesktop FindDesktop(ref Guid desktopid);
    void GetDesktopSwitchIncludeExcludeViews(IVirtualDesktop desktop, out IObjectArray unknown1, out IObjectArray unknown2);
    void SetDesktopName(IVirtualDesktop desktop, [MarshalAs(UnmanagedType.HString)] string name);
    void SetDesktopWallpaper(IVirtualDesktop desktop, [MarshalAs(UnmanagedType.HString)] string path);
    void UpdateWallpaperPathForAllDesktops([MarshalAs(UnmanagedType.HString)] string path);
    void CopyDesktopState(IApplicationView pView0, IApplicationView pView1);
    int GetDesktopIsPerMonitor();
    void SetDesktopIsPerMonitor(bool state);
}