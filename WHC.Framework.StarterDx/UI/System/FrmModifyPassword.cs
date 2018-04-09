using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using WHC.Framework.Commons;
using WHC.Framework.BaseUI;
using WHC.Framework.ControlUtil;

namespace WHC.Framework.Starter
{
    public partial class FrmModifyPassword : BaseDock
    {
        public FrmModifyPassword()
        {
            InitializeComponent();
        }

        private void FrmModifyPassword_Load(object sender, EventArgs e)
        {
            this.txtLogin.Text = this.LoginUserInfo.FullName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            #region 输入验证
            if (this.txtRePassword.Text != this.txtPassword.Text)
            {
                MessageDxUtil.ShowTips("两个新密码的输入不一致");
                this.txtRePassword.Focus();
                return;
            }
            #endregion

            try
            {
                bool result = BLLFactory<WHC.Security.BLL.User>.Instance.ModifyPassword(this.LoginUserInfo.Name, this.txtPassword.Text);

                if (result)
                {
                    this.DialogResult = DialogResult.OK;
                    MessageDxUtil.ShowTips("密码修改成功");
                }
                else
                {
                    MessageDxUtil.ShowWarning("用户密码资料不正确，请核对");
                }
            }
            catch (Exception ex)
            {
                MessageDxUtil.ShowError(ex.Message);
            }
        }
    }
}
