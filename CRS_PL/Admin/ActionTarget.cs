using nus.iss.crs.pl.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace nus.iss.crs.pl.Admin
{
    public class ActionTarget
    {

        private Type _ActionContainer;

        public Type FailedTarget { get; set; }
        public Type SuccessTarget { get; set; }
        public AdminAction ActionName { get; set; }

        public ActionTarget(Type actionContainer, AdminAction action, Type successTarget)
        {
            _ActionContainer = actionContainer;
            ActionName = action;
            SuccessTarget = successTarget;
        }

        public string GetActionID()
        {
            return BuildActionID(_ActionContainer, ActionName);
        }

        public static string BuildActionID(Type actionContainer, AdminAction action)
        {
            return actionContainer.Name + "|" + action.ToString();
        }
    }

    
    
}
