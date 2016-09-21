using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Common.Entity
{
    public class Parameter
    {
        /// <summary>
        /// database name
        /// </summary>
        public string SPECIFIC_SCHEMA { get; set; }
        /// <summary>
        /// function or procedure name
        /// </summary>
        public string SPECIFIC_NAME { get; set; }
        /// <summary>
        /// parameter position
        /// </summary>
        public int ORDINAL_POSITION { get; set; }
        /// <summary>
        /// parameter mode (in/out)
        /// </summary>
        public string PARAMETER_MODE { get; set; }
        /// <summary>
        /// parameter name
        /// </summary>
        public string PARAMETER_NAME { get; set; }
        /// <summary>
        /// parameter data type
        /// </summary>
        public string DATA_TYPE { get; set; }
        /// <summary>
        /// parameter maximum lenght
        /// </summary>
        public int? CHARACTER_MAXIMUM_LENGTH { get; set; }
        /// <summary>
        /// 单字符长度？
        /// </summary>
        public int? CHARACTER_OCTET_LENGTH { get; set; }
        /// <summary>
        /// 数值最大位数
        /// </summary>
        public long? NUMERIC_PRECISION { get; set; }
        /// <summary>
        /// 小数位数
        /// </summary>
        public int? NUMERIC_SCALE { get; set; }
        /// <summary>
        /// 时间精度
        /// </summary>
        public long? DATETIME_PRECISION { get; set; }
        /// <summary>
        /// 字符编码
        /// </summary>
        public string CHARACTER_SET_NAME { get; set; }
        /// <summary>
        /// 数据类型定义
        /// </summary>
        public string DTD_IDENTIFIER { get; set; }
        /// <summary>
        /// 类型（function/procedure）
        /// </summary>
        public string ROUTINE_TYPE { get; set; }
    }
}
