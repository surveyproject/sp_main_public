/**************************************************************************************************
	Survey changes: copyright (c) 2010, Fryslan Webservices TM (http://survey.codeplex.com)	

	NSurvey - The web survey and form engine
	Copyright (c) 2004, 2005 Thomas Zumbrunn. (http://www.nsurvey.org)


	This program is free software; you can redistribute it and/or
	modify it under the terms of the GNU General Public License
	as published by the Free Software Foundation; either version 2
	of the License, or (at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU General Public License for more details.

	You should have received a copy of the GNU General Public License
	along with this program; if not, write to the Free Software
	Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.

************************************************************************************************/


namespace Votations.NSurvey.WebAdmin.UserControls
{
	using System;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Resources;
	using Microsoft.VisualBasic;
	using Votations.NSurvey;
	using Votations.NSurvey.Data;
	using Votations.NSurvey.DataAccess;
	using Votations.NSurvey.BusinessRules;
	using Votations.NSurvey.Web;
	using Votations.NSurvey.WebControls.UI;
	using Votations.NSurvey.WebControlsFactories;


	/// <summary>
	/// Answer data CU methods
	/// </summary>
    public partial class AnswerOptionControl : UserControl
	{
		public event EventHandler OptionChanged;
		protected System.Web.UI.WebControls.Label MessageLabel;
		protected System.Web.UI.WebControls.TextBox AnswerTextTextBox;
		protected System.Web.UI.WebControls.Label AnswerURLLabel;
		protected System.Web.UI.WebControls.TextBox AnswerImageURLTextBox;
		protected System.Web.UI.WebControls.Label AnswerTypeLabel;
		protected System.Web.UI.WebControls.DropDownList AnswerTypeDropDownList;
		protected System.Web.UI.WebControls.Label DefaultTextLabel;
		protected System.Web.UI.WebControls.TextBox DefaultTextTextBox;
		protected System.Web.UI.WebControls.Label SelectedAnswersLabel;
		protected System.Web.UI.WebControls.CheckBox SelectionCheckBox;
		protected System.Web.UI.WebControls.Label AnswerRatingLabel;
		protected System.Web.UI.WebControls.CheckBox RatingPartCheckbox;
		protected System.Web.UI.WebControls.TextBox ScoreTextBox;
		protected System.Web.UI.WebControls.Button AddAnswerButton;
		protected System.Web.UI.WebControls.Label PipeHelpLabel;
		protected System.Web.UI.WebControls.Literal EditAnswerTitle;
		protected System.Web.UI.WebControls.Button DeleteAnswerButton;
		protected System.Web.UI.WebControls.Button UpdateAnswerButton;
		protected System.Web.UI.WebControls.Label ScoreLabel;
		protected System.Web.UI.WebControls.Label AnswerTextLabel;
		protected System.Web.UI.WebControls.Button CancelAnswerButton;
		protected System.Web.UI.WebControls.Label AnswerPipeAliasLabel;
		protected System.Web.UI.WebControls.TextBox AnswerPipeAliasTextBox;
		protected System.Web.UI.WebControls.Label ConnectionLabel;
		protected System.Web.UI.WebControls.ListBox ListBox2;
		protected System.Web.UI.WebControls.Label AnswerSubscribedLabel;
		protected System.Web.UI.WebControls.Label AnswerPublishersLabel;
		protected System.Web.UI.WebControls.ListBox AvailablePublishersListBox;
		protected System.Web.UI.WebControls.ListBox SubscribedListbox;
		protected System.Web.UI.WebControls.PlaceHolder ConnectionsPlaceHolder;
		protected System.Web.UI.WebControls.Label RegExValidationLabel;
		protected System.Web.UI.WebControls.Label MandatoryLabel;
		protected System.Web.UI.WebControls.CheckBox MandatoryCheckBox;
		protected System.Web.UI.WebControls.PlaceHolder ExtendedPropertiesPlaceholder;
		protected System.Web.UI.WebControls.Label EditExtendedSettingsTitle;
		protected System.Web.UI.WebControls.PlaceHolder ExtendedPlaceholder;
		protected System.Web.UI.WebControls.DropDownList RegExDropDownList;

