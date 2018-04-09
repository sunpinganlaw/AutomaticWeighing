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
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private CardInfo tempInfo = new CardInfo();
    	
        public FrmEditCard()
        {
            InitializeComponent();
        }
                
        /// <summary>
        /// 实现控件输入检查的函数
        /// </summary>
        /// <returns></returns>
        public override bool CheckInput()
        {
            bool result = true;//默认是可以通过

            #region MyRegion
            if (this.txtCardID.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtCardID.Focus();
                result = false;
            }
             else if (this.txtCarNo.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtCarNo.Focus();
                result = false;
            }
            #endregion

            return result;
        }

        /// <summary>
        /// 初始化数据字典
        /// </summary>
        private void InitDictItem()
        {
			//初始化代码
        }                        

        /// <summary>
        /// 数据显示的函数
        /// </summary>
        public override void DisplayData()
        {
            InitDictItem();//数据字典加载（公用）

            if (!string.IsNullOrEmpty(ID))
            {
                #region 显示信息
                CardInfo info = BLLFactory<Card>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
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
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
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
        /// 编辑或者保存状态下取值函数
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
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            CardInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据
                //检查是否还有其他相同关键字的记录
                bool exist = BLLFactory<Card>.Instance.IsExistKey("CardID", info.CardID);
                  if (exist)
                {
                    MessageDxUtil.ShowTips("指定的【车卡号】已经存在，不能重复添加，请修改");
                    return false;
                }

                bool succeed = BLLFactory<Card>.Instance.Insert(info);
                if (succeed)
                {
                    //可添加其他关联操作

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
        /// 编辑状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveUpdated()
        {
			//检查不同ID是否还有其他相同关键字的记录
			string condition = string.Format("CardID ='{0}' and ID <> '{1}' ", this.txtCardID.Text, ID);
            bool exist = BLLFactory<Card>.Instance.IsExistRecord(condition);
             if (exist)
            {
                MessageDxUtil.ShowTips("指定的【车卡号】已经存在，不能重复添加，请修改");
                return false;
            }

            CardInfo info = BLLFactory<Card>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<Card>.Instance.Update(info, info.ID);
                    if (succeed)
                    {
                        //可添加其他关联操作
                       
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
