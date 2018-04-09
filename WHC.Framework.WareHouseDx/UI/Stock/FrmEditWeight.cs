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
    public partial class FrmEditWeight : BaseEditForm
    {
    	/// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
    	private WeightInfo tempInfo = new WeightInfo();
    	
        public FrmEditWeight()
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
            if (this.txtCarNo.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCarNo.Focus();
                result = false;
            }
             else if (this.txtCardID.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("������");
                this.txtCardID.Focus();
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
                WeightInfo info = BLLFactory<Weight>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����
                	
	                    txtCarNo.Text = info.CarNo;
           	                    txtCardID.Text = info.CardID;
                                   txtMzQty.Value = info.MzQty;
                               txtPzQty.Value = info.PzQty;
                               txtNetQty.Value = info.NetQty;
       	                    txtMZ_BalanceNo.Text = info.MZ_BalanceNo;
                               txtMZ_Time.SetDateTime(info.MZ_Time);	
   	                    txtMZ_Type.Text = info.MZ_Type;
           	                    txtMZ_Operator.Text = info.MZ_Operator;
           	                    txtPZ_BalanceNo.Text = info.PZ_BalanceNo;
                               txtPZ_Time.SetDateTime(info.PZ_Time);	
   	                    txtPZ_Type.Text = info.PZ_Type;
           	                    txtPZ_Operator.Text = info.PZ_Operator;
           	                    txtRemark.Text = info.Remark;
                             } 
                #endregion
                //this.btnOK.Enabled = HasFunction("Weight/Edit");             
            }
            else
            {
              
                //this.btnOK.Enabled = Portal.gc.HasFunction("Weight/Add");  
            }
            
            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(WeightInfo info)
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
            this.tempInfo = new WeightInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(WeightInfo info)
        {
	            info.CarNo = txtCarNo.Text;
           	            info.CardID = txtCardID.Text;
                           info.MzQty = txtMzQty.Value;
                       info.PzQty = txtPzQty.Value;
                       info.NetQty = txtNetQty.Value;
       	            info.MZ_BalanceNo = txtMZ_BalanceNo.Text;
                       info.MZ_Time = txtMZ_Time.DateTime;
   	            info.MZ_Type = txtMZ_Type.Text;
           	            info.MZ_Operator = txtMZ_Operator.Text;
           	            info.PZ_BalanceNo = txtPZ_BalanceNo.Text;
                       info.PZ_Time = txtPZ_Time.DateTime;
   	            info.PZ_Type = txtPZ_Type.Text;
           	            info.PZ_Operator = txtPZ_Operator.Text;
           	            info.Remark = txtRemark.Text;
                   }
         
        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WeightInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);

            try
            {
                #region ��������

                bool succeed = BLLFactory<Weight>.Instance.Insert(info);
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

            WeightInfo info = BLLFactory<Weight>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = BLLFactory<Weight>.Instance.Update(info, info.ID);
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
