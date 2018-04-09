using System;
using System.Xml.Serialization;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.Entity
{
    [Serializable]
    public class ItemDetailInfo : BaseEntity
    {    
        #region Field Members

        private int m_ID = 0;         
        private string m_ItemNo = ""; //备件编号          
        private string m_ItemName = ""; //备件名称       
        private string m_Manufacture = ""; //供应商   
        private string m_MapNo = ""; //图号          
        private string m_Specification = ""; //规格型号          
        private string m_Material = ""; //材质          
        private string m_ItemBigType = ""; //备件属类          
        private string m_ItemType = ""; //备件类别          
        private string m_Unit = ""; //单位          
        private decimal m_Price = 0; //单价          
        private string m_Source = ""; //来源          
        private string m_StoragePos = ""; //库位          
        private string m_UsagePos = ""; //使用位置        
        private string m_Note = ""; //备注     
        private string m_WareHouse = ""; //库房编号          
        private string m_Dept = ""; //部门    

        #endregion

        #region Property Members
        
        public virtual int ID
        {
            get
            {
                return this.m_ID;
            }
            set
            {
                this.m_ID = value;
            }
        }

        /// <summary>
        /// 备件编号
        /// </summary>
        public virtual string ItemNo
        {
            get
            {
                return this.m_ItemNo;
            }
            set
            {
                this.m_ItemNo = value;
            }
        }

        /// <summary>
        /// 备件名称
        /// </summary>
        public virtual string ItemName
        {
            get
            {
                return this.m_ItemName;
            }
            set
            {
                this.m_ItemName = value;
            }
        }

        /// <summary>
        /// 供应商
        /// </summary>
        public virtual string Manufacture
        {
            get
            {
                return this.m_Manufacture;
            }
            set
            {
                this.m_Manufacture = value;
            }
        }

        /// <summary>
        /// 图号
        /// </summary>
        public virtual string MapNo
        {
            get
            {
                return this.m_MapNo;
            }
            set
            {
                this.m_MapNo = value;
            }
        }

        /// <summary>
        /// 规格型号
        /// </summary>
        public virtual string Specification
        {
            get
            {
                return this.m_Specification;
            }
            set
            {
                this.m_Specification = value;
            }
        }

        /// <summary>
        /// 材质
        /// </summary>
        public virtual string Material
        {
            get
            {
                return this.m_Material;
            }
            set
            {
                this.m_Material = value;
            }
        }

        /// <summary>
        /// 备件属类
        /// </summary>
        public virtual string ItemBigType
        {
            get
            {
                return this.m_ItemBigType;
            }
            set
            {
                this.m_ItemBigType = value;
            }
        }

        /// <summary>
        /// 备件类别
        /// </summary>
        public virtual string ItemType
        {
            get
            {
                return this.m_ItemType;
            }
            set
            {
                this.m_ItemType = value;
            }
        }

        /// <summary>
        /// 单位
        /// </summary>
        public virtual string Unit
        {
            get
            {
                return this.m_Unit;
            }
            set
            {
                this.m_Unit = value;
            }
        }

        /// <summary>
        /// 单价
        /// </summary>
        public virtual decimal Price
        {
            get
            {
                return this.m_Price;
            }
            set
            {
                this.m_Price = value;
            }
        }

        /// <summary>
        /// 来源
        /// </summary>
        public virtual string Source
        {
            get
            {
                return this.m_Source;
            }
            set
            {
                this.m_Source = value;
            }
        }

        /// <summary>
        /// 库位
        /// </summary>
        public virtual string StoragePos
        {
            get
            {
                return this.m_StoragePos;
            }
            set
            {
                this.m_StoragePos = value;
            }
        }

        /// <summary>
        /// 使用位置
        /// </summary>
        public virtual string UsagePos
        {
            get
            {
                return this.m_UsagePos;
            }
            set
            {
                this.m_UsagePos = value;
            }
        }

        /// <summary>
        /// 备注
        /// </summary>
        public virtual string Note
        {
            get
            {
                return this.m_Note;
            }
            set
            {
                this.m_Note = value;
            }
        }

        /// <summary>
        /// 库房编号
        /// </summary>
        public virtual string WareHouse
        {
            get
            {
                return this.m_WareHouse;
            }
            set
            {
                this.m_WareHouse = value;
            }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public virtual string Dept
        {
            get
            {
                return this.m_Dept;
            }
            set
            {
                this.m_Dept = value;
            }
        }

        #endregion

    }
}