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
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.IO;

namespace iTelluro.Explorer.YatMing.Application
{
    /// <summary>
    /// TDataInfo基础方法的提供
    /// </summary>
    public class TDataInfoApp : ITDataInfoApp
    {
        private ITDataInfoRepository _repository;

        public TDataInfoApp(ITDataInfoRepository repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// 新增一条TDataInfo记录
        /// </summary>
        /// <param name="dto">TDataInfo实体</param>
        /// <returns>是否新增成功</returns>
        public bool Add(TDataInfoDTO dto)
        {
            try
            {
                var entity = dto.ProjectedAs<T_DataInfo>();
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

        public void DoConvert(string metaId)
        {
            string sqlselect1 = "select DataName from T_DataInfo where MetaDataId=@MetaDataId";
            SqlParameter id2 = new SqlParameter("@MetaDataId", SqlDbType.Char);
            id2.Value = metaId;
            string name = _repository.ExecuteQuery<string>(sqlselect1, new DbParameter[] { id2 }).FirstOrDefault();
            string root = System.Configuration.ConfigurationManager.AppSettings["RootUrl"];
            string path = Path.Combine(root, metaId + Path.GetExtension(name));

            string toolPath = System.Configuration.ConfigurationManager.AppSettings["ToolPath"];
            System.Diagnostics.Process.Start(toolPath, path);
        }

        public bool UploadFile(byte[] buffer, string metaId, int index)
        {
            try
            {
                //写入文件
                string sqlselect1 = "select DataName from T_DataInfo where MetaDataId=@MetaDataId";
                SqlParameter id2 = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id2.Value = metaId;
                string name = _repository.ExecuteQuery<string>(sqlselect1, new DbParameter[] { id2 }).FirstOrDefault();
                if (name.ToLower().EndsWith("mp4") || name.ToLower().EndsWith("ogg") || name.ToLower().EndsWith("webm") || name.ToLower().EndsWith("flv") || name.ToLower().EndsWith("txt") || name.ToLower().EndsWith("jpg") || name.ToLower().EndsWith("png") || name.ToLower().EndsWith("jpeg") || name.ToLower().EndsWith("bmp") || name.ToLower().EndsWith(".doc") || name.ToLower().EndsWith(".docx") || name.ToLower().EndsWith(".ppt") || name.ToLower().EndsWith(".pptx") || name.ToLower().EndsWith(".xls"))
                {
                    WriteFile(metaId + Path.GetExtension(name), buffer);
                }
                string contentName = index == 0 ? "DataContent" : "DataContent" + index;
                string sql = string.Format("update T_DataInfo set {0}=@DataContent where MetaDataId=@MetaDataId", contentName);
                List<SqlParameter> parameters = new List<SqlParameter>();
                SqlParameter content = new SqlParameter("@DataContent", SqlDbType.Image);
                //查询当前流
                string sqlselect = string.Format("select {0} from T_DataInfo where MetaDataId=@MetaDataId", contentName);
                SqlParameter id = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id.Value = metaId;
                byte[] total = _repository.ExecuteQuery<byte[]>(sqlselect, new DbParameter[] { id }).FirstOrDefault();
                //合并流
                content.Value = JoinByte(buffer, total);
                //插入流
                SqlParameter id1 = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id1.Value = metaId;
                return _repository.ExecuteCommand(sql, new DbParameter[] { content, id1 }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void WriteFile(string fileName, byte[] buffer)
        {
            try
            {
                string root = System.Configuration.ConfigurationManager.AppSettings["RootUrl"];
                using (FileStream stream = new FileStream(root + fileName, FileMode.Append))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] JoinByte(byte[] buffer, byte[] temp)
        {
            if (temp == null)
                temp = new byte[0];
            byte[] total = new byte[buffer.Length + temp.Length];
            temp.CopyTo(total, 0);
            buffer.CopyTo(total, temp.Length);
            return total;
        }

        private static byte[] SubByte(long length, byte[] total)
        {
            byte[] outstream;
            if (total.Length - length > 4096000)
                outstream = new byte[4096000];
            else
                outstream = new byte[total.Length - length];
            outstream = total.Skip((int)length).Take(outstream.Length).ToArray();
            return outstream;
        }

        public bool DownloadFile(out byte[] outstream,long length,string metaId)
        {
           
            try
            {
                int type = (int)(length / 40960000);
                string contentName = type == 0 ? "DataContent" : "DataContent" + type;
                string sql = string.Format("select {0} from T_DataInfo where MetaDataId=@MetaDataId", contentName);             
                SqlParameter id = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id.Value = metaId;
                byte[] total = _repository.ExecuteQuery<byte[]>(sql, new DbParameter[] { id }).FirstOrDefault();              
                outstream = SubByte(length % 40960000, total);
                return outstream.Length > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据主键删除一条TDataInfo记录
        /// </summary>
        /// <param name="guid">TDataInfo主键值</param>
        /// <returns>是否删除成功</returns>
        public bool Remove(string guid)
        {
            try
            {
                string sqlselect1 = "select DataName from T_DataInfo where MetaDataId=@MetaDataId";
                SqlParameter id2 = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id2.Value = guid;
                string name = _repository.ExecuteQuery<string>(sqlselect1, new DbParameter[] { id2 }).FirstOrDefault();
                if (name.ToLower().EndsWith("mp4") || name.ToLower().EndsWith("ogg") || name.ToLower().EndsWith("webm") || name.ToLower().EndsWith("flv") || name.ToLower().EndsWith("txt") || name.ToLower().EndsWith("jpg") || name.ToLower().EndsWith("png") || name.ToLower().EndsWith("jpeg") || name.ToLower().EndsWith("bmp"))
                {
                    string root = System.Configuration.ConfigurationManager.AppSettings["RootUrl"];
                    if (File.Exists(root + name + Path.GetExtension(name)))
                        File.Delete(root + name + Path.GetExtension(name));
                }
                else if (name.ToLower().EndsWith(".doc") || name.ToLower().EndsWith(".docx") || name.ToLower().EndsWith(".ppt") || name.ToLower().EndsWith(".pptx") || name.ToLower().EndsWith(".xls"))
                {
                    string root = System.Configuration.ConfigurationManager.AppSettings["RootUrl"];
                    if (File.Exists(root + name + Path.GetExtension(name)))
                        File.Delete(root + name + Path.GetExtension(name));
                    string folder = System.Configuration.ConfigurationManager.AppSettings["FileFolder"];
                    if(File.Exists(Path.Combine(folder,@"FlexPaper\swfs",guid+".swf")))
                    {
                        File.Delete(Path.Combine(folder, @"FlexPaper\swfs", guid + ".swf"));
                    }
                    if (File.Exists(Path.Combine(folder, @"FlexPaper\pdfs", guid + ".pdf")))
                    {
                        File.Delete(Path.Combine(folder, @"FlexPaper\pdfs", guid + ".pdf"));
                    }
                }
                //  return _repository.Delete(guid) > 0;

                string sql = "delete from T_DataInfo where MetaDataId=@MetaDataId";
                SqlParameter id = new SqlParameter("@MetaDataId", SqlDbType.Char);
                id.Value = guid;
                return _repository.ExecuteCommand(sql, new DbParameter[] { id }) > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 更新一条TDataInfo记录
        /// </summary>
        /// <param name="dto">TDataInfo实体</param>
        /// <returns>是否更新成功</returns>
        public bool Update(TDataInfoDTO dto)
        {
            try
            {
                string sql = "update T_DataInfo set ParentId=@ParentId,DataName=@DataName,LastModifyTime=@LastModifyTime,DataDescription=@DataDescription,DownloadTimes=@DownloadTimes where MetaDataId=@MetaDataId";
                return _repository.ExecuteCommand(sql, new DbParameter[] { new SqlParameter("@DataName", dto.DataName), new SqlParameter("@ParentId", dto.ParentId), new SqlParameter("@LastModifyTime", dto.LastModifyTime), new SqlParameter("@DataDescription", dto.DataDescription == null ? string.Empty : dto.DataDescription), new SqlParameter("@DownloadTimes", dto.DownloadTimes), new SqlParameter("@MetaDataId", dto.MetaDataId) }) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 根据TDataInfo主键获取一条记录
        /// </summary>
        /// <param name="guid">TDataInfo主键值</param>
        /// <returns>根据主键查询到的TDataInfo记录</returns>
        public TDataInfoDTO Get(string guid)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.MetaDataId == guid).Select(s => new TDataInfoDTO() { BaseInfoId = s.BaseInfoId, CreateTime = s.CreateTime, DataDescription = s.DataDescription, DataName = s.DataName, DownloadTimes = s.DownloadTimes, FileSize = s.FileSize, LastModifyTime = s.LastModifyTime, MetaDataId = s.MetaDataId, UploadPeople = s.UploadPeople,ParentId=s.ParentId }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询所有TDataInfo记录
        /// </summary>
        /// <returns>TDataInfo所有记录集合</returns>
        public List<TDataInfoDTO> GetAll()
        {
            try
            {
                return _repository.EntityNoTracking.Select(s => new TDataInfoDTO() { BaseInfoId = s.BaseInfoId, CreateTime = s.CreateTime, DataDescription = s.DataDescription, DataName = s.DataName, DownloadTimes = s.DownloadTimes, FileSize = s.FileSize, LastModifyTime = s.LastModifyTime, MetaDataId = s.MetaDataId, UploadPeople = s.UploadPeople, ParentId = s.ParentId, IsForlder = s.IsForlder }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TDataInfoDTO> GetByForginKey(string key)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.BaseInfoId == key)
                     .Select(s => new TDataInfoDTO() { BaseInfoId = s.BaseInfoId, CreateTime = s.CreateTime, DataDescription = s.DataDescription, DataName = s.DataName, DownloadTimes = s.DownloadTimes, FileSize = s.FileSize, LastModifyTime = s.LastModifyTime, MetaDataId = s.MetaDataId, UploadPeople = s.UploadPeople, ParentId = s.ParentId,IsForlder=s.IsForlder }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TDataInfoDTO> GetByParentKey(string key)
        {
            try
            {
                return _repository.EntityNoTracking.Where(t => t.ParentId == key)
                    .Select(s => new TDataInfoDTO() { BaseInfoId = s.BaseInfoId, CreateTime = s.CreateTime, DataDescription = s.DataDescription, DataName = s.DataName, DownloadTimes = s.DownloadTimes, FileSize = s.FileSize, LastModifyTime = s.LastModifyTime, MetaDataId = s.MetaDataId, UploadPeople = s.UploadPeople, ParentId = s.ParentId, IsForlder = s.IsForlder }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<TDataInfoDTO> Query(bool limit, DateTime start, DateTime end, string keyword, string baseId)
        {
            try
            {
                List<TDataInfoDTO> result = string.IsNullOrEmpty(baseId) ? GetAll() : GetByForginKey(baseId);
                if (limit)
                {
                    result = result.Where(t => t.CreateTime.Value.CompareTo(start) >= 0 && t.CreateTime.Value.CompareTo(end) <= 0).ToList();
                }
                if (string.IsNullOrEmpty(keyword) == false)
                {
                    result = result.Where(t => (t.DataName != null && t.DataName.Contains(keyword)) || (t.DataDescription != null && t.DataDescription.Contains(keyword))).ToList();
                }
                return result;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
