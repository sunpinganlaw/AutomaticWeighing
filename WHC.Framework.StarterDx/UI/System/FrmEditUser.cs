using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using WHC.Framework.Commons;
using WHC.Framework.ControlUtil;

using WHC.Security.BLL;
using WHC.Security.Entity;
using WHC.Security.Common;
using WHC.Framework.BaseUI;
using DevExpress.XtraTreeList.Nodes;

namespace WHC.Framework.Starter
{
    public partial class FrmEditUser : BaseEditForm
    {
        /// <summary>
        /// ����һ����ʱ���󣬷����ڸ��������л�ȡ���ڵ�GUID
        /// </summary>
        private UserInfo tempInfo = new UserInfo();

        public FrmEditUser()
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
            //if (this.txtName.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("�������û���/��¼��");
            //    this.txtName.Focus();
            //    result = false;
            //}
            //else if (this.txtFullName.Text.Trim().Length == 0)
            //{
            //    MessageDxUtil.ShowTips("��������ʵ����");
            //    this.txtFullName.Focus();
            //    result = false;
            //}
            //else if (this.txtCompany.Text == "")
            //{
            //    MessageDxUtil.ShowTips("������˾����Ϊ��");
            //    this.txtCompany.Focus();
            //    return false;
            //}
            //else if (this.txtDept.Text == "")
            //{
            //    MessageDxUtil.ShowTips("Ĭ�ϲ��Ż�������Ϊ��");
            //    this.txtDept.Focus();
            //    return false;
            //}
            #endregion

            return result;
        }

        /// <summary>
        /// ��ʼ�������ֵ�
        /// </summary>
        private void InitDictItem()
        {
            this.treeFunction.Nodes.Clear();//�����ƽڵ�
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
                UserInfo info = BLLFactory<User>.Instance.FindByID(ID);
                if (info != null)
                {
                    tempInfo = info;//���¸���ʱ����ֵ��ʹָ֮����ڵļ�¼����

                    RefreshOUs(info.ID);
                    RefreshRoles(info.ID);
                    RefreshFunction(info.ID);

                    this.cmbManager.Text = BLLFactory<User>.Instance.GetFullNameByID(info.PID);
                    this.txtCompany.Text = BLLFactory<OU>.Instance.GetName(info.Company_ID.ToInt32());
                    this.txtDept.Text = BLLFactory<OU>.Instance.GetName(info.Dept_ID.ToInt32());

                    txtHandNo.Text = info.HandNo;
                    txtName.Text = info.Name;
                    txtFullName.Text = info.FullName;
                    txtNickname.Text = info.Nickname;
                    txtTitle.Text = info.Title;
                    txtIdentityCard.Text = info.IdentityCard;
                    txtMobilePhone.Text = info.MobilePhone;
                    txtOfficePhone.Text = info.OfficePhone;
                    txtHomePhone.Text = info.HomePhone;
                    txtEmail.Text = info.Email;
                    txtAddress.Text = info.Address;
                    txtWorkAddr.Text = info.WorkAddr;
                    txtGender.Text = info.Gender;
                    txtBirthday.SetDateTime(info.Birthday);
                    txtQq.Text = info.QQ;
                    txtSignature.Text = info.Signature;
                    txtAuditStatus.Text = info.AuditStatus;
                    txtNote.Text = info.Note;
                    txtCustomField.Text = info.CustomField;                   
                    txtSortCode.Text = info.SortCode;
                    txtCreator.Text = info.Creator;
                    txtCreateTime.SetDateTime(info.CreateTime);
                }
                #endregion
            }
            else
            {
                txtCreator.Text = Portal.gc.UserInfo.FullName;//Ĭ��Ϊ��ǰ��¼�û�
                txtCreateTime.DateTime = DateTime.Now; //Ĭ�ϵ�ǰʱ��
            }

