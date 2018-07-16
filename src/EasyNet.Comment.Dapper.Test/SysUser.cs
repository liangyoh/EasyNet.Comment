using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNet.Comment.Dapper.Test
{
    public class SysUser
    {
        /// <summary>
        /// 账号
        /// </summary>		
        public string LoginName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>		
        public string Password { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>		
        public string Name { get; set; }
        /// <summary>
        /// 头像
        /// </summary>		
        public string Icon { get; set; }
        /// <summary>
        /// 密码加密盐
        /// </summary>		
        public string Salt { get; set; }
        /// <summary>
        /// 性别编码
        /// </summary>		
        public int SexCode { get; set; }
        /// <summary>
        /// 性别
        /// </summary>		
        public string Sex { get; set; }
        /// <summary>
        /// 工号
        /// </summary>		
        public string BizCode { get; set; }
        /// <summary>
        /// 证件编码
        /// </summary>		
        public string CredentialsCode { get; set; }
        /// <summary>
        /// 证件名称
        /// </summary>		
        public string Credentials { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>		
        public string IdNumber { get; set; }
        /// <summary>
        /// 生日
        /// </summary>		
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 雇用日期
        /// </summary>		
        public DateTime? HireDate { get; set; }
        /// <summary>
        /// 部门编码
        /// </summary>		
        public string DepartmentCode { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>		
        public string Department { get; set; }
        /// <summary>
        /// 工种编码
        /// </summary>		
        public string KindOfWorkCode { get; set; }
        /// <summary>
        /// 工种
        /// </summary>		
        public string KindOfWork { get; set; }
        /// <summary>
        /// 行政等级编码
        /// </summary>		
        public string ADGradeCode { get; set; }
        /// <summary>
        /// 行政等级
        /// </summary>		
        public string ADGrade { get; set; }
        /// <summary>
        /// 职务编码
        /// </summary>		
        public string PostCode { get; set; }
        /// <summary>
        /// 职务
        /// </summary>		
        public string Post { get; set; }
        /// <summary>
        /// PositionalTitles
        /// </summary>		
        public string PositionalTitles { get; set; }
        /// <summary>
        /// 联系电话
        /// </summary>		
        public string ContactNumber { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>		
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 住址
        /// </summary>		
        public string Address { get; set; }
        /// <summary>
        /// 邮件
        /// </summary>		
        public string Email { get; set; }
        /// <summary>
        /// 备注
        /// </summary>		
        public string Remark { get; set; }
    }
}

