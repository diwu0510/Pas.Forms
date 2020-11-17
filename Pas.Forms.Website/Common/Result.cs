using System;
using System.Collections.Generic;

namespace Pas.Forms.Website.Common
{
    public class Result
    {
        public int Code { get; set; }

        public string Message { get; set; }

        public Result()
        { }

        public Result(int code, string message = "")
        {
            Code = code;
            Message = message;
        }
    }

    public class Result<T> : Result
    {
        public T Body { get; set; }

        public Result()
        { }

        public Result(int code, T body, string message = "")
        {
            Code = code;
            Body = body == null ? default(T) : body;
            Message = message;
        }
    }

    public class PageList<T>
    {
        public int RecordCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public List<T> Body { get; set; }

        protected PageList()
        { }

        public PageList(List<T> body, int recordCount, int pageIndex, int pageSize)
        {
            Body = body;
            RecordCount = recordCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }

    public class PageList : PageList<dynamic>
    { }

    public class PageListResult<T> : Result
    {
        public int PageSize { get; set; }

        public int PageIndex { get; set; }

        public int RecordCount { get; set; }

        public IEnumerable<T> Body { get; set; }

        public PageListResult()
        { }

        public PageListResult(int code, PageList<T> pageList, string message = "")
        {
            Code = code;
            Message = message;
            PageSize = pageList.PageSize;
            PageIndex = pageList.PageIndex;
            RecordCount = pageList.RecordCount;
            Body = pageList.Body;
        }

        public PageListResult(int code, IEnumerable<T> body, int pageIndex, int pageSize, int recordCount, string message = "")
        {
            Code = code;
            Body = body;
            PageSize = pageSize;
            PageIndex = pageIndex;
            RecordCount = recordCount;
            Message = message;
        }
    }

    public class ResultUtil
    {
        #region 通用返回结果
        /// <summary>
        /// 返回操作结果及说明，无返回值
        /// </summary>
        /// <param name="code">结果码</param>
        /// <param name="message">结果说明</param>
        /// <returns></returns>
        public static Result Return(int code, string message)
        {
            return new Result { Code = code, Message = message };
        }

        /// <summary>
        /// 返回操作结果及说明，有返回值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code">结果码</param>
        /// <param name="body">操作结果</param>
        /// <param name="message">结果说明</param>
        /// <returns></returns>
        public static Result<T> Return<T>(int code, T body, string message)
        {
            return new Result<T> { Code = code, Body = body, Message = message };
        }
        #endregion

        #region 操作成功
        /// <summary>
        /// 操作成功
        /// </summary>
        /// <param name="msg">操作结果说明</param>
        /// <returns></returns>
        public static Result Success(string msg = "")
        {
            return Return(200, msg);
        }

        /// <summary>
        /// 操作成功
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body">操作结果</param>
        /// <param name="msg">操作结果说明</param>
        /// <returns></returns>
        public static Result<T> Success<T>(T body, string msg = "")
        {
            return Return(200, body, msg);
        }
        #endregion

        #region 操作失败
        /// <summary>
        /// 一般类型操作失败，无返回
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result Fail(string msg = "操作失败")
        {
            return Return(204, msg);
        }

        public static Result<T> Fail<T>(T body, string msg = "操作失败")
        {
            return Return(204, body, msg);
        }
        #endregion

        #region 身份验证失败
        /// <summary>
        /// 身份验证失败，未登录
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result AuthenticationError(string msg = "您尚未登录")
        {
            return Return(401, msg);
        }
        #endregion

        #region 权限验证失败
        /// <summary>
        /// 权限验证失败，无模块权限或数据权限
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result AuthorizeError(string msg = "您无权使用此功能")
        {
            return Return(403, msg);
        }
        #endregion

        #region 验证失败
        /// <summary>
        /// 数据验证失败，模型验证或请求参数验证失败等
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result AuthFail(string msg = "验证失败")
        {
            return Return(204, msg);
        }

        /// <summary>
        /// 数据验证失败，模型验证失败或请求参数验证失败等
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result<T> AuthFail<T>(T body, string msg = "验证失败")
        {
            return Return(204, body, msg);
        }
        #endregion

        #region 空数据
        /// <summary>
        /// 数据获取失败，请求的数据不存在
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static Result NotFound(string msg = "请求的资源不存在")
        {
            return Return(404, msg);
        }

        public static Result<T> NotFound<T>(string msg = "请求的资源不存在", T body = default)
        {
            return Return<T>(404, body, msg);
        }
        #endregion

        #region 系统错误
        /// <summary>
        /// 返回系统错误
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static Result Exception(Exception ex)
        {
            return Return(500, ex.Message);
        }
        #endregion

        #region 列表
        /// <summary>
        /// 返回列表结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static Result<IEnumerable<T>> List<T>(IEnumerable<T> body, int code = 200, string message = "")
        {
            return Return(code, body, message);
        }

        /// <summary>
        /// 返回分页列表结果
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="body"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static PageListResult<T> PageList<T>(PageList<T> body, int code = 200, string message = "")
        {
            return new PageListResult<T>
            {
                Code = code,
                Message = message,
                Body = body.Body,
                PageIndex = body.PageIndex,
                PageSize = body.PageSize,
                RecordCount = body.RecordCount
            };
        }

        public static PageListResult<T> PageList<T>(int total, List<T> body, int pageIndex, int pageSize, int code = 200, string message = "")
        {
            return new PageListResult<T>
            {
                Code = code,
                Message = message,
                Body = body,
                PageIndex = pageIndex,
                PageSize = pageSize,
                RecordCount = total
            };
        }
        #endregion
    }
}
