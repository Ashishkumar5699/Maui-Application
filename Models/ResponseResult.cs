using System;
using System.Diagnostics.CodeAnalysis;

namespace Punjab_Ornaments.Models
{
    public class ExecResult
    {
        public bool HasErrors { get; set; }
        public bool IsSystemError { get; set; }
        public string Message { get; set; }
    }

    public class ResponseResult<TDataType> : ExecResult
    {
        [AllowNull]
        public TDataType Data { get; set; }
    }
}

