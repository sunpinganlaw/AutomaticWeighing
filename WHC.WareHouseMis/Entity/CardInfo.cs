using System;
using System.Xml.Serialization;
using WHC.Framework.ControlUtil;

namespace WHC.WareHouseMis.Entity
{
    /// <summary>
    /// CardInfo
    /// </summary>
    [Serializable]
    public class CardInfo : BaseEntity
    {
        #region Field Members

        private int m_ID = 0; //          
        private string m_CardID; //          
        private string m_CarNo; //          
        private string m_Driver; //          
        private string m_TransportUnit; //          
        private DateTime m_RegisterTime; //          
        private DateTime m_ExpireTime; //          
        private string m_Operator; //          
        private string m_Goods; //          
        private string m_TelNo; //          
        private DateTime m_InsertTime; //          
        private int m_DataStatus = 0; //          
        private string m_Reamark; //          

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

        public virtual string Driver
        {
            get
            {
                return this.m_Driver;
            }
            set
            {
                this.m_Driver = value;
            }
        }

        public virtual string TransportUnit
        {
            get
            {
                return this.m_TransportUnit;
            }
            set
            {
                this.m_TransportUnit = value;
            }
        }

        public virtual DateTime RegisterTime
        {
            get
            {
                return this.m_RegisterTime;
            }
            set
            {
                this.m_RegisterTime = value;
            }
        }

        public virtual DateTime ExpireTime
        {
            get
            {
                return this.m_ExpireTime;
            }
            set
            {
                this.m_ExpireTime = value;
            }
        }

        public virtual string Operator
        {
            get
            {
                return this.m_Operator;
            }
            set
            {
                this.m_Operator = value;
            }
        }

        public virtual string Goods
        {
            get
            {
                return this.m_Goods;
            }
            set
            {
                this.m_Goods = value;
            }
        }

        public virtual string TelNo
        {
            get
            {
                return this.m_TelNo;
            }
            set
            {
                this.m_TelNo = value;
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

        public virtual string Reamark
        {
            get
            {
                return this.m_Reamark;
            }
            set
            {
                this.m_Reamark = value;
            }
        }


        #endregion

    }
}