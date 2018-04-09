using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Pager.Entity;
using WHC.Dictionary;
using WHC.Framework.BaseUI;
using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using WHC.WareHouseMis.BLL;
using WHC.WareHouseMis.Entity;

namespace WHC.WareHouseMis.UI
{
    public partial class FrmEditCard : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private CardInfo tempInfo = new CardInfo();
    	
        public FrmEditCard()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// ʵ�ֿؼ�������ĺ���
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//Ĭ���ǿ���ͨ��

            #region MyRegion
            if (this.txtCardID.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCardID.Focus();
                result = false;
            }
             else if (this.txtCarNo.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCarNo.Focus();
                result = false;
            }
            #endregion

            return result;
        }

        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
			//��ʼ������
        }                        

        /// <summary>
        /// ������ʾ�ĺ���
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//�����ֵ���أ����ã�

            if (!string.IsNullOrEmpty(ID))
            {
                #region ��ʾ��Ϣ
                CardInfo info = BLLFactory<Card>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtCardID.Text = info.CardID;
           	                    txtCarNo.Text = info.CarNo;
           	                    txtDriver.Text = info.Driver;
           	                    txtTransportUnit.Text = info.TransportUnit;
                               txtRegisterTime.SetDateTime(info.RegisterTime);	
                       txtExpireTime.SetDateTime(info.ExpireTime);	
   	                    txtOperator.Text = info.Operator;
           	                    txtGoods.Text = info.Goods;
           	                    txtTelNo.Text = info.TelNo;
           	                    txtReamark.Text = info.Reamark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("Card/Edit");             
            }
            else
            {
          
                //this.btnOK.Enabled = Portal.gc.HasFunction("Card/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(CardInfo info)
        //{
        //    this.attachmentGUID.AttachmentGUID = info.AttachGUID;
        //    this.attachmentGUID.userId = LoginUserInfo.Name;

        //    string name = txtName.Text;
        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        string dir = string.Format("{0}", name);
        //        this.attachmentGUID.Init(dir, tempInfo.ID, LoginUserInfo.Name);
        //    }
        //}

        public override void ClearScreen()
        {
            this.tempInfo = new CardInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(CardInfo info)
        {
	            info.CardID = txtCardID.Text;
           	            info.CarNo = txtCarNo.Text;
           	            info.Driver = txtDriver.Text;
           	            info.TransportUnit = txtTransportUnit.Text;
                       info.RegisterTime = txtRegisterTime.DateTime;
               info.ExpireTime = txtExpireTime.DateTime;
   	            info.Operator = txtOperator.Text;
           	            info.Goods = txtGoods.Text;
           	            info.TelNo = txtTelNo.Text;
           	            info.Reamark = txtReamark.Text;
                   }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            CardInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������
                //����Ƿ���������ͬ�ؼ��ֵļ�¼
                bool exist = BLLFactory<Card>.Instance.IsExistKey("CardID", info.CardID);
                  if (exist)
                {
                    MessageDxUtil.ShowTips("ָ���ġ������š��Ѿ����ڣ������ظ���ӣ����޸�");
                    return false;
                }

                bool succeed = BLLFactory<Card>.Instance.Insert(info);
                if (succeed)
                {
                    //�����������������

                    return true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                LogTextHelper.Error(ex);
                MessageDxUtil.ShowError(ex.Message);
            }
            return false;
        }                 

        /// <summary>
        /// �༭״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
			//��鲻ͬID�Ƿ���������ͬ�ؼ��ֵļ�¼
			string condition = string.Format("CardID ='{0}' and ID <> '{1}' ", this.txtCardID.Text, ID);
            bool exist = BLLFactory<Card>.Instance.IsExistRecord(condition);
             if (exist)
            {
                MessageDxUtil.ShowTips("ָ���ġ������š��Ѿ����ڣ������ظ���ӣ����޸�");
                return false;
            }

            CardInfo info = BLLFactory<Card>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = BLLFactory<Card>.Instance.Update(info, info.ID);
                    if (succeed)
                    {
                        //�����������������
                       
                        return true;
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    LogTextHelper.Error(ex);
                    MessageDxUtil.ShowError(ex.Message);
                }
            }
           return false;
        }
    }
}