            //tempInfo�ڶ��������Ϊָ�������½�����ȫ�µĶ��󣬵���һЩ��ʼ����GUID���ڸ����ϴ�
            //SetAttachInfo(tempInfo);
        }

        //private void SetAttachInfo(UserInfo info)
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
            this.tempInfo = new UserInfo();
            base.ClearScreen();
        }

        /// <summary>
        /// �༭���߱���״̬��ȡֵ����
        /// </summary>
        /// <param name="info"></param>
        private void SetInfo(UserInfo info)
        {
            info.HandNo = txtHandNo.Text;
            info.FullName = txtFullName.Text;
            info.Nickname = txtNickname.Text;
            info.IdentityCard = txtIdentityCard.Text;
            info.MobilePhone = txtMobilePhone.Text;
            info.OfficePhone = txtOfficePhone.Text;
            info.HomePhone = txtHomePhone.Text;
            info.Email = txtEmail.Text;
            info.Address = txtAddress.Text;
            info.WorkAddr = txtWorkAddr.Text;
            info.Gender = txtGender.Text;
            info.Birthday = txtBirthday.DateTime;
            info.QQ = txtQq.Text;
            info.Signature = txtSignature.Text;
            info.Note = txtNote.Text;
            info.CustomField = txtCustomField.Text;
            info.Editor = Portal.gc.UserInfo.FullName;
            info.Editor_ID = Portal.gc.UserInfo.ID.ToString();
            info.EditTime = DateTime.Now;

            info.CurrentLoginUserId = Portal.gc.UserInfo.ID.ToString();
        }

        /// <summary>
        /// ����״̬�µ����ݱ���
        /// </summary>
        /// <returns></returns>
        public override bool SaveAddNew()
        {
            UserInfo info = tempInfo;//����ʹ�ô��ڵľֲ���������Ϊ������Ϣ���ܱ�����ʹ��
            SetInfo(info);
            info.Creator = Portal.gc.UserInfo.FullName;
            info.Creator_ID = Portal.gc.UserInfo.ID.ToString();
            info.CreateTime = DateTime.Now;

            try
            {
                #region ��������

                bool succeed = BLLFactory<User>.Instance.Insert(info);
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
            UserInfo info = BLLFactory<User>.Instance.FindByID(ID);
            if (info != null)
            {
                SetInfo(info);

                try
                {
                    #region ��������
                    bool succeed = BLLFactory<User>.Instance.Update(info, info.ID);
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

        private void txtIdentityCard_Validated(object sender, EventArgs e)
        {
            if (this.txtIdentityCard.Text.Trim().Length > 0)
            {
                GenerateBirthdays();
            }
            else
            {
                //this.txtBirthday.Text = "";
                //this.txtSex.Text = "";
            }
        }

        private void GenerateBirthdays()
        {
            string idCardNo = this.txtIdentityCard.Text.Trim();
            if (!string.IsNullOrEmpty(idCardNo))
            {
                string result = IDCardHelper.Validate(idCardNo);
                if (!string.IsNullOrEmpty(result))
                {
                    MessageDxUtil.ShowTips(result);
                    this.txtIdentityCard.Focus();
                    return;
                }

                DateTime birthDay = IDCardHelper.GetBirthday(idCardNo);
                int age = DateTime.Now.Year - birthDay.Year;
                string sex = IDCardHelper.GetSexName(idCardNo);

                this.txtBirthday.DateTime = birthDay;
                //this.txtAge.Value = age;
                this.txtGender.Text = sex;
                this.txtOfficePhone.Focus();
            }
        }

        private void RefreshOUs(int id)
        {
            this.lvwOU.BeginUpdate();
            this.lvwOU.Items.Clear();

            List<OUInfo> list = BLLFactory<OU>.Instance.GetOUsByUser(id);
            foreach (OUInfo info in list)
            {
                this.lvwOU.Items.Add(info.Name);
            }
            this.lvwOU.EndUpdate();
        }

        private void RefreshRoles(int id)
        {
            this.lvwRole.BeginUpdate();
            this.lvwRole.Items.Clear();

            List<RoleInfo> list = BLLFactory<Role>.Instance.GetRolesByUser(id);
            foreach (RoleInfo info in list)
            {
                this.lvwRole.Items.Add(info.Name);
            }
            this.lvwRole.EndUpdate();
        }
        
        public void RefreshFunction(int id)
        {
            this.treeFunction.BeginUpdate();
            this.treeFunction.Nodes.Clear();

            List<SystemTypeInfo> typeList = BLLFactory<SystemType>.Instance.GetAll();
            int i = 0;
            foreach (SystemTypeInfo typeInfo in typeList)
            {
                TreeNode parentNode = this.treeFunction.Nodes.Add(typeInfo.OID, typeInfo.Name, 0, 0);
                List<FunctionNodeInfo> list = BLLFactory<Function>.Instance.GetFunctionNodesByUser(id, typeInfo.OID);
                AddFunctionNode(parentNode, list);                
            }

            this.treeFunction.ExpandAll();
            this.treeFunction.EndUpdate();            
        }

        private void AddFunctionNode(TreeNode node, List<FunctionNodeInfo> list)
        {
            foreach (FunctionNodeInfo info in list)
            {
               TreeNode subNode =  node.Nodes.Add(info.ID, info.Name, 1, 1);

               AddFunctionNode(subNode, info.Children);
            }
        }
    }
}
