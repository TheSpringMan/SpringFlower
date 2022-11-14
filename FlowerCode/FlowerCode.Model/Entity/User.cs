using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerCode.Model.Entity;

public class User
{
      /// <summary>
        /// 主键
        /// </summary>
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
         [Required]
        public string NickName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
         [Required]
        public string Password { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
         [Required]
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 用户类型
        /// </summary>
         [Required]
        public int UserType { get; set; }
}