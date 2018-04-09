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
        /// 创建一个临时对象，方便在附件管理中获取存在的GUID
        /// </summary>
    	private WeightInfo tempInfo = new WeightInfo();
    	
        public FrmEditWeight()
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
            if (this.txtCarNo.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtCarNo.Focus();
                result = false;
            }
             else if (this.txtCardID.Text.Trim().Length == 0)
            {
                MessageDxUtil.ShowTips("请输入");
                this.txtCardID.Focus();
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
                WeightInfo info = BLLFactory<Weight>.Instance.FindByID(ID);
                if (info != null)
                {
                	tempInfo = info;//重新给临时对象赋值，使之指向存在的记录对象
                	
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
            
            //tempInfo在对象存在则为指定对象，新建则是全新的对象，但有一些初始化的GUID用于附件上传
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
        /// 编辑或者保存状态下取值函数
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
        /// 新增状态下的数据保存
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            WeightInfo info = tempInfo;//必须使用存在的局部变量，因为部分信息可能被附件使用
            SetInfo(info);

            try
            {
                #region 新增数据

                bool succeed = BLLFactory<Weight>.Instance.Insert(info);
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

            WeightInfo info = BLLFactory<Weight>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region 更新数据
                    bool succeed = BLLFactory<Weight>.Instance.Update(info, info.ID);
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