        protected System.Web.UI.WebControls.DropDownList SliderRangeDDL;

        protected System.Web.UI.WebControls.Label SliderRangeLabel;
        protected System.Web.UI.WebControls.Label SliderValueLabel;
        protected System.Web.UI.WebControls.Label SliderMinLabel;
        protected System.Web.UI.WebControls.Label SliderMaxLabel;
        protected System.Web.UI.WebControls.Label SliderAnimateLabel;
        protected System.Web.UI.WebControls.Label SliderStepLabel;


		/// <summary>
		/// Id of the answer to edit
		/// if no id is given put the 
		/// usercontrol in creation mode
		/// </summary>
		public int AnswerId
		{
            get { return (ViewState["AnswerID"] == null) ? -1 : int.Parse(ViewState["AnswerID"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
			set { ViewState["AnswerID"] = value; }
		}

		/// <summary>
		/// Id of the answer's question 
		/// </summary>
		public int QuestionId
		{
            get { return (ViewState["QuestionId"] == null) ? -1 : int.Parse(ViewState["QuestionId"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
			set { ViewState["QuestionId"] = value; }
		}

		public bool ScoreEnabled
		{
			get { return (ViewState["ScoreEnabled"]==null) ? false : bool.Parse(ViewState["ScoreEnabled"].ToString()); }
			set { ViewState["ScoreEnabled"] = value; }
		}

		public bool RatingEnabled
		{
			get { return (ViewState["RatingEnabled"]==null) ? false : bool.Parse(ViewState["RatingEnabled"].ToString()); }
			set { ViewState["RatingEnabled"] = value; }
		}

		public int SurveyId
		{
            get { return (ViewState["SurveyId"] == null) ? -1 : int.Parse(ViewState["SurveyId"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
			set { ViewState["SurveyId"] = value; }
		}

		public string LanguageCode
		{
			get { return (ViewState["LanguageCode"]==null) ? null : ViewState["LanguageCode"].ToString(); }
			set { ViewState["LanguageCode"] = value; }
		}

        public int AnsuwerIDText
        {
            get { return (ViewState["AnsuwerIDText"] == null) ? -1 : int.Parse(ViewState["AnsuwerIDText"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
            set { ViewState["AnsuwerIDText"] = value; }
        }

        public string AnswerAlias
        {
            get { return (ViewState["AnswerAlias"] == null) ? null : ViewState["AnswerAlias"].ToString(); }
            set { ViewState["AnswerAlias"] = value; }
        }


        /// <summary>
        /// AnswerType Slider values:
        /// </summary>
        public string SliderRange
        {
            get { return (ViewState["SliderRange"] == null) ? null : ViewState["SliderRange"].ToString(); }
            set { ViewState["SliderRange"] = value; }
        }
        public int SliderValue
        {
            get { return (ViewState["SliderValue"] == null) ? 0 : int.Parse(ViewState["SliderValue"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
            set { ViewState["SliderValue"] = value; }
        }
        public int SliderMin
        {
            get { return (ViewState["SliderMin"] == null) ? 0 : int.Parse(ViewState["SliderMin"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
            set { ViewState["SliderMin"] = value; }
        }
        public int SliderMax
        {
            get { return (ViewState["SliderMax"] == null) ? 0 : int.Parse(ViewState["SliderMax"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
            set { ViewState["SliderMax"] = value; }
        }
        public bool SliderAnimate
        {
            get { return (ViewState["SliderAnimate"] == null) ? false : bool.Parse(ViewState["SliderAnimate"].ToString()); }
            set { ViewState["SliderAnimate"] = value; }
        }
        public int SliderStep
        {
            get { return (ViewState["SliderStep"] == null) ? 0 : int.Parse(ViewState["SliderStep"].ToString(), System.Globalization.CultureInfo.InvariantCulture); }
            set { ViewState["SliderStep"] = value; }
        }



		private void Page_Load(object sender, System.EventArgs e)
		{
			LocalizePage();

			MessageLabel.Visible = false;
			DeleteAnswerButton.Attributes.Add("onClick",
							"javascript:if(confirm('" +((PageBase)Page).GetPageResource("DeleteAnswerConfirmationMessage")+ "')== false) return false;");
		
			if (!Page.IsPostBack)
			{
				BindData();
			}

            AnswerTypeData typeData = new AnswerTypes().GetAnswerTypeById(int.Parse(AnswerTypeDropDownList.SelectedValue, System.Globalization.CultureInfo.InvariantCulture));
			SetUIState(typeData.AnswerTypes[0].TypeMode, false);
		}

		private void LocalizePage()
		{
			PipeHelpLabel.Text = ((PageBase)Page).GetPageResource("PipeHelpLabel");
			AnswerRatingLabel.Text = ((PageBase)Page).GetPageResource("AnswerRatingLabel");
			SelectedAnswersLabel.Text = ((PageBase)Page).GetPageResource("SelectedAnswersLabel");
			AnswerURLLabel.Text = ((PageBase)Page).GetPageResource("AnswerURLLabel");
			ScoreLabel.Text = ((PageBase)Page).GetPageResource("ScoreLabel");
			UpdateAnswerButton.Text = ((PageBase)Page).GetPageResource("UpdateAnswerButton");
			DeleteAnswerButton.Text = ((PageBase)Page).GetPageResource("DeleteAnswerButton");
			AddAnswerButton.Text = ((PageBase)Page).GetPageResource("AddAnswerButton");
			AnswerTextLabel.Text = ((PageBase)Page).GetPageResource("AnswerTextLabel");
			AnswerTypeLabel.Text = ((PageBase)Page).GetPageResource("AnswerTypeLabel");
			CancelAnswerButton.Text = ((PageBase)Page).GetPageResource("CancelAnswerButton");
			AnswerPipeAliasLabel.Text = ((PageBase)Page).GetPageResource("AnswerPipeAliasLabel");
			MandatoryLabel.Text = ((PageBase)Page).GetPageResource("MandatoryLabel");
			RegExValidationLabel.Text = ((PageBase)Page).GetPageResource("RegExValidationLabel");
			AnswerPublishersLabel.Text = ((PageBase)Page).GetPageResource("AnswerPublishersLabel");
			AnswerSubscribedLabel.Text = ((PageBase)Page).GetPageResource("AnswerSubscribedLabel");
			EditExtendedSettingsTitle.Text = ((PageBase)Page).GetPageResource("EditExtendedSettingsTitle");
			DefaultTextLabel.Text = ((PageBase)Page).GetPageResource("DefaultTextLabel");
        
            SliderRangeLabel.Text = ((PageBase)Page).GetPageResource("SliderRangeTextLabel");
            SliderValueLabel.Text = ((PageBase)Page).GetPageResource("SliderValueTextLabel");
            SliderMinLabel.Text = ((PageBase)Page).GetPageResource("SliderMinTextLabel");
            SliderMaxLabel.Text = ((PageBase)Page).GetPageResource("SliderMaxTextLabel");
            SliderAnimateLabel.Text = ((PageBase)Page).GetPageResource("SliderAnimateTextLabel");
            SliderStepLabel.Text = ((PageBase)Page).GetPageResource("SliderStepTextLabel");

            SliderRangeDDL.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderRangeValue");
            SliderValueTextBox.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderValue");
            SliderMinTextBox.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderMinValue");
            SliderMaxTextBox.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderMaxValue");
            SliderAnimateCheckbox.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderAnimateValue");
            SliderStepTextBox.ToolTip = ((PageBase)Page).GetPageHelpfiles("SliderStepValue");

            MandatoryCheckBox.ToolTip = ((PageBase)Page).GetPageHelpfiles("RequiredMarkerSettings");

		}

		public void BindData()
		{
			if (((PageBase)Page).NSurveyUser.Identity.IsAdmin || 
				((PageBase)Page).NSurveyUser.Identity.HasAllSurveyAccess)
			{
				AnswerTypeDropDownList.DataSource = new AnswerTypes().GetAnswerTypesList();
			}
			else
			{
				AnswerTypeDropDownList.DataSource = new AnswerTypes().GetAssignedAnswerTypesList(((PageBase)Page).NSurveyUser.Identity.UserId, SurveyId);
			}
			
			AnswerTypeDropDownList.DataMember = "AnswerTypes";
			AnswerTypeDropDownList.DataTextField = "Description";
			AnswerTypeDropDownList.DataValueField = "AnswerTypeID";
			AnswerTypeDropDownList.DataBind();
			((PageBase)Page).TranslateListControl(AnswerTypeDropDownList);
			AnswerTypeDropDownList.SelectedValue = "1";

			AvailablePublishersListBox.DataSource = new Answers().GetPublishersList(AnswerId);
			AvailablePublishersListBox.DataTextField = "AnswerText";
			AvailablePublishersListBox.DataValueField = "AnswerId";
			AvailablePublishersListBox.DataBind();

			SubscribedListbox.DataSource = new Answers().GetSubscriptionList(AnswerId);
			SubscribedListbox.DataTextField = "AnswerText";
			SubscribedListbox.DataValueField = "AnswerId";
			SubscribedListbox.DataBind();

			if (NSurveyContext.Current.User.Identity.IsAdmin || 
				NSurveyContext.Current.User.Identity.HasAllSurveyAccess)
			{
				RegExDropDownList.DataSource = 
					new RegularExpressions().GetAllRegularExpressionsList();
			}
			else
			{
				RegExDropDownList.DataSource =
					new RegularExpressions().GetRegularExpressionsOfUser(NSurveyContext.Current.User.Identity.UserId, SurveyId);
			}
			RegExDropDownList.DataTextField = "Description";
			RegExDropDownList.DataValueField = "RegularExpressionId";
			RegExDropDownList.DataBind();
			((PageBase)Page).TranslateListControl(RegExDropDownList);
			RegExDropDownList.Items.Insert(0, 
				new ListItem(((PageBase)Page).GetPageResource("NoRegExValidationOption"), "-1"));


			// Check if any answer has been assigned
			if (AnswerId == -1)
			{
				SwitchToCreationMode();
			}
			else
			{
				SwitchToEditionMode();
			}
		}


		/// <summary>
		/// Setup the control in creation mode
		/// </summary>
		private void SwitchToCreationMode()
		{
			// Creation mode
			AddAnswerButton.Visible = true;
			UpdateAnswerButton.Visible = false;
			DeleteAnswerButton.Visible = false;
			SelectedAnswersLabel.Visible = true;
			SelectionCheckBox.Visible = true;
			RatingPartCheckbox.Visible = RatingEnabled;
			AnswerRatingLabel.Visible = RatingEnabled;
			AnswerTextTextBox.Text = String.Empty;
			AnswerPipeAliasTextBox.Text = String.Empty;
			DefaultTextTextBox.Text = String.Empty;
			ScoreTextBox.Text = String.Empty;
			ScoreTextBox.Visible = ScoreEnabled;
			ScoreLabel.Visible = ScoreEnabled;
            txtAnswerAlias.Text = string.Empty;
            txtAnswerID.Text = string.Empty;
			EditAnswerTitle.Text = ((PageBase)Page).GetPageResource("AddNewAnswerTitle");
			RegExDropDownList.ClearSelection();
			MandatoryLabel.Visible = false;
			MandatoryCheckBox.Checked = false;
			RegExValidationLabel.Visible = false;
			RegExDropDownList.Visible = false;
			MandatoryCheckBox.Visible = false;
			ConnectionsPlaceHolder.Visible = false;


            SliderRangeLabel.Visible = false;

            SliderRangeDDL.Visible = false;
            SliderRangeDDL.Text = SliderRangeDDL.SelectedValue.ToString();

            SliderValueTextBox.Visible = false;
            SliderValueLabel.Visible = false;
            SliderValueTextBox.Text = String.Empty;

            SliderMinLabel.Visible = false;
            SliderMinTextBox.Visible = false;
            SliderMinTextBox.Text = String.Empty;

            SliderMaxLabel.Visible = false;
            SliderMaxTextBox.Visible = false;
            SliderMaxTextBox.Text = String.Empty;

            SliderAnimateLabel.Visible = false;
            SliderAnimateCheckbox.Visible = false;
            SliderAnimateCheckbox.Checked = false;

            SliderStepLabel.Visible = false;
            SliderStepTextBox.Visible = false;
            SliderStepTextBox.Text = String.Empty;

            
			DefaultTextLabel.Visible = false;
			DefaultTextTextBox.Visible = false;
			AnswerPipeAliasLabel.Visible = false;
			AnswerPipeAliasTextBox.Visible = false;
			PipeHelpLabel.Visible = false;

			ExtendedPropertiesPlaceholder.Controls.Clear();
			ExtendedPropertiesPlaceholder.Visible = false;
			ExtendedPlaceholder.Visible = false;
		}

		/// <summary>
		/// Setup the control in edition mode
		/// </summary>
		private void SwitchToEditionMode()
		{
			AddAnswerButton.Visible = false;
			UpdateAnswerButton.Visible = true;
			DeleteAnswerButton.Visible = true;
			EditAnswerTitle.Text = ((PageBase)Page).GetPageResource("EditAnswerTitle");
			BindFields();
		}

		/// <summary>
		/// Get the current DB data and fill 
		/// the fields with them
		/// </summary>
		private void BindFields()
		{
			AnswerData answer = new Answers().GetAnswerById(AnswerId, LanguageCode);
			AnswerTextTextBox.Text = answer.Answers[0].AnswerText;
			AnswerImageURLTextBox.Text = answer.Answers[0].ImageURL;
			DefaultTextTextBox.Text = answer.Answers[0].DefaultText;
			AnswerPipeAliasTextBox.Text = answer.Answers[0].AnswerPipeAlias;
			SelectionCheckBox.Checked = answer.Answers[0].Selected;
			if (AnswerTypeDropDownList.Items.FindByValue(answer.Answers[0].AnswerTypeId.ToString(System.Globalization.CultureInfo.InvariantCulture)) != null)
			{
                AnswerTypeDropDownList.SelectedValue = answer.Answers[0].AnswerTypeId.ToString(System.Globalization.CultureInfo.InvariantCulture);
			}
			RatingPartCheckbox.Checked = answer.Answers[0].RatePart;
			RatingPartCheckbox.Visible = RatingEnabled;
			AnswerRatingLabel.Visible = RatingEnabled;
            ScoreTextBox.Text = answer.Answers[0].ScorePoint.ToString(System.Globalization.CultureInfo.InvariantCulture);
			ScoreTextBox.Visible = ScoreEnabled;
			ScoreLabel.Visible = ScoreEnabled;
			MandatoryCheckBox.Checked = answer.Answers[0].Mandatory;
			if (!answer.Answers[0].IsRegularExpressionIdNull())
			{
                RegExDropDownList.SelectedValue = answer.Answers[0].RegularExpressionId.ToString(System.Globalization.CultureInfo.InvariantCulture);
			}
            txtAnswerAlias.Text = answer.Answers[0].AnswerAlias;
            txtAnswerID.Text = answer.Answers[0].AnswerIDText;

            SliderRangeDDL.SelectedValue = answer.Answers[0].SliderRange;

            SliderValueTextBox.Text = Convert.ToString(answer.Answers[0].SliderValue, System.Globalization.CultureInfo.InvariantCulture);
            SliderMinTextBox.Text = Convert.ToString(answer.Answers[0].SliderMin, System.Globalization.CultureInfo.InvariantCulture);
            SliderMaxTextBox.Text = Convert.ToString(answer.Answers[0].SliderMax, System.Globalization.CultureInfo.InvariantCulture);
            SliderAnimateCheckbox.Checked = answer.Answers[0].SliderAnimate;
            SliderStepTextBox.Text = Convert.ToString(answer.Answers[0].SliderStep, System.Globalization.CultureInfo.InvariantCulture);
            
			SetUIState(answer.Answers[0].TypeMode, false);
		}

		/// <summary>
		/// Enable / disable fields depending on the type mode choosen
		/// </summary>
		/// <param name="typeMode"></param>
		private void SetUIState(int typeMode, bool resetValues)
		{
			bool isSelectionType = (((AnswerTypeMode)typeMode & AnswerTypeMode.Selection) > 0),

				isFieldType = (((AnswerTypeMode)typeMode & AnswerTypeMode.Field) > 0) ||
				(((AnswerTypeMode)typeMode & AnswerTypeMode.Custom) > 0) ||
				(((AnswerTypeMode)typeMode & AnswerTypeMode.DataSource) > 0),

				isMandatoryType = ((AnswerTypeMode)typeMode & AnswerTypeMode.Mandatory) > 0,

				isRegExType = ((AnswerTypeMode)typeMode & AnswerTypeMode.RegExValidator) > 0,

				isSubscriber = ((AnswerTypeMode)typeMode & AnswerTypeMode.Subscriber) > 0,

				isFileUpload = ((AnswerTypeMode)typeMode & AnswerTypeMode.Upload) > 0,

				isExtended = ((AnswerTypeMode)typeMode & AnswerTypeMode.ExtendedType) > 0,

                isSlider = ((AnswerTypeMode)typeMode & AnswerTypeMode.Slider) > 0;
			
			SelectedAnswersLabel.Visible = isSelectionType;
			SelectionCheckBox.Visible = isSelectionType;

			RatingPartCheckbox.Visible = isSelectionType && RatingEnabled;
			AnswerRatingLabel.Visible = isSelectionType && RatingEnabled;

			ScoreTextBox.Visible = isSelectionType && ScoreEnabled;
			ScoreLabel.Visible = isSelectionType && ScoreEnabled;	
		
			PipeHelpLabel.Visible = isFieldType;
			
			MandatoryLabel.Visible = isMandatoryType;
			MandatoryCheckBox.Visible = isMandatoryType;
			
			RegExValidationLabel.Visible = isRegExType;
			RegExDropDownList.Visible = isRegExType;			
			
			if (resetValues && isFieldType)
			{
				ScoreTextBox.Text = "0";
				RatingPartCheckbox.Checked = false;
				SelectionCheckBox.Checked = false;
			}

		
			ConnectionsPlaceHolder.Visible = 
				isSubscriber && AnswerId != -1;

			DefaultTextLabel.Visible = isFieldType;
			DefaultTextTextBox.Visible = isFieldType;

            SliderRangeLabel.Visible = isSlider && isFieldType;
            SliderRangeDDL.Visible = isSlider && isFieldType;

            SliderValueTextBox.Visible = isSlider && isFieldType;
            SliderValueLabel.Visible = isSlider && isFieldType;

            SliderMinLabel.Visible = isSlider && isFieldType;
            SliderMinTextBox.Visible = isSlider && isFieldType;

            SliderMaxLabel.Visible = isSlider && isFieldType;
            SliderMaxTextBox.Visible = isSlider && isFieldType;

            SliderAnimateLabel.Visible = isSlider && isFieldType;
            SliderAnimateCheckbox.Visible = isSlider && isFieldType;

            SliderStepLabel.Visible = isSlider && isFieldType;
            SliderStepTextBox.Visible = isSlider && isFieldType;

			AnswerPipeAliasLabel.Visible = isFieldType;
			AnswerPipeAliasTextBox.Visible = isFieldType;

			if (AnswerId != -1 && isExtended)
			{
				SetExtendedProperties();
			}
			else
			{
				ExtendedPropertiesPlaceholder.Controls.Clear();
				ExtendedPropertiesPlaceholder.Visible = false;
				ExtendedPlaceholder.Visible = false;
			}
	}


		private void SetExtendedProperties()
		{		
			AnswerData answers = new Answers().GetAnswerById(AnswerId, null);
			ExtendedPropertiesPlaceholder.Controls.Clear();

			if (((AnswerTypeMode)answers.Answers[0].TypeMode & AnswerTypeMode.ExtendedType) > 0)
			{

				ExtendedPlaceholder.Visible = true;
				ExtendedPropertiesPlaceholder.Visible = true;
				AnswerItem answerItem = 
					AnswerItemFactory.Create(answers.Answers[0], null, null, AnswerSelectionMode.None, null,
					ControlRenderMode.Edit, null, UniqueID, true, null, true);

				ExtendedAnswerItem extendedItem = answerItem as ExtendedAnswerItem; 

				if (extendedItem != null)
				{
					extendedItem.RestoreProperties();
					ExtendedPropertiesPlaceholder.Controls.Add(extendedItem.GeneratePropertiesUI());
				}
			}
			else
			{
				ExtendedPropertiesPlaceholder.Controls.Clear();
				ExtendedPropertiesPlaceholder.Visible = false;
				ExtendedPlaceholder.Visible = false;
			}
		}




		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.AnswerTypeDropDownList.SelectedIndexChanged += new System.EventHandler(this.AnswerTypeDropDownList_SelectedIndexChanged);
			this.AvailablePublishersListBox.SelectedIndexChanged += new System.EventHandler(this.AvailablePublishersListBox_SelectedIndexChanged);
			this.SubscribedListbox.SelectedIndexChanged += new System.EventHandler(this.SubscribedListbox_SelectedIndexChanged);
			this.UpdateAnswerButton.Click += new System.EventHandler(this.UpdateAnswerButton_Click);
			this.AddAnswerButton.Click += new System.EventHandler(this.AddAnswerButton_Click);
			this.DeleteAnswerButton.Click += new System.EventHandler(this.DeleteAnswerButton_Click);
			this.CancelAnswerButton.Click += new System.EventHandler(this.CancelAnswerButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected void OnOptionChanged()
		{
			if (OptionChanged != null)
			{
				OptionChanged(this, EventArgs.Empty);
			}
		}

		private void AddAnswerButton_Click(object sender, System.EventArgs e)
		{
			//Creates a BE and adds it in the DB
			AnswerData answer = new AnswerData();
			AnswerData.AnswersRow newAnswer = answer.Answers.NewAnswersRow();

			newAnswer.QuestionId = QuestionId;
			newAnswer.AnswerText = AnswerTextTextBox.Text;
			newAnswer.ImageURL = AnswerImageURLTextBox.Text;
			newAnswer.AnswerTypeId =
                int.Parse(AnswerTypeDropDownList.SelectedValue, System.Globalization.CultureInfo.InvariantCulture);
			newAnswer.RatePart = RatingPartCheckbox.Checked;
			newAnswer.DefaultText = DefaultTextTextBox.Text;
			newAnswer.Selected = SelectionCheckBox.Checked;
			newAnswer.AnswerPipeAlias = AnswerPipeAliasTextBox.Text;
            newAnswer.ScorePoint = Information.IsNumeric(ScoreTextBox.Text) ? int.Parse(ScoreTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) : 0;
			newAnswer.Mandatory = MandatoryCheckBox.Checked;
            newAnswer.AnswerAlias = txtAnswerAlias.Text;
            newAnswer.AnswerIDText = txtAnswerID.Text;

            newAnswer.SliderRange = SliderRangeDDL.SelectedValue.ToString();
            newAnswer.SliderValue = Information.IsNumeric(SliderValueTextBox) ? int.Parse(SliderValueTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) : 0;
            newAnswer.SliderMin = Information.IsNumeric(SliderMinTextBox.Text) ? int.Parse(SliderMinTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) : 0;
            newAnswer.SliderMax = Information.IsNumeric(SliderMaxTextBox.Text) ? int.Parse(SliderMaxTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) : 0;
            newAnswer.SliderAnimate = SliderAnimateCheckbox.Checked;
            newAnswer.SliderStep = Information.IsNumeric(SliderStepTextBox.Text) ? int.Parse(SliderStepTextBox.Text, System.Globalization.CultureInfo.InvariantCulture) : 0;

			if (RegExDropDownList.SelectedIndex > 0)
			{
				newAnswer.RegularExpressionId = int.Parse(RegExDropDownList.SelectedValue);
			}
			answer.Answers.AddAnswersRow(newAnswer);
			new Answer().AddAnswer(answer);
			
			OnOptionChanged();

			AnswerId = -1;
			Visible = false;
		}


		private void DeleteAnswerButton_Click(object sender, System.EventArgs e)
		{
			new Answer().DeleteAnswer(AnswerId);

			AnswerId = -1;
			Visible = false;
		
			// Let the subscribers know that something changed
			OnOptionChanged();
		}

		private void UpdateAnswerButton_Click(object sender, System.EventArgs e)
		{
			int oldTypeMode = new Answers().GetAnswerTypeMode(AnswerId);
			
			// Create the updated BE
			AnswerData answer = new AnswerData();
			AnswerData.AnswersRow updatedAnswer = answer.Answers.NewAnswersRow();

			updatedAnswer.AnswerText = AnswerTextTextBox.Text;
			updatedAnswer.ImageURL = AnswerImageURLTextBox.Text;
			updatedAnswer.AnswerTypeId = 
				int.Parse(AnswerTypeDropDownList.SelectedValue);
			updatedAnswer.RatePart = RatingPartCheckbox.Checked;
			updatedAnswer.AnswerId = AnswerId;
            updatedAnswer.AnswerIDText = txtAnswerID.Text;
            updatedAnswer.AnswerAlias = txtAnswerAlias.Text;

            updatedAnswer.SliderRange = SliderRangeDDL.SelectedValue.ToString();
            updatedAnswer.SliderValue = int.Parse(SliderValueTextBox.Text);
            updatedAnswer.SliderMin = int.Parse(SliderMinTextBox.Text);
            updatedAnswer.SliderMax = int.Parse(SliderMaxTextBox.Text);
            updatedAnswer.SliderAnimate = SliderAnimateCheckbox.Checked;
            updatedAnswer.SliderStep = int.Parse(SliderStepTextBox.Text);

			if (DefaultTextTextBox.Text.Length>0)
			{
				updatedAnswer.DefaultText = DefaultTextTextBox.Text;
			}
			else
			{
				updatedAnswer.SetDefaultTextNull();
			}
			updatedAnswer.Selected = SelectionCheckBox.Checked;
			updatedAnswer.ScorePoint = Information.IsNumeric(ScoreTextBox.Text) ?
				int.Parse(ScoreTextBox.Text) : 0;
			updatedAnswer.AnswerPipeAlias = AnswerPipeAliasTextBox.Text;
			updatedAnswer.Mandatory = MandatoryCheckBox.Checked;
			if (RegExDropDownList.SelectedIndex > 0)
			{
				updatedAnswer.RegularExpressionId = int.Parse(RegExDropDownList.SelectedValue);
			}
			answer.Answers.AddAnswersRow(updatedAnswer);
			new Answer().UpdateAnswer(answer, LanguageCode);
			
			int newTypeMode = new Answers().GetAnswerTypeMode(AnswerId);
			
			// Check if need to delete persisted properties if it was
			// previously an extended item
			if (oldTypeMode != newTypeMode && ((AnswerTypeMode)oldTypeMode & AnswerTypeMode.ExtendedType)>0)
			{
				new Answer().DeleteAnswerProperties(AnswerId);
			}

			MessageLabel.Visible = true;
            ((PageBase)Page).ShowNormalMessage(MessageLabel,((PageBase)Page).GetPageResource("SelectionUpdatedMessage"));

			SetUIState(newTypeMode, false);

			// Let the subscribers know that something changed
			OnOptionChanged();

		}

		private void AnswerTypeDropDownList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            AnswerTypeData typeData = new AnswerTypes().GetAnswerTypeById(int.Parse(AnswerTypeDropDownList.SelectedValue, System.Globalization.CultureInfo.InvariantCulture));
			SetUIState(typeData.AnswerTypes[0].TypeMode, true);
		}

		private void CancelAnswerButton_Click(object sender, System.EventArgs e)
		{
			AnswerId = -1;
			Visible = false;		
		}

		private void AvailablePublishersListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            new Answer().SubscribeToPublisher(int.Parse(AvailablePublishersListBox.SelectedValue, System.Globalization.CultureInfo.InvariantCulture), AnswerId);
			BindData();
			MessageLabel.Visible = true;
            ((PageBase)Page).ShowNormalMessage(MessageLabel,((PageBase)Page).GetPageResource("SelectionUpdatedMessage"));
		}

		private void SubscribedListbox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            new Answer().UnSubscribeFromPublisher(int.Parse(SubscribedListbox.SelectedValue, System.Globalization.CultureInfo.InvariantCulture), AnswerId);
			BindData();
			MessageLabel.Visible = true;
            ((PageBase)Page).ShowNormalMessage(MessageLabel,((PageBase)Page).GetPageResource("SelectionUpdatedMessage"));
		
		}

	}
}
