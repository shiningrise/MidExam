
/******************************************************************
* 创 建 人：   shiningrise@163.com
* 创建时间：   2012-8-12 20:41:54
* 描    述：   文件操作类
*		
* 内容描述：  来自 http://www.cnblogs.com/blosaa/archive/2012/01/05/2313182.html
*              
* 版    本：   
* 修 改 人： 
* 修改内容： 
* 版    本:
******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MidExam.DAL.Util
{
    /*
        public static bool CopyDir(DirectoryInfo fromDir, string toDir); //复制目录
        public static bool CopyDir(string fromDir, string toDir); //复制目录
        public static bool CreateDir(string dirName); //创建目录
        public static bool CreateFile(string fileName); //创建文件
        public static void DeleteDir(DirectoryInfo dir); //删除目录 （如果目录中存在文件就删除）
        public static bool DeleteDir(string dir, bool onlyDir); //删除目录
        public static bool DeleteFile(string fileName);//删除文件
        public static bool Exists(string fileName);//判断文件是否存在
        public static bool FindFile(DirectoryInfo dir, string fileName);//在指定的目录中查找文件
        public static bool FindFile(string dir, string fileName);//在指定的目录中查找文件
        public static string Read(string fileName);//读文件的全部内容
        public static string ReadLine(string fileName);//读第一行数据
        public static bool Write(string fileName, string content);//写入指定的内容
        public static bool WriteLine(string fileName, string content);//写一行数据
     */
    /// <summary>
    /// 文件文件夹操作
    /// </summary>
    public static class FileHelper
    {
        #region 文件操作

        public static string FilterSpecial(string strHtml)
        {
            if (string.Empty == strHtml)
            {
                return strHtml;
            }
            string[] aryReg = { "'", "'delete", "?", "<", ">", "%", "\"\"", ",", ".", ">=", "=<", "_", ";", "||", "[", "]", "&", "/", "-", "|", " ", "''" };
            for (int i = 0; i < aryReg.Length; i++)
            {
                strHtml = strHtml.Replace(aryReg[i], string.Empty);
            }
            return strHtml;
        }

        public static string FilterFileName(string fileName)
        {
            string fileExt = GetFileExt(fileName);

            fileName = fileName.TrimEnd(fileExt.ToCharArray());
            fileName = FileHelper.FilterSpecial(fileName);
            if (string.Empty == fileName)
            {
                return fileName;
            }
            string[] aryReg = { "'", "'delete", "?", "<", ">", "%", "\"\"", ",", ".", ">=", "=<", "_", ";", "||", "[", "]", "&", "/", "-", "|", " ", "''" };
            for (int i = 0; i < aryReg.Length; i++)
            {
                fileName = fileName.Replace(aryReg[i], string.Empty);
            }
            fileName = fileName + fileExt;
            return fileName;
        }

        public static string GetFileShortName(string fileFullName)
        {
            string fileName = string.Empty;
            if (fileFullName == null || fileFullName.Trim() == "")
            {
                return string.Empty;
            }
            if (fileFullName.LastIndexOf('\\') > 0)
            {
                fileName = fileFullName.Substring(fileFullName.LastIndexOf('\\') + 1);
            }
            else
            {
                fileName = fileFullName;
            }
            return fileName;
        }

        public static string GetFileExt(string fileName)
        {
            string fileExt = string.Empty;
            if (fileName == null || fileName.Trim() == "")
            {
                return string.Empty;
            }
            if (fileName.LastIndexOf('.') > 0)
            {
                fileExt = fileName.Substring(fileName.LastIndexOf('.'));
            }
            return fileExt;
        }

        /// <summary>
        /// 判断文件是否存在
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool Exists(string fileName)
        {
            if (fileName == null || fileName.Trim() == "")
            {
                return false;
            }

            if (File.Exists(fileName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CreateFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
                fs.Dispose();
            }
            return true;

        }


        /// <summary>
        /// 读文件内容
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Read(string fileName)
        {
            if (!Exists(fileName))
            {
                return null;
            }
            //将文件信息读入流中
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return new StreamReader(fs).ReadToEnd();
            }
        }


        public static string ReadLine(string fileName)
        {
            if (!Exists(fileName))
            {
                return null;
            }
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return new StreamReader(fs).ReadLine();
            }
        }


        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">文件内容</param>
        /// <returns></returns>
        public static bool Write(string fileName, string content)
        {
            if (!Exists(fileName) || content == null)
            {
                return false;
            }

            //将文件信息读入流中
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                lock (fs)//锁住流
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件fileName=" + fileName + "是只读文件不能写入!");
                    }

                    byte[] buffer = Encoding.Default.GetBytes(content);
                    fs.Write(buffer, 0, buffer.Length);
                    return true;
                }
            }
        }


        /// <summary>
        /// 写入一行
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="content">内容</param>
        /// <returns></returns>
        public static bool WriteLine(string fileName, string content)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate | FileMode.Append))
            {
                lock (fs)
                {
                    if (!fs.CanWrite)
                    {
                        throw new System.Security.SecurityException("文件fileName=" + fileName + "是只读文件不能写入!");
                    }

                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(content);
                    sw.Dispose();
                    sw.Close();
                    return true;
                }
            }
        }


        /// <summary>
        /// 在指定的目录中查找文件
        /// </summary>
        /// <param name="dir">目录</param>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static bool FindFile(string dir, string fileName)
        {
            if (dir == null || dir.Trim() == "" || fileName == null || fileName.Trim() == "" || !Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            return FindFile(dirInfo, fileName);

        }


        public static bool FindFile(DirectoryInfo dir, string fileName)
        {
            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                if (File.Exists(d.FullName + "\\" + fileName))
                {
                    return true;
                }
                FindFile(d, fileName);
            }

            return false;
        }

        public static void FileCopy(string fromFilePath,string toFilePath,bool overwrite)
        {
            File.Copy(fromFilePath, toFilePath, overwrite);
        }

        #endregion

        #region 文件夹操作

        public static bool ExistsFolder(string folderName)
        {
            if (folderName == null || folderName.Trim() == "")
            {
                return false;
            }

            if (Directory.Exists(folderName))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="dirName"></param>
        /// <returns></returns>
        public static bool CreateDir(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                Directory.CreateDirectory(dirName);
            }
            return true;
        }

        public static bool CopyDir(DirectoryInfo fromDir, string toDir)
        {
            return CopyDir(fromDir, toDir, fromDir.FullName);
        }


        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录</param>
        /// <param name="toDir">复制到的目录</param>
        /// <returns></returns>
        public static bool CopyDir(string fromDir, string toDir)
        {
            if (fromDir == null || toDir == null)
            {
                throw new NullReferenceException("参数为空");
            }

            if (fromDir == toDir)
            {
                throw new Exception("两个目录都是" + fromDir);
            }

            if (!Directory.Exists(fromDir))
            {
                throw new IOException("目录fromDir=" + fromDir + "不存在");
            }

            DirectoryInfo dir = new DirectoryInfo(fromDir);
            return CopyDir(dir, toDir, dir.FullName);
        }


        /// <summary>
        /// 复制目录
        /// </summary>
        /// <param name="fromDir">被复制的目录</param>
        /// <param name="toDir">复制到的目录</param>
        /// <param name="rootDir">被复制的根目录</param>
        /// <returns></returns>
        private static bool CopyDir(DirectoryInfo fromDir, string toDir, string rootDir)
        {
            string filePath = string.Empty;
            foreach (FileInfo f in fromDir.GetFiles())
            {
                filePath = toDir + f.FullName.Substring(rootDir.Length);
                string newDir = filePath.Substring(0, filePath.LastIndexOf("\\"));
                CreateDir(newDir);
                File.Copy(f.FullName, filePath, true);
            }

            foreach (DirectoryInfo dir in fromDir.GetDirectories())
            {
                CopyDir(dir, toDir, rootDir);
            }

            return true;
        }


        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fileName">文件的完整路径</param>
        /// <returns></returns>
        public static bool DeleteFile(string fileName)
        {
            if (Exists(fileName))
            {
                File.Delete(fileName);
                return true;
            }
            return false;
        }


        public static void DeleteDir(DirectoryInfo dir)
        {
            if (dir == null)
            {
                throw new NullReferenceException("目录不存在");
            }

            foreach (DirectoryInfo d in dir.GetDirectories())
            {
                DeleteDir(d);
            }

            foreach (FileInfo f in dir.GetFiles())
            {
                DeleteFile(f.FullName);
            }

            dir.Delete();

        }


        /// <summary>
        /// 删除目录
        /// </summary>
        /// <param name="dir">制定目录</param>
        /// <param name="onlyDir">是否只删除目录</param>
        /// <returns></returns>
        public static bool DeleteDir(string dir, bool onlyDir)
        {
            if (dir == null || dir.Trim() == "")
            {
                throw new NullReferenceException("目录dir=" + dir + "不存在");
            }

            if (!Directory.Exists(dir))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            if (dirInfo.GetFiles().Length == 0 && dirInfo.GetDirectories().Length == 0)
            {
                Directory.Delete(dir);
                return true;
            }


            if (!onlyDir)
            {
                return false;
            }
            else
            {
                DeleteDir(dirInfo);
                return true;
            }

        }

        #endregion

        /// <summary>
        /// 将一个字符串以某一特定字符分割成字符串数组
        /// </summary>
        /// <param name="Strings">字符串</param>
        /// <param name="str">分割字符</param>
        /// <returns>string[]</returns>
        public static string[] SplitArray(string Strings, char str)
        {
            string[] strArray = Strings.Trim().Split(new char[] { str });

            return strArray;
        }

        /// <summary>
        /// 以日期为标准获得一个绝对的名称
        /// </summary>
        /// <returns>返回 String</returns>
        public static string MakeName()
        {
            /*
            string y = DateTime.Now.Year.ToString();
            string m = DateTime.Now.Month.ToString();
            string d = DateTime.Now.Day.ToString();
            string h = DateTime.Now.Hour.ToString();
            string n = DateTime.Now.Minute.ToString();
            string s = DateTime.Now.Second.ToString();
            return y + m + d + h + n + s;
            */

            return DateTime.Now.ToString("yyMMddHHmmss");
        }

        public static string AddFilePath(this string orginFilepath,string strFilepath)
        {
            strFilepath = FileHelper.FilterFileName(strFilepath);
            if (orginFilepath.EndsWith(System.IO.Path.AltDirectorySeparatorChar.ToString()) == false)
            {
                orginFilepath += System.IO.Path.DirectorySeparatorChar.ToString();
            }
            orginFilepath += strFilepath;
            return orginFilepath;
        }
    }
}
