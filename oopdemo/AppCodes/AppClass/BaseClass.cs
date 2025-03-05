using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

/// <summary>
/// 底層類別
/// </summary>
public class BaseClass : IDisposable
{
    #region 解構子
    private bool disposed = false;
    private readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

    /// <summary>
    /// 解構,實現 IDisposable 中的 Dispose 方法
    /// </summary>
    public void Dispose(){
        //必須為true
        Dispose(true);
        //通知垃圾回收機制不再調用終端子（析構器）
        GC.SuppressFinalize(this);
    }
    /// <summary>
    /// 解構
    /// </summary>
    /// <param name="disposing">disposing</param>
    protected virtual void Dispose(bool disposing){
        if(disposed) return;
        //解構時要執行的其它程式

        if (disposing){
            handle.Dispose();
        }
        //讓類別知道自己已經被釋放
        disposed = true;
    }

    /// <summary>
    /// BaseClass 解構子
    /// </summary>
    ~BaseClass(){
        //必須為false
        Dispose(false);
    }
    #endregion
}