using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Reflection;

public static class VHelper
{
    public static List<Guid> ToGuidList(this string[] ids)
    {
        if (ids == null)
        {
            return null;
        }
        List<Guid> list = new List<Guid>();
        foreach (var id in ids)
        {
            list.Add(id.ToGuid());
        }
        return list;
    }
    public static List<Guid> ToGuidList(this Guid[] ids)
    {
        if (ids == null)
        {
            return null;
        }
        List<Guid> list = new List<Guid>();
        foreach (var id in ids)
        {
            list.Add(id);
        }
        return list;
    }

    #region 常用处理

    /// <summary>
    /// 对象是否为NULL
    /// </summary>
    /// <param name="str">对象</param>
    /// <returns>是否为NULL</returns>
    public static bool IsNull(this object obj)
    {
        if (obj == null)
        {
            return true;
        }
        else if (obj is DateTime && obj.ToDateTime().Equals(DateTime.MinValue))
        {
            return true;
        }
        else if (obj is Guid && obj.ToGuid() == Guid.Empty )
        {
            return true;;
        }
        return false;
    }

    /// <summary>
    /// 字符串是否为空
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>是否为空</returns>
    public static bool IsEmpty(this string str)
    {
        if (IsNull(str))
        {
            return true;
        }
        if (str.Equals(String.Empty))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 字符串不为NULL
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>返回字符串</returns>
    public static string IfNull(this object str)
    {
        if (str == null)
        {
            return String.Empty;
        }
        return str.ToString();
    }

    /// <summary>
    /// 字符串不为NULL
    /// </summary>
    /// <param name="str">要验证字符串</param>
    /// <param name="val">为空返回字符串</param>
    /// <returns>返回字符串</returns>
    public static string IfNull(this string str, string retStr)
    {
        if (str == null)
        {
            return retStr;
        }
        return str;
    }

    /// <summary>
    /// 字符串数组转换成数字
    /// </summary>
    /// <param name="strs">字符串</param>
    /// <returns>数字</returns>
    public static int[] StrsToInts(this string[] strs)
    {
        int[] ints = new int[strs.Length];
        for (int i = 0; i < strs.Length; i++)
        {
            ints[i] = Convert.ToInt32(strs[i]);
        }
        return ints;
    }
    
    /// <summary>
    /// 返回字符串真实长度 1个汉字长度为2
    /// </summary>
    /// <param name="str">字符串</param>
    /// <returns>实际字符串长度</returns>
    public static int GetCharLength(this string str)
    {
        return Encoding.Default.GetBytes(str).Length;
    }

    /// <summary>
    /// 取左边固定长度的字符串
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="len">长度</param>
    /// <returns>截取后的字符串</returns>
    public static string Left(this string s, int len)
    {
        if (len > s.Length)
        {
            len = s.Length;
        }
        return s.Substring(0, len);
    }
    /// <summary>
    /// 取右边固定长度的字符串
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="len">长度</param>
    /// <returns>截取后的字符串</returns>
    public static string Right(this string s, int len)
    {
        if (len > s.Length)
        {
            len = s.Length;
        }
        return s.Substring(s.Length - len, len);
    }
    /// <summary>
    /// 取某一位开始的固定长度字符串
    /// </summary>
    /// <param name="s">字符串</param>
    /// <param name="start">开始位置 从1开始计数</param>
    /// <param name="len">截取长度</param>
    /// <returns>截取后的字符串</returns>
    public static string Substring(this string s, int start, int len)
    {
        if (start >= s.Length - 1)
        {
            return "";
        }

        if (len > (s.Length - start))
        {
            len = s.Length - start;
        }
        return s.Substring(start, len);
    }

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式 3:指定高宽缩放（可能变形）2:指定宽，高按比例 1:指定高，宽按比例0:指定高宽裁减（不变形）</param>    
    public static bool MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, int mode)
    {
        bool isSuccess = true;
        Image originalImage = Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case 3://指定高宽缩放（可能变形）                
                break;
            case 2://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case 1://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case 0://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        Image bitmap = new Bitmap(towidth, toheight);

        //新建一个画板
        Graphics g = Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(Color.White);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new Rectangle(0, 0, towidth, toheight),
            new Rectangle(x, y, ow, oh),
            GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, ImageFormat.Jpeg);
        }
        catch (System.Exception ex)
        {
            isSuccess = false;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
        return isSuccess;
    }

    /// <summary>
    /// 根据属性名提取属性值
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="obj">要提取的对象</param>
    /// <param name="name">属性名</param>
    /// <returns>提取出的属性值</returns>
    public static object GetPropertyByName<T>(T obj, string name)
    {
        try
        {
            Type t = obj.GetType();
            PropertyInfo pi = t.GetProperty(name);
            return pi.GetValue(obj, null);
        }
        catch (System.Exception ex)
        {
        }
        return new Object();
    }

    /// <summary>
    /// 根据属性名设置值
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="obj">要设置的对象</param>
    /// <param name="name">属性名</param>
    /// <param name="val">属性值</param>
    /// <returns>设置值后的对象</returns>
    public static T SetPropertyByName<T>(T obj, string name, object val)
    {
        try
        {
            Type t = obj.GetType();
            PropertyInfo pi = t.GetProperty(name);
            pi.SetValue(obj, val, null);
        }
        catch (System.Exception ex)
        {
        }
        return obj;
    }

    #endregion

    #region 网页
    
    #region COOKIE
    /// <summary>
    /// 读取Cookie
    /// </summary>
    /// <typeparam name="T">要读取的类名</typeparam>
    /// <param name="Name">Cookie名</param>
    /// <returns>读取的数据</returns>
    public static T CookieRead<T>(string Name)
    {
        System.Web.HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies[Name];
        T _data = default(T);
        if (cookie != null)
        {
            string __data = cookie.Value;
            _data = BinaryDeserialize<T>(__data);
        }
        return _data;
    }

    /// <summary>
    /// 写入Cookie
    /// </summary>
    /// <typeparam name="T">写入的类，需加[Serializable]标记,否则无法序列化</typeparam>
    /// <param name="Name">Cookie名</param>
    /// <param name="data">数据</param>
    /// <param name="Expires">有效期</param>
    /// <param name="Domain">有效域</param>
    /// <returns></returns>
    public static bool CookieWrite<T>(string Name, T data, TimeSpan Expires, string Domain)
    {
        try
        {
            System.Web.HttpCookie cookie = new System.Web.HttpCookie(Name);
            cookie.Value = BinarySerializer<T>(data);
            if (Expires.TotalMinutes > 0)
            {
                cookie.Expires = DateTime.Now.Add(Expires);
            }
            cookie.Domain = Domain;

            System.Web.HttpContext.Current.Response.AppendCookie(cookie);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// 写入Cookie
    /// </summary>
    /// <typeparam name="T">写入的类，需加[Serializable]标记,否则无法序列化</typeparam>
    /// <param name="Name">Cookie名</param>
    /// <param name="data">数据</param>
    /// <param name="Expires">有效期(单位分钟)</param>
    /// <param name="Domain">有效域</param>
    /// <returns></returns>
    public static bool CookieWrite<T>(string Name, T data, int Expires, string Domain)
    {
        TimeSpan t = TimeSpan.FromMinutes(Expires);
        return CookieWrite<T>(Name, data, t, Domain);
    }

    /// <summary>
    /// 清空cookie
    /// </summary>
    public static void Clear()
    {
        foreach (string s in System.Web.HttpContext.Current.Response.Cookies.AllKeys)
        {
            System.Web.HttpContext.Current.Response.Cookies[s].Expires = DateTime.Now.AddDays(-1);
        }
    }
    #endregion

    #region 序列化
    /// <summary>
    /// 序列化类
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="iPack">实体类</param>
    /// <returns>序列化的类</returns>
    public static string BinarySerializer<T>(T iPack)
    {
        try
        {
            using (System.IO.MemoryStream mS = new System.IO.MemoryStream())
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                b.Serialize(mS, iPack);
                mS.Seek(0, System.IO.SeekOrigin.Begin);
                string s = System.Convert.ToBase64String(mS.GetBuffer(), 0, (int)mS.Length);
                mS.Close();
                return s;
            }
        }
        catch (Exception ex)
        {
            return "";
        }
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    /// <param name="iData">序列化字符串</param>
    /// <returns>实体类</returns>
    public static T BinaryDeserialize<T>(string iData)
    {
        try
        {
            using (System.IO.MemoryStream mS = new System.IO.MemoryStream(System.Convert.FromBase64String(iData)))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter b = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                T obj = (T)b.Deserialize(mS);
                mS.Close();
                return obj;
            }
        }
        catch (Exception ex)
        {
            return default(T);
        }
    }
    #endregion

    #region HTML编码/解码
    /// <summary>
    /// URL解码
    /// </summary>
    /// <param name="str">要解码的字符串</param>
    /// <returns>解码后的字符串</returns>
    public static string UrlDecode(this string str)
    {
        try
        {
            return HttpUtility.UrlDecode(str);
        }
        catch (Exception ex)
        {
        }
        return str;
    }

    /// <summary>
    /// URL编码
    /// </summary>
    /// <param name="str">要编码的字符串</param>
    /// <returns>编码后的字符串</returns>
    public static string UrlEncode(this string str)
    {
        try
        {
            return HttpUtility.UrlEncode(str);
        }
        catch (Exception ex)
        {
        }
        return str;
    }

    /// <summary>
    /// HTML解码
    /// </summary>
    /// <param name="str">要解码的字符串</param>
    /// <returns>解码后的字符串</returns>
    public static string HtmlDecode(this string str)
    {
        try
        {
            return HttpUtility.HtmlDecode(str);
        }
        catch (Exception ex)
        {
        }
        return str;
    }

    /// <summary>
    /// HTML编码
    /// </summary>
    /// <param name="str">要编码的字符串</param>
    /// <returns>编码后的字符串</returns>
    public static string HtmlEncode(this string str)
    {
        try
        {
            return HttpUtility.HtmlEncode(str);
        }
        catch (Exception ex)
        {
        }
        return str;
    }

    #endregion

    #region Session

    /// <summary>
    /// 是否存在
    /// </summary>
    /// <param name="Name"></param>
    /// <returns></returns>
    public static bool SessionIsExist(string Name)
    {
        return !(System.Web.HttpContext.Current.Session[Name] == null);
    }

    /// <summary>
    /// 读取Session值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Name"></param>
    /// <returns></returns>
    public static T SessionRead<T>(string Name)
    {
        T d = default(T);
        try
        {
            d = (T)System.Web.HttpContext.Current.Session[Name];
        }
        catch (Exception ex)
        {
            d = default(T);
        }

        return d;
    }

    /// <summary>
    /// 写入Session值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Name"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static bool SessionWrite<T>(string Name, T data)
    {
        return SessionWrite<T>(Name, data, 0);
    }

    /// <summary>
    /// 写入Session值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Name"></param>
    /// <param name="data"></param>
    /// <param name="Expires"></param>
    /// <returns></returns>
    public static bool SessionWrite<T>(string Name, T data, int Expires)
    {
        try
        {
            if (Expires > 0)
            {
                System.Web.HttpContext.Current.Session.Timeout = Expires;
            }

            System.Web.HttpContext.Current.Session[Name] = data;
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;

    }
    /// <summary>
    /// 写入Session值
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="Name"></param>
    /// <param name="data"></param>
    /// <param name="Expires"></param>
    /// <returns></returns>
    public static bool SessionWrite<T>(string Name, T data, TimeSpan Expires)
    {
        return SessionWrite<T>(Name, data, ToInt(Expires.TotalMinutes));
    }

    /// <summary>
    /// 清空Session
    /// </summary>
    public static void SessionClear()
    {
        System.Web.HttpContext.Current.Session.Clear();
        System.Web.HttpContext.Current.Session.Abandon();
    }

    #endregion

    #region Request数据

    #region 获取QueryString数据
    /// <summary>
    /// 读取QueryString数据
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string QueryString(string key)
    {
        try
        {
            return System.Web.HttpContext.Current.Request.QueryString[key].ToString();
        }
        catch
        {
            return "";
        }
    }

    #region 获取GUID
    /// <summary>
    /// 获取GUID 出错时返回Guid.Empty
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static Guid QueryStringGuid(string key)
    {
        return ToGuid(QueryString(key));
    }

    /// <summary>
    /// 获取GUID
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">获取不到时的默认值</param>
    /// <returns>获取到的值</returns>
    public static Guid QueryStringGuid(string key, Guid def)
    {
        return ToGuid(QueryString(key), def);
    }
    #endregion

    #region Enum
    /// <summary>
    /// 获取枚举类型 出错时返回default(T)
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static T QueryStringEnum<T>(string key)
    {
        return ToEnum<T>(QueryString(key));
    }

    /// <summary>
    /// 获取枚举类型
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static T QueryStringEnum<T>(string key, T def)
    {
        return ToEnum<T>(QueryString(key), def);
    }
    #endregion

    #region Int
    /// <summary>
    /// 返回整数 出错时返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static int QueryStringInt(string key)
    {
        return ToInt(QueryString(key));
    }

    /// <summary>
    /// 获取整数
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static int QueryStringInt(string key, int def)
    {
        return ToInt(QueryString(key), def);

    }
    #endregion

    #region Long
    /// <summary>
    /// 获取整数 出错时返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static long QueryStringLong(string key)
    {
        return ToLong(QueryString(key));
    }
    /// <summary>
    /// 获取整数
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static long QueryStringLong(string key, long def)
    {
        return ToLong(QueryString(key), def);

    }
    #endregion

    #region Double
    /// <summary>
    /// 获取Double 获取出错返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static double QueryStringDouble(string key)
    {
        return ToDouble(QueryString(key));
    }

    /// <summary>
    /// 获取Double
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static double QueryStringDouble(string key, double def)
    {
        return ToDouble(QueryString(key), def);

    }
    #endregion

    #region DateTime
    /// <summary>
    /// 获取时间,出错时返回DateTime.MinValue
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static DateTime QueryStringDateTime(string key)
    {
        return ToDateTime(QueryString(key));
    }
    /// <summary>
    /// 获取时间
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static DateTime QueryStringDateTime(string key, DateTime def)
    {
        return ToDateTime(QueryString(key), def);
    }
    #endregion

    #region TimeSpan
    /// <summary>
    /// 获取时间间隔,默认为new TimeSpan()
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static TimeSpan QueryStringTimeSpan(string key)
    {
        return ToTimeSpan(QueryString(key));
    }
    /// <summary>
    /// 获取时间间隔
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static TimeSpan QueryStringTimeSpan(string key, TimeSpan def)
    {
        return ToTimeSpan(QueryString(key), def);
    }
    #endregion
    #endregion

    #region 获取Form数据
    /// <summary>
    /// 读取Form数据
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    public static string Form(string key)
    {
        try
        {
            return System.Web.HttpContext.Current.Request.Form[key].ToString();
        }
        catch
        {
            return "";
        }
    }

    #region 获取GUID
    /// <summary>
    /// 获取GUID 出错时返回Guid.Empty
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static Guid FormGuid(string key)
    {
        return ToGuid(Form(key));
    }

    /// <summary>
    /// 获取GUID
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">获取不到时的默认值</param>
    /// <returns>获取到的值</returns>
    public static Guid FormGuid(string key, Guid def)
    {
        return ToGuid(Form(key), def);
    }
    #endregion

    #region Enum
    /// <summary>
    /// 获取枚举类型 出错时返回default(T)
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static T FormEnum<T>(string key)
    {
        return ToEnum<T>(Form(key));
    }

    /// <summary>
    /// 获取枚举类型
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static T FormEnum<T>(string key, T def)
    {
        return ToEnum<T>(Form(key), def);
    }
    #endregion

    #region Int
    /// <summary>
    /// 返回整数 出错时返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static int FormInt(string key)
    {
        return ToInt(Form(key));
    }

    /// <summary>
    /// 获取整数
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static int FormInt(string key, int def)
    {
        return ToInt(Form(key), def);

    }
    #endregion

    #region Long
    /// <summary>
    /// 获取整数 出错时返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static long FormLong(string key)
    {
        return ToLong(Form(key));
    }
    /// <summary>
    /// 获取整数
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static long FormLong(string key, long def)
    {
        return ToLong(Form(key), def);

    }
    #endregion

    #region Double
    /// <summary>
    /// 获取Double 获取出错返回0
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static double FormDouble(string key)
    {
        return ToDouble(Form(key));
    }

    /// <summary>
    /// 获取Double
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static double FormDouble(string key, double def)
    {
        return ToDouble(Form(key), def);

    }
    #endregion

    #region DateTime
    /// <summary>
    /// 获取时间,出错时返回DateTime.MinValue
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static DateTime FormDateTime(string key)
    {
        return ToDateTime(Form(key));
    }
    /// <summary>
    /// 获取时间
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static DateTime FormDateTime(string key, DateTime def)
    {
        return ToDateTime(Form(key), def);
    }
    #endregion

    #region TimeSpan
    /// <summary>
    /// 获取时间间隔,默认为new TimeSpan()
    /// </summary>
    /// <param name="key">参数名</param>
    /// <returns>获取到的值</returns>
    public static TimeSpan FormTimeSpan(string key)
    {
        return ToTimeSpan(Form(key));
    }
    /// <summary>
    /// 获取时间间隔
    /// </summary>
    /// <param name="key">参数名</param>
    /// <param name="def">默认值</param>
    /// <returns>获取到的值</returns>
    public static TimeSpan FormTimeSpan(string key, TimeSpan def)
    {
        return ToTimeSpan(Form(key), def);
    }
    #endregion
    #endregion


    #endregion

    #endregion

    #region 类型转换

    #region 时间特殊转换（以1970-1-1 08：00：00为基准）
    /// <summary>
    /// 时间转换成秒数（以1970-1-1 08：00：00为基准）
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static long DateTime2Long(DateTime d)
    {
        return (long)(d - new DateTime(1970, 1, 1, 8, 0, 0)).TotalSeconds;
    }

    /// <summary>
    /// 秒数转成时间（以1970-1-1 08：00：00为基准）
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static DateTime Long2DateTime(long d)
    {
        return new DateTime(1970, 1, 1, 8, 0, 0).AddSeconds(d);
    }
    #endregion

    #region 枚举转换
    /// <summary>
    /// 枚举转换（value可以为数字或名字的字符串）
    /// </summary>
    /// <typeparam name="T">枚举类名</typeparam>
    /// <param name="value">值</param>
    /// <param name="def">默认值</param>
    /// <returns></returns>
    public static T ToEnum<T>(object value)
    {
        return ToEnum(value, default(T));
    }
    public static T ToEnum<T>(object value, T def)
    {
        if (IsNull(value))
        {
            return def;
        }
        T r = def;
        try
        {
            r = (T)System.Enum.Parse(typeof(T), value.ToString());
        }
        catch (Exception ex)
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region Guid
    /// <summary>
    /// Guid转换函数(转换出错赋值Guid.Empty)
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <returns>转换后的数值</returns>
    public static Guid ToGuid(this object value)
    {
        return ToGuid(value, Guid.Empty);
    }
    /// <summary>
    /// Guid转换函数
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <param name="def">默认值</param>
    /// <returns>转换后的数值</returns>
    public static Guid ToGuid(this object value, Guid def)
    {
        string s = "";
        if (value != null)
            s = value.ToString();
        else
            return def;
        if (IsGuid(s))
        {
            return new Guid(s);
        }
        else
        {
            return def;
        }
    }

    private static bool IsGuid(string strToValidate)
    {
        bool isGuid = false;
        string strRegexPatten = @"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\"
                + @"-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$";
        if (strToValidate != null && !strToValidate.Equals(""))
        {
            isGuid = System.Text.RegularExpressions.Regex.IsMatch(strToValidate, strRegexPatten);
        }
        return isGuid;
    }
    #endregion

    #region Int
    /// <summary>
    /// 转为整数（出错默认值0）
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <returns>转换后的数值</returns>
    public static int ToInt(this object value)
    {
        return ToInt(value, 0);
    }
    /// <summary>
    /// 转为整数
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <param name="def">默认值</param>
    /// <returns>转换后的数值</returns>
    public static int ToInt(this object value, int def)
    {
        string s = value.ToString();
        int r = def;
        if (!int.TryParse(s, out r))
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region Long
    /// <summary>
    /// 转为整数（出错默认值0）
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <returns>转换后的数值</returns>
    public static long ToLong(this object value)
    {
        return ToLong(value, 0);
    }
    /// <summary>
    /// 转为整数
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <param name="def">默认值</param>
    /// <returns>转换后的数值</returns>
    public static long ToLong(this object value, long def)
    {
        string s = value.ToString();
        long r = def;
        bool t = long.TryParse(s, out r);
        if (!t)
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region Double
    /// <summary>
    /// 转为小数（出错默认值0）
    /// </summary>
    /// <param name="value">要转换的数值</param>
    /// <returns>转换后的数值</returns>
    public static double ToDouble(this object value)
    {
        return ToDouble(value, 0);
    }
    /// <summary>
    /// 转为小数
    /// </summary>
    /// <param name="value"></param>
    /// <param name="def">无法转换的默认值</param>
    /// <returns></returns>
    public static double ToDouble(this object value, double def)
    {
        string s = value.ToString();
        double r = def;
        bool t = double.TryParse(s, out r);
        if (!t)
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region 时间
    /// <summary>
    /// 转为时间（出错默认值DateTime.MinValue）
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static System.DateTime ToDateTime(this object value)
    {
        return ToDateTime(value, DateTime.MinValue);
    }
    /// <summary>
    /// 转为时间
    /// </summary>
    /// <param name="value"></param>
    /// <param name="def">无法转换的默认值</param>
    /// <returns></returns>
    public static System.DateTime ToDateTime(this object value, System.DateTime def)
    {
        string s = value.ToString();
        System.DateTime r = def;
        bool t = System.DateTime.TryParse(s, out r);
        if (!t)
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region 时间描述
    /// <summary>
    /// 转成间隔描述(几天前 几小时前 几分钟前)
    /// </summary>
    /// <param name="ts">时间间隔</param>
    /// <returns></returns>
    public static string TimeDescription(this TimeSpan ts)
    {
        if (ts.TotalDays >= 1)
            return ts.Days.ToString() + "天前";
        if (ts.TotalHours >= 1)
            return ts.Hours.ToString() + "小时前";
        return ts.Minutes.ToString() + "分钟前";
    }

    /// <summary>
    /// 转成间隔描述(几天前 几小时前 几分钟前)
    /// </summary>
    /// <param name="ts">要和当前时间比较的时间</param>
    /// <returns></returns>
    public static string TimeDescription(this DateTime da)
    {
        return TimeDescription(DateTime.Now - da);
    }
    #endregion

    #region 时间间隔
    /// <summary>
    /// 转为时间间隔（出错默认值new TimeSpan()）
    /// </summary>
    /// <param name="value">要转换的值</param>
    /// <returns>转换后的值</returns>
    public static System.TimeSpan ToTimeSpan(this object value)
    {
        return ToTimeSpan(value, new TimeSpan());
    }
    /// <summary>
    /// 转为时间间隔
    /// </summary>
    /// <param name="value">要转换的值</param>
    /// <param name="def">默认值</param>
    /// <returns>转换后的值</returns>
    public static System.TimeSpan ToTimeSpan(this object value, System.TimeSpan def)
    {
        string s = value.ToString();
        System.TimeSpan r = def;
        bool t = System.TimeSpan.TryParse(s, out r);
        if (!t)
        {
            r = def;
        }
        return r;
    }
    #endregion

    #region Bool
    /// <summary>
    /// Bool（出错默认值false）
    /// </summary>
    /// <param name="value">要转换的值</param>
    /// <returns>转换后的值</returns>
    public static bool ToBool(this object value)
    {
        return ToBool(value, false);
    }
    /// <summary>
    /// 转为Bool
    /// </summary>
    /// <param name="value">要转换的值</param>
    /// <param name="def">默认值</param>
    /// <returns>转换后的值</returns>
    public static bool ToBool(this object value, bool def)
    {
        if (value.IsNull())
            return false;
        string s = value.ToString().Trim().ToLower();
        if (s == "on" || s == "1" || s.ToLower() == "true")
            return true;
        else
            return false;
    }
    #endregion

    #region 时间格式转换
    /// <summary>
    /// 返回yyyy-MM-dd HH:mm:ss格式化后的字符串
    /// </summary>
    /// <param name="dt">要转换的时间</param>
    /// <returns>转换后的字符串</returns>
    public static string TimeToString(object dt)
    {
        return dt.TimeToString("yyyy-MM-dd HH:mm:ss");
    }
    /// <summary>
    /// 自定义时间格式转换 
    /// {常用符号yyyy-MM-dd HH:mm:ss} 转换出错返回当前时间
    /// </summary>
    /// <param name="dt">要转换的时间</param>
    /// <param name="f">时间字符串</param>
    /// <returns>转换后的字符串</returns>
    public static string TimeToString(this object dt, string f)
    {
        return ToDateTime(dt).ToString(f);
    }

    /// <summary>
    /// 转换yyyy-MM-dd
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string TimeToStringDate(this object dt)
    {
        return dt.TimeToString("yyyy-MM-dd");
    }

    /// <summary>
    /// 转换yyyy年MM月dd日
    /// </summary>
    /// <param name="dt"></param>
    /// <returns></returns>
    public static string TimeToStringDateCN(System.DateTime dt)
    {
        return dt.TimeToString("yyyy年MM月dd日");
    }
    #endregion
    #endregion

    #region 获取金额的大写中文文字
    /// <summary>
    /// 获取金额的大写中文文字   返回：中文数字文字
    /// </summary>
    /// <param name="mvarOrDollar">金额</param>
    /// <param name="mstrLanguage">格式 P：中文简体 C：繁体中文</param>
    /// <returns>转换后的字符串</returns>
    public static string GetDollorStr(this double mvarOrDollar)
    {
        if (mvarOrDollar == 0)
            return "零";
        else
            return GetDollorStr(mvarOrDollar, "P");             //返回简体中文的中文描述
    }
    public static string GetDollorStr(this double mvarOrDollar, string mstrLanguage)
    {
        if (mvarOrDollar == 0 && mstrLanguage == "P")
            return "零";
        else if (mvarOrDollar == 0 && mstrLanguage == "C")
            return "箂";

        string t_word;
        string WLAMT;
        //            double tt;
        t_word = "";
        //            If mstrLanguage = "E" Or mstrLanguage = "e" Then
        //                t_word = t_word + noinword(Int(mvarOrDollar))
        //                If mvarOrDollar <> Int(mvarOrDollar) Then
        //                    tt = Int((mvarOrDollar - Int(mvarOrDollar)) * 100)
        //                    t_word = t_word & "And " & " Cents " & noinword(tt)
        //                End If
        //                 
        //            Else
        //            WLAMT = mvarOrDollar.ToString();
        WLAMT = StrFormat(mvarOrDollar, 12, 2);

        for (int i = 0; i < 12; i++)
        {
            if (i != 9)
                t_word = t_word + SHRCHG(WLAMT, WLAMT.Substring(i, 1), i, mstrLanguage);

        }
        string spacestr = "";
        t_word = t_word + spacestr.PadLeft(40 - t_word.Length, ' ');

        //            End If
        return t_word.Trim();
    }

    private static string SHRCHG(string WLAMT, string WLCD, int WLLOC, string mstrLanguage)
    {
        string WLNAME;
        string WLDD;
        if (mstrLanguage == "C")
            WLDD = "货ㄕ珺窾ㄕ珺じ  àだ";
        else
            //WLDD = "亿千百十万千百十元 角分";
            WLDD = "亿仟佰拾万仟佰拾 角分";

        WLNAME = "    ";
        switch (WLCD)
        {
            case " ":
                WLNAME = "   ";
                break;
            case "1":
                //WLNAME = IIf(mstrLanguage = "C", "滁", "壹") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "滁" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "壹" + WLDD.Substring(WLLOC, 1);
                break;
            case "2":
                //'WLNAME = IIf(mstrLanguage = "C", "禠", "贰") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "禠" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "贰" + WLDD.Substring(WLLOC, 1);

                break;
            case "3":
                //'WLNAME = IIf(mstrLanguage = "C", "把", "叁") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "把" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "叁" + WLDD.Substring(WLLOC, 1);

                break;
            case "4":
                //'WLNAME = IIf(mstrLanguage = "C", "竩", "肆") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "竩" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "肆" + WLDD.Substring(WLLOC, 1);

                break;
            case "5":
                //'WLNAME = IIf(mstrLanguage = "C", "ヮ", "伍") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "ヮ" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "伍" + WLDD.Substring(WLLOC, 1);

                break;
            case "6":
                //'WLNAME = IIf(mstrLanguage = "C", "嘲", "陆") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "嘲" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "陆" + WLDD.Substring(WLLOC, 1);

                break;
            case "7":
                //'WLNAME = IIf(mstrLanguage = "C", "琺", "柒") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "琺" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "柒" + WLDD.Substring(WLLOC, 1);

                break;
            case "8":
                //'WLNAME = IIf(mstrLanguage = "C", "", "捌") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "捌" + WLDD.Substring(WLLOC, 1);
                break;
            case "9":
                //'WLNAME = IIf(mstrLanguage = "C", "╤", "玖") + Mid(WLDD, (WLLOC - 1) * 2 + 1, 2)
                if (mstrLanguage.Equals("C"))
                    WLNAME = "╤" + WLDD.Substring(WLLOC, 1);
                else
                    WLNAME = "玖" + WLDD.Substring(WLLOC, 1);
                break;
            case "0":
                string locList = "123567";
                if (locList.IndexOf(WLLOC.ToString().Trim()) > 0 && WLAMT.Substring(WLLOC + 1, 1) != "0")
                    if (mstrLanguage.Equals("C"))
                        WLNAME = "箂";
                    else
                        WLNAME = "零";
                else
                    WLNAME = "";
                if (WLAMT.Substring(WLLOC, 1) == ".")
                    WLNAME = WLDD.Substring(WLLOC, 1);

                if (WLLOC == 4 && (WLAMT.Substring(1, 1) != "0" || WLAMT.Substring(2, 1) != "0" || WLAMT.Substring(3, 1) != "0"))
                    if (mstrLanguage.Equals("C"))
                        WLNAME = "窾";
                    else
                        WLNAME = "万";
                break;

        }
        return WLNAME.Trim();
    }

    private static string StrFormat(double Tlong, int Along, int Adec)
    {
        string tstr;

        tstr = Tlong.ToString().Trim();
        if (tstr.IndexOf(".") == -1)
        {
            tstr += ".00";
        }
        else
        {
            if (tstr.IndexOf(".") == 0)
            {
                tstr = "0" + tstr;
            }
            if (tstr.IndexOf(".") == tstr.Length - 1)  //0.  case
            {
                tstr = tstr + "0";
            }
            if (tstr.Substring(tstr.IndexOf(".") + 1).Length == 1)
            {
                tstr = tstr + "0";
            }
            else
            {
                tstr = tstr.Substring(0, tstr.IndexOf(".") + 3);
            }

        }
        if (tstr.Length < 12)
            tstr = tstr.PadLeft(12, ' ');
        return tstr;
    }
    #endregion

    #region HEX
    /// <summary>
    /// 校验相应位数是否是1
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static bool HexCheckNum(string num1, int num2)
    {
        string nS = HexAnd(num1, HexNum(num2));
        if (nS == "0")
            return false;
        else
            return true;
    }


    /// <summary>
    /// 对就位数的十六进制串
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string HexNum(int num)
    {
        string r = "0" + "[0]";
        if (num > 0)
        {
            int tcount = (num - 1) / 4;
            int tFew = (num - 1) % 4;
            int t = 1;
            for (int i = 0; i < tFew; i++)
                t *= 2;
            r = t.ToString();
            for (int i = 0; i < tcount; i++)
                r += "0";
        }
        return r;
    }

    /// <summary>
    /// 与操作
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static string HexAnd(string num1, string num2)
    {
        //补足操作
        int len = num1.Length > num2.Length ? num1.Length : num2.Length;
        num1 = HexComplement(num1, len);
        num2 = HexComplement(num2, len);
        string r = "";
        for (int i = 0; i < len; i++)
        {
            r += HexAnd(num1[i], num2[i]).ToString();
            //num1[]
        }

        return HexCut(r);
    }
    /// <summary>
    /// 与操作
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static char HexAnd(char num1, char num2)
    {

        return HexInt2Char(HexChar2Int(num1) & HexChar2Int(num2));
    }
    /// <summary>
    /// 或操作
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static string HexOr(string num1, string num2)
    {
        //补足操作
        int len = num1.Length > num2.Length ? num1.Length : num2.Length;
        num1 = HexComplement(num1, len);
        num2 = HexComplement(num2, len);
        string r = "";
        for (int i = 0; i < len; i++)
        {
            r += HexOr(num1[i], num2[i]).ToString();
            //num1[]
        }

        return HexCut(r);
    }
    /// <summary>
    /// 或操作
    /// </summary>
    /// <param name="num1"></param>
    /// <param name="num2"></param>
    /// <returns></returns>
    public static char HexOr(char num1, char num2)
    {
        return HexInt2Char(HexChar2Int(num1) | HexChar2Int(num2));
    }
    /// <summary>
    /// 非操作
    /// </summary>
    /// <param name="num1"></param>
    /// <returns></returns>
    public static string HexNon(string num1)
    {
        string r = "";
        for (int i = 0; i < num1.Length; i++)
        {
            r += HexNon(num1[i]).ToString();
            //num1[]
        }

        return HexCut(r);
    }
    /// <summary>
    /// 非操作
    /// </summary>
    /// <param name="num1"></param>
    /// <returns></returns>
    public static char HexNon(char num1)
    {
        return HexInt2Char(~HexChar2Int(num1));
    }

    private static byte HexChar2Byte(char num)
    {
        int t = System.Convert.ToInt32(num.ToString(), 16);
        return BitConverter.GetBytes(t)[0];
    }
    private static char HexByte2Char(byte num)
    {
        string s = num.ToString("X");
        return s[s.Length - 1];
    }

    private static int HexChar2Int(char num)
    {
        return System.Convert.ToInt32(num.ToString(), 16);
        //return BitConverter.GetBytes(t)[0];
    }

    private static char HexInt2Char(int num)
    {
        string s = System.Convert.ToString(num, 16);
        return s[s.Length - 1];
    }
    /// <summary>
    /// 补足位数
    /// </summary>
    /// <param name="num">原十六进制串</param>
    /// <param name="length">长度</param>
    /// <returns>补足后的十六进制串</returns>
    private static string HexComplement(string num, int length)
    {
        if (num.Length < length)
        {
            int bu = length - num.Length;
            string bus = "";
            for (int i = 0; i < bu; i++)
                bus += "0";
            num = bus + num;
        }
        return num;
    }

    /// <summary>
    /// 清除打头的'0'
    /// </summary>
    /// <param name="num">原十六进制串</param>
    /// <returns>清除后的十六进制串</returns>
    private static string HexCut(string num)
    {
        string r = "";
        int i = 0;
        for (i = 0; i < num.Length; i++)
            if (num[i] != '0')
                break;
        for (; i < num.Length; i++)
            r += num[i].ToString();

        if (r == "")
            r = "0";
        return r.ToUpper();
    }
    #endregion
}
