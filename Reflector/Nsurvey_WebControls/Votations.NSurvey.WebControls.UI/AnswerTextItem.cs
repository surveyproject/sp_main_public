namespace Votations.NSurvey.WebControls.UI
{
    using System;
    using System.Web.UI;
    using Votations.NSurvey.Data;
    using System.Web.UI.WebControls;
    public class AnswerTextItem : AnswerItem
    {
        protected override void CreateChildControls()
        {
            Label label = new Label();
            label.Text = this.Text;
            label.CssClass = "answerTextRender";
            this.Controls.Add(label);
        }

        protected override PostedAnswerDataCollection GetPostedAnswerData()
        {
            return null;
        }
    }
}

