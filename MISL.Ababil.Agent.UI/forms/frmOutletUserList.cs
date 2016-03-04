using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework.Forms;
using MISL.Ababil.Agent.Infrastructure.Models.common;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.agent;
using MISL.Ababil.Agent.Infrastructure.Models.domain.models.user;
using MISL.Ababil.Agent.Services;
using MISL.Ababil.Agent.UI.forms.OutletUI;

namespace MISL.Ababil.Agent.UI.forms
{
    public partial class frmOutletUserList : MetroForm
    {
        Packet _packet; 
        SubAgentInformation _subAgentInformation;
        public frmOutletUserList(Packet packet, SubAgentInformation subAgentInformation)
        {
            _packet = packet;
            _subAgentInformation = subAgentInformation;

            InitializeComponent();
            loadOutletUsers(_subAgentInformation.id);
        }

        private void loadOutletUsers(long outletId)
        {
            try
            {
                panelUserList.Controls.Clear();
                lblOutletCodeValue.Text = _subAgentInformation.subAgentCode;
                lblOutletNameValue.Text = _subAgentInformation.name;

                SubAgentServices subAgentServices = new SubAgentServices();
                List<SubAgentUser> subAgentUserList = subAgentServices.GetSubAgentUserListBySubAgentId(outletId);

                for (int i = 0; i < subAgentUserList.Count; i++)
                {
                    //OutletListItem outletListItem = new OutletListItem(null, subAgentInformationList[i]);
                    OutletListItem outletListItem = new OutletListItem(null, LimitUserType.User, (object)subAgentUserList[i]);

                    outletListItem.Dock = DockStyle.Top;
                    panelUserList.Controls.Add(outletListItem);
                }
            }
            catch (Exception exp)
            { }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < panelUserList.Controls.Count; i++ ) panelUserList.Controls.RemoveAt(i);
            this.Close();
        }
    }
}
