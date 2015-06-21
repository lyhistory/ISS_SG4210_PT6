using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace nus.iss.crs.pl.Admin
{
    public class NavigationManager
    {
        //page action, target url
        private static Dictionary<string, ActionTarget> mappingTable = new Dictionary<string, ActionTarget>();

        private static NavigationManager manager = null;
        private NavigationManager()
        {
            ActionTarget actionTarget = new ActionTarget(typeof(CreateCourse), (AdminAction)CourseAdminAction.Save, typeof(ListCourse));
            //actionTarget.FailedTarget =

            mappingTable[actionTarget.GetActionID()] = actionTarget;
        }

        public static NavigationManager GetInstance()
        {
            if (manager == null)
                manager = new NavigationManager();
            return manager;
        }

        public void RegisterActionTarget(Page actionContainer, AdminAction action, Type target)
        {
            RegisterActionTarget(actionContainer, action, target, null);
        }

        public void RegisterActionTarget(Page actionContainer, AdminAction action, Type successTarget, Type failedTarget)
        {
            ActionTarget actionTarget = new ActionTarget(actionContainer.GetType(), action, successTarget);
            if (mappingTable.Keys.Contains(actionTarget.GetActionID()))
            {
                return;
            }

            if (failedTarget != null)
            {
                actionTarget.FailedTarget = failedTarget;
            }
            mappingTable[actionTarget.GetActionID()] = actionTarget;
        }

        public ActionTarget Navigate(Page actionContainer, AdminAction action)
        {
            string key = ActionTarget.BuildActionID(actionContainer.GetType(), action);

            if (mappingTable.Keys.Contains(key))
            {
                return mappingTable[key];
            }
            else
            {
                return null;//return error page
            }
        }

    }
}
