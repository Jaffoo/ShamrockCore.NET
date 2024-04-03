using UniBot.Model;

namespace UniBot.Message
{
    /// <summary>
    /// 戳一戳
    /// </summary>
    public class PokeMessage : MessageBase
    {
        public override Messages Type => Messages.Poke;

        public PokeMessage(int type, int id, string name = "")
        {
            Data = new Body()
            {
                Id = id,
                Name = name,
                Type = type,
            };
        }

        /// <summary>
        /// 消息体
        /// </summary>
        public class Body
        {
            /// <summary>
            /// 类型
            /// </summary>
            public int Type { get; set; }

            /// <summary>
            /// id
            /// </summary>
            public int Id { get; set; }

            /// <summary>
            /// 表情名
            /// </summary>
            public string Name { get; set; } = "";
        }
    }

    /// <summary>
    /// 戳一戳
    /// </summary>
    public class Poke : PokeMessage
    {
        public Poke() : base(1, -1, "戳一戳")
        {
        }
    }

    /// <summary>
    /// 比心
    /// </summary>
    public class ShowLove : PokeMessage
    {
        public ShowLove() : base(2, -1, "比心")
        {
        }
    }

    /// <summary>
    /// 点赞
    /// </summary>
    public class Like : PokeMessage
    {
        public Like() : base(3, -1, "点赞")
        {
        }
    }

    /// <summary>
    /// 心碎
    /// </summary>
    public class Heartbroken : PokeMessage
    {
        public Heartbroken() : base(4, -1, "心碎")
        {
        }
    }

    /// <summary>
    /// 666
    /// </summary>
    public class SixSixSix : PokeMessage
    {
        public SixSixSix() : base(5, -1, "666")
        {
        }
    }

    /// <summary>
    /// 放大招
    /// </summary>
    public class FangDaZhao : PokeMessage
    {
        public FangDaZhao() : base(6, -1, "放大招")
        {
        }
    }

    /// <summary>
    /// 宝贝球 (SVIP)
    /// </summary>
    public class BaoBeiQiu : PokeMessage
    {
        public BaoBeiQiu() : base(126, 2011, "宝贝球")
        {
        }
    }

    /// <summary>
    /// 玫瑰花 (SVIP) 
    /// </summary>
    public class Rose : PokeMessage
    {
        public Rose() : base(126, 2007, "玫瑰花")
        {
        }
    }

    /// <summary>
    /// 召唤术 (SVIP) 
    /// </summary>
    public class ZhaoHuanShu : PokeMessage
    {
        public ZhaoHuanShu() : base(126, 2006, "召唤术")
        {
        }
    }

    /// <summary>
    /// 让你皮 (SVIP)
    /// </summary>
    public class RangNiPi : PokeMessage
    {
        public RangNiPi() : base(126, 2009, "让你皮")
        {
        }
    }

    /// <summary>
    /// 结印 (SVIP)
    /// </summary>
    public class JieYin : PokeMessage
    {
        public JieYin() : base(126, 2005, "结印")
        {
        }
    }

    /// <summary>
    /// 手雷 (SVIP)
    /// </summary>
    public class ShouLei : PokeMessage
    {
        public ShouLei() : base(126, 2004, "手雷")
        {
        }
    }

    /// <summary>
    /// 勾引 (SVIP)
    /// </summary>
    public class GouYin : PokeMessage
    {
        public GouYin() : base(126, 2003, "勾引")
        {
        }
    }

    /// <summary>
    /// 抓一下 (SVIP)
    /// </summary>
    public class ZhuaYiXia : PokeMessage
    {
        public ZhuaYiXia() : base(126, 2001, "抓一下")
        {
        }
    }

    /// <summary>
    /// 碎屏 (SVIP)
    /// </summary>
    public class SuiPing : PokeMessage
    {
        public SuiPing() : base(126, 2002, "碎屏")
        {
        }
    }

    /// <summary>
    /// 敲门 (SVIP)
    /// </summary>
    public class QiaoMen : PokeMessage
    {
        public QiaoMen() : base(126, 2002, "敲门")
        {
        }
    }
}
