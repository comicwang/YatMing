using iTelluro.Explorer.YatMing.IApplication;
using iTelluro.Explorer.YatMing.Application.DTO;
using iTelluro.Explorer.Application.CodeFirst.Seedwork;
using iTelluro.Explorer.Domain.CodeFirst.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTelluro.Explorer.YatMing.Domain.Context;
using iTelluro.Explorer.YatMing.Domain.Entities;
using iTelluro.Explorer.Infrastruct.CodeFirst.Seedwork;
using System.Diagnostics;
using System.Web;
using System.Configuration;
using System.IO;

namespace iTelluro.Explorer.YatMing.Application
{
    /// <summary>
    /// TLogin基础方法的提供
    /// </summary>
    public class TLoginApp : ITLoginApp
    {
        private ITLoginRepository _repository;

        public TLoginApp(ITLoginRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TLogin记录
        /// </summary>
        /// <param name="dto">TLogin实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TLoginDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_Login>();
                if (_repository.Insert(entity) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据主键删除一条TLogin记录
        /// </summary>
        /// <param name="guid">TLogin主键值</param>
        /// <returns>是否删除成功</returns>
        public bool Remove(string guid)
        {
            try
            {
                if (_repository.Delete(guid) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新一条TLogin记录
        /// </summary>
        /// <param name="dto">TLogin实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TLoginDTO dto)
        {
            try
            {
                if (_repository.Update(dto.ProjectedAs<T_Login>()) >= 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据TLogin主键获取一条记录
        /// </summary>
        /// <param name="guid">TLogin主键值</param>
        /// <returns>根据主键查询到的TLogin记录</returns>
        public TLoginDTO Get(string guid)
        {
            try
            {
                var entity = _repository.GetByKey(guid);
                return entity.ProjectedAs<TLoginDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TLogin记录
        /// </summary>
        /// <returns>TLogin所有记录集合</returns>
        public List<TLoginDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.ProjectedAsCollection<TLoginDTO>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckAccountExits(string account)
        {
            try
            {
                T_Login checkName = _repository.EntityNoTracking.Where(t => t.LoginName == account).FirstOrDefault();
                return checkName != null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckLogin(string account, string psw, out string message,out TLoginDTO result)
        {
            try
            {
                T_Login checkName = _repository.EntityNoTracking.Where(t => t.LoginName == account).FirstOrDefault();
                if (checkName == null)
                {
                    message = "用户名不存在！";
                    result = null;
                    return false;
                }
               
                T_Login checkLogin = _repository.EntityNoTracking.Where(t => t.LoginName == account && t.LoginPsw == psw).FirstOrDefault();
                if (checkLogin == null)
                {
                    message = "密码不正确！";
                    result = null;
                    return false;
                }
                message = "登录成功..";
                result = checkLogin.ProjectedAs<TLoginDTO>();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update(out string[] uploadFileLst,out string[] deleteFileLst,out byte[][] fileContent)
        {
            bool result = true;
            try
            {
                uploadFileLst = null;
                fileContent = null;
                string[] filePaths = ConfigurationManager.AppSettings["UploadFiles"].Split(';');
                string deleteFile= ConfigurationManager.AppSettings["DeleteFiles"];
                deleteFileLst = string.IsNullOrEmpty(deleteFile) ? new string[] { } : deleteFile.Split(';');
                string forlder = ConfigurationManager.AppSettings["Forlder"];
                List<byte[]> lst = new List<byte[]>();
                List<string> fileNames = new List<string>();
                foreach (string item in filePaths)
                {
                    string path = Path.Combine(forlder, item);
                    if (string.IsNullOrEmpty(item) || File.Exists(path) == false)
                        continue;
                    FileVersionInfo version = FileVersionInfo.GetVersionInfo(path);
                    using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        lst.Add(buffer);
                        fileNames.Add(item + ";" + version.FileVersion);
                    }
                }
                uploadFileLst = fileNames.ToArray();
                fileContent = lst.ToArray();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckUpdate(string currentVersion)
        {
            try
            {
                string mainDll = ConfigurationManager.AppSettings["MainDll"];
                string Forlder = ConfigurationManager.AppSettings["Forlder"];
                FileVersionInfo info = FileVersionInfo.GetVersionInfo(Path.Combine(Forlder, mainDll));
                Version newVersion = new Version(info.FileVersion);
                Version current = new Version(currentVersion);
                return newVersion > current;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
