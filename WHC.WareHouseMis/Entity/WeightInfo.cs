using System;
using System.Xml.Serialization;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.Entity
{
    /// <summary>
    /// WeightInfo
    /// </summary>
    [Serializable]
    public class WeightInfo : BaseEntity
    {    
        #region Field Members

        private int m_ID = 0; //          
        private string m_CarNo; //          
        private string m_CardID; //          
        private decimal m_MzQty = 0; //          
        private decimal m_PzQty = 0; //          
        private decimal m_NetQty = 0; //          
        private string m_MZ_BalanceNo; //          
        private DateTime m_MZ_Time; //          
        private string m_MZ_Type; //          
        private string m_MZ_Operator; //          
        private string m_PZ_BalanceNo; //          
        private DateTime m_PZ_Time; //          
        private string m_PZ_Type; //          
        private string m_PZ_Operator; //          
        private int m_PrintStatus = 0; //          
        private int m_DataStatus = 0; //          
        private string m_Remark; //          
        private DateTime m_InsertTime; //          

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

        public virtual string CarNo
        {
            get
            {
                return this.m_CarNo;
            }
            set
            {
                this.m_CarNo = value;
            }
        }

        public virtual string CardID
        {
            get
            {
                return this.m_CardID;
            }
            set
            {
                this.m_CardID = value;
            }
        }

        public virtual decimal MzQty
        {
            get
            {
                return this.m_MzQty;
            }
            set
            {
                this.m_MzQty = value;
            }
        }

        public virtual decimal PzQty
        {
            get
            {
                return this.m_PzQty;
            }
            set
            {
                this.m_PzQty = value;
            }
        }

        public virtual decimal NetQty
        {
            get
            {
                return this.m_NetQty;
            }
            set
            {
                this.m_NetQty = value;
            }
        }

        public virtual string MZ_BalanceNo
        {
            get
            {
                return this.m_MZ_BalanceNo;
            }
            set
            {
                this.m_MZ_BalanceNo = value;
            }
        }

        public virtual DateTime MZ_Time
        {
            get
            {
                return this.m_MZ_Time;
            }
            set
            {
                this.m_MZ_Time = value;
            }
        }

        public virtual string MZ_Type
        {
            get
            {
                return this.m_MZ_Type;
            }
            set
            {
                this.m_MZ_Type = value;
            }
        }

        public virtual string MZ_Operator
        {
            get
            {
                return this.m_MZ_Operator;
            }
            set
            {
                this.m_MZ_Operator = value;
            }
        }

        public virtual string PZ_BalanceNo
        {
            get
            {
                return this.m_PZ_BalanceNo;
            }
            set
            {
                this.m_PZ_BalanceNo = value;
            }
        }

        public virtual DateTime PZ_Time
        {
            get
            {
                return this.m_PZ_Time;
            }
            set
            {
                this.m_PZ_Time = value;
            }
        }

        public virtual string PZ_Type
        {
            get
            {
                return this.m_PZ_Type;
            }
            set
            {
                this.m_PZ_Type = value;
            }
        }

        public virtual string PZ_Operator
        {
            get
            {
                return this.m_PZ_Operator;
            }
            set
            {
                this.m_PZ_Operator = value;
            }
        }

        public virtual int PrintStatus
        {
            get
            {
                return this.m_PrintStatus;
            }
            set
            {
                this.m_PrintStatus = value;
            }
        }

        public virtual int DataStatus
        {
            get
            {
                return this.m_DataStatus;
            }
            set
            {
                this.m_DataStatus = value;
            }
        }

        public virtual string Remark
        {
            get
            {
                return this.m_Remark;
            }
            set
            {
                this.m_Remark = value;
            }
        }

        public virtual DateTime InsertTime
        {
            get
            {
                return this.m_InsertTime;
            }
            set
            {
                this.m_InsertTime = value;
            }
        }


        #endregion

    }
}