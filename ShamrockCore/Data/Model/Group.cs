using Newtonsoft.Json;
using System.Collections.Generic;

namespace ShamrockCore.Data.Model
{
    /// <summary>
    /// 群
    /// </summary>
    public record Group
    {
        /// <summary>
        ///     群号
        /// </summary>
        [JsonProperty("group_id")]
        public long Id { get; set; }

        /// <summary>
        ///     群 Uin
        /// </summary>
        [JsonProperty("group_uin")]
        public long UinId { get; set; }

        /// <summary>
        ///     群名称
        /// </summary>
        [JsonProperty("group_name")]
        public string Name { get; set; } = "";

        /// <summary>
        ///     群备注
        /// </summary>
        [JsonProperty("group_remark")]
        public string Remark { get; set; } = "";

        /// <summary>
        ///     群分类
        /// </summary>
        [JsonProperty("class_text")]
        public string Text { get; set; } = "";

        /// <summary>
        ///     是否冻结
        /// </summary>
        [JsonProperty("is_frozen")]
        public bool Frozen { get; set; }

        /// <summary>
        ///     最大成员数
        /// </summary>
        [JsonProperty("max_member_count")]
        public int MaxCount { get; set; }

        /// <summary>
        ///     最大成员数
        /// </summary>
        [JsonProperty("max_member")]
        public int Max { get; set; }

        /// <summary>
        ///     成员数量
        /// </summary>
        [JsonProperty("member_num")]
        public int MemberNum { get; set; }

        /// <summary>
        ///     成员数量
        /// </summary>
        [JsonProperty("member_count")]
        public int MemberCount { get; set; }

        /// <summary>
        /// 管理员列表
        /// </summary>
        [JsonProperty("admins")]
        public List<long>? Admins { get; set; } = null;
    }
}