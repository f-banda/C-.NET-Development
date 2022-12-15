
namespace mathteam_Assign2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.rich_Output = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dragWindow = new System.Windows.Forms.Panel();
            this.Title = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.group_Communities = new System.Windows.Forms.GroupBox();
            this.comm_Sycamore = new System.Windows.Forms.RadioButton();
            this.comm_DeKalb = new System.Windows.Forms.RadioButton();
            this.group_addResident = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label_Residence = new System.Windows.Forms.Label();
            this.button_AddNewResident = new System.Windows.Forms.Button();
            this.input_Birthday = new System.Windows.Forms.DateTimePicker();
            this.label_Birthday = new System.Windows.Forms.Label();
            this.label_Occupation = new System.Windows.Forms.Label();
            this.input_Occupation = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.input_Name = new System.Windows.Forms.TextBox();
            this.group_addProperty = new System.Windows.Forms.GroupBox();
            this.bool_attachedGarage = new System.Windows.Forms.CheckBox();
            this.input_Floors = new System.Windows.Forms.NumericUpDown();
            this.input_Baths = new System.Windows.Forms.NumericUpDown();
            this.input_Bedrooms = new System.Windows.Forms.NumericUpDown();
            this.input_SqrFt = new System.Windows.Forms.NumericUpDown();
            this.button_addNewProperty = new System.Windows.Forms.Button();
            this.bool_Garage = new System.Windows.Forms.CheckBox();
            this.label_Floors = new System.Windows.Forms.Label();
            this.label_Baths = new System.Windows.Forms.Label();
            this.label_Bedrooms = new System.Windows.Forms.Label();
            this.label_SqrFt = new System.Windows.Forms.Label();
            this.label_AptNum = new System.Windows.Forms.Label();
            this.input_AptNum = new System.Windows.Forms.TextBox();
            this.label_Address = new System.Windows.Forms.Label();
            this.input_Address = new System.Windows.Forms.TextBox();
            this.list_Person = new System.Windows.Forms.ListBox();
            this.list_Residence = new System.Windows.Forms.ListBox();
            this.label_PersonList = new System.Windows.Forms.Label();
            this.label_ResidenceList = new System.Windows.Forms.Label();
            this.button_toggleSale = new System.Windows.Forms.Button();
            this.button_buyProperty = new System.Windows.Forms.Button();
            this.button_AddResident = new System.Windows.Forms.Button();
            this.button_removeResident = new System.Windows.Forms.Button();
            this.dragWindow.SuspendLayout();
            this.group_Communities.SuspendLayout();
            this.group_addResident.SuspendLayout();
            this.group_addProperty.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_Floors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_Baths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_Bedrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_SqrFt)).BeginInit();
            this.SuspendLayout();
            // 
            // rich_Output
            // 
            this.rich_Output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(40)))), ((int)(((byte)(47)))));
            this.rich_Output.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rich_Output.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rich_Output.ForeColor = System.Drawing.Color.White;
            this.rich_Output.Location = new System.Drawing.Point(12, 576);
            this.rich_Output.Name = "rich_Output";
            this.rich_Output.ReadOnly = true;
            this.rich_Output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rich_Output.Size = new System.Drawing.Size(989, 139);
            this.rich_Output.TabIndex = 0;
            this.rich_Output.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 552);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output";
            // 
            // dragWindow
            // 
            this.dragWindow.Controls.Add(this.Title);
            this.dragWindow.Location = new System.Drawing.Point(0, 0);
            this.dragWindow.Margin = new System.Windows.Forms.Padding(0);
            this.dragWindow.Name = "dragWindow";
            this.dragWindow.Size = new System.Drawing.Size(993, 36);
            this.dragWindow.TabIndex = 2;
            this.dragWindow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDown_Event);
            this.dragWindow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMove_Event);
            this.dragWindow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUp_Event);
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(355, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(303, 20);
            this.Title.TabIndex = 1;
            this.Title.Text = "Math Team - Real Estate Application";
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Firebrick;
            this.exit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exit.ForeColor = System.Drawing.Color.White;
            this.exit.Location = new System.Drawing.Point(951, 5);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(56, 28);
            this.exit.TabIndex = 0;
            this.exit.Text = "X";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.button1_Click);
            // 
            // group_Communities
            // 
            this.group_Communities.Controls.Add(this.comm_Sycamore);
            this.group_Communities.Controls.Add(this.comm_DeKalb);
            this.group_Communities.ForeColor = System.Drawing.Color.White;
            this.group_Communities.Location = new System.Drawing.Point(12, 39);
            this.group_Communities.Name = "group_Communities";
            this.group_Communities.Size = new System.Drawing.Size(223, 100);
            this.group_Communities.TabIndex = 4;
            this.group_Communities.TabStop = false;
            this.group_Communities.Text = "Communities";
            // 
            // comm_Sycamore
            // 
            this.comm_Sycamore.AutoSize = true;
            this.comm_Sycamore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comm_Sycamore.Location = new System.Drawing.Point(38, 57);
            this.comm_Sycamore.Name = "comm_Sycamore";
            this.comm_Sycamore.Size = new System.Drawing.Size(94, 22);
            this.comm_Sycamore.TabIndex = 1;
            this.comm_Sycamore.TabStop = true;
            this.comm_Sycamore.Text = "Sycamore";
            this.comm_Sycamore.UseVisualStyleBackColor = true;
            this.comm_Sycamore.CheckedChanged += new System.EventHandler(this.comm_Sycamore_CheckedChanged);
            // 
            // comm_DeKalb
            // 
            this.comm_DeKalb.AutoSize = true;
            this.comm_DeKalb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comm_DeKalb.Location = new System.Drawing.Point(38, 29);
            this.comm_DeKalb.Name = "comm_DeKalb";
            this.comm_DeKalb.Size = new System.Drawing.Size(74, 22);
            this.comm_DeKalb.TabIndex = 0;
            this.comm_DeKalb.TabStop = true;
            this.comm_DeKalb.Text = "DeKalb";
            this.comm_DeKalb.UseVisualStyleBackColor = true;
            this.comm_DeKalb.CheckedChanged += new System.EventHandler(this.comm_DeKalb_CheckedChanged);
            // 
            // group_addResident
            // 
            this.group_addResident.Controls.Add(this.comboBox1);
            this.group_addResident.Controls.Add(this.label_Residence);
            this.group_addResident.Controls.Add(this.button_AddNewResident);
            this.group_addResident.Controls.Add(this.input_Birthday);
            this.group_addResident.Controls.Add(this.label_Birthday);
            this.group_addResident.Controls.Add(this.label_Occupation);
            this.group_addResident.Controls.Add(this.input_Occupation);
            this.group_addResident.Controls.Add(this.label_Name);
            this.group_addResident.Controls.Add(this.input_Name);
            this.group_addResident.ForeColor = System.Drawing.Color.White;
            this.group_addResident.Location = new System.Drawing.Point(12, 216);
            this.group_addResident.Name = "group_addResident";
            this.group_addResident.Size = new System.Drawing.Size(223, 264);
            this.group_addResident.TabIndex = 5;
            this.group_addResident.TabStop = false;
            this.group_addResident.Text = "Add New Resident";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 196);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label_Residence
            // 
            this.label_Residence.AutoSize = true;
            this.label_Residence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Residence.Location = new System.Drawing.Point(3, 177);
            this.label_Residence.Name = "label_Residence";
            this.label_Residence.Size = new System.Drawing.Size(74, 16);
            this.label_Residence.TabIndex = 7;
            this.label_Residence.Text = "Residence";
            // 
            // button_AddNewResident
            // 
            this.button_AddNewResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddNewResident.ForeColor = System.Drawing.Color.Black;
            this.button_AddNewResident.Location = new System.Drawing.Point(143, 230);
            this.button_AddNewResident.Name = "button_AddNewResident";
            this.button_AddNewResident.Size = new System.Drawing.Size(75, 25);
            this.button_AddNewResident.TabIndex = 6;
            this.button_AddNewResident.Text = "Add";
            this.button_AddNewResident.UseVisualStyleBackColor = true;
            this.button_AddNewResident.Click += new System.EventHandler(this.button_AddNewResident_Click);
            // 
            // input_Birthday
            // 
            this.input_Birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Birthday.Location = new System.Drawing.Point(6, 145);
            this.input_Birthday.Name = "input_Birthday";
            this.input_Birthday.Size = new System.Drawing.Size(211, 20);
            this.input_Birthday.TabIndex = 5;
            this.input_Birthday.ValueChanged += new System.EventHandler(this.input_Birthday_ValueChanged);
            // 
            // label_Birthday
            // 
            this.label_Birthday.AutoSize = true;
            this.label_Birthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Birthday.Location = new System.Drawing.Point(3, 126);
            this.label_Birthday.Name = "label_Birthday";
            this.label_Birthday.Size = new System.Drawing.Size(57, 16);
            this.label_Birthday.TabIndex = 4;
            this.label_Birthday.Text = "Birthday";
            // 
            // label_Occupation
            // 
            this.label_Occupation.AutoSize = true;
            this.label_Occupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Occupation.Location = new System.Drawing.Point(3, 74);
            this.label_Occupation.Name = "label_Occupation";
            this.label_Occupation.Size = new System.Drawing.Size(76, 16);
            this.label_Occupation.TabIndex = 3;
            this.label_Occupation.Text = "Occupation";
            // 
            // input_Occupation
            // 
            this.input_Occupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Occupation.Location = new System.Drawing.Point(6, 93);
            this.input_Occupation.Name = "input_Occupation";
            this.input_Occupation.Size = new System.Drawing.Size(212, 22);
            this.input_Occupation.TabIndex = 2;
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.Location = new System.Drawing.Point(3, 28);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(45, 16);
            this.label_Name.TabIndex = 1;
            this.label_Name.Text = "Name";
            // 
            // input_Name
            // 
            this.input_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Name.Location = new System.Drawing.Point(6, 47);
            this.input_Name.Name = "input_Name";
            this.input_Name.Size = new System.Drawing.Size(211, 22);
            this.input_Name.TabIndex = 0;
            // 
            // group_addProperty
            // 
            this.group_addProperty.Controls.Add(this.bool_attachedGarage);
            this.group_addProperty.Controls.Add(this.input_Floors);
            this.group_addProperty.Controls.Add(this.input_Baths);
            this.group_addProperty.Controls.Add(this.input_Bedrooms);
            this.group_addProperty.Controls.Add(this.input_SqrFt);
            this.group_addProperty.Controls.Add(this.button_addNewProperty);
            this.group_addProperty.Controls.Add(this.bool_Garage);
            this.group_addProperty.Controls.Add(this.label_Floors);
            this.group_addProperty.Controls.Add(this.label_Baths);
            this.group_addProperty.Controls.Add(this.label_Bedrooms);
            this.group_addProperty.Controls.Add(this.label_SqrFt);
            this.group_addProperty.Controls.Add(this.label_AptNum);
            this.group_addProperty.Controls.Add(this.input_AptNum);
            this.group_addProperty.Controls.Add(this.label_Address);
            this.group_addProperty.Controls.Add(this.input_Address);
            this.group_addProperty.ForeColor = System.Drawing.Color.White;
            this.group_addProperty.Location = new System.Drawing.Point(260, 216);
            this.group_addProperty.Name = "group_addProperty";
            this.group_addProperty.Size = new System.Drawing.Size(223, 264);
            this.group_addProperty.TabIndex = 6;
            this.group_addProperty.TabStop = false;
            this.group_addProperty.Text = "Add Property";
            // 
            // bool_attachedGarage
            // 
            this.bool_attachedGarage.AutoSize = true;
            this.bool_attachedGarage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bool_attachedGarage.Location = new System.Drawing.Point(99, 196);
            this.bool_attachedGarage.Name = "bool_attachedGarage";
            this.bool_attachedGarage.Size = new System.Drawing.Size(87, 20);
            this.bool_attachedGarage.TabIndex = 24;
            this.bool_attachedGarage.Text = "Attached?";
            this.bool_attachedGarage.UseVisualStyleBackColor = true;
            this.bool_attachedGarage.Visible = false;
            // 
            // input_Floors
            // 
            this.input_Floors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_Floors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Floors.Location = new System.Drawing.Point(156, 145);
            this.input_Floors.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_Floors.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_Floors.Name = "input_Floors";
            this.input_Floors.Size = new System.Drawing.Size(38, 22);
            this.input_Floors.TabIndex = 23;
            this.input_Floors.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // input_Baths
            // 
            this.input_Baths.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_Baths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Baths.Location = new System.Drawing.Point(86, 145);
            this.input_Baths.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_Baths.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_Baths.Name = "input_Baths";
            this.input_Baths.Size = new System.Drawing.Size(38, 22);
            this.input_Baths.TabIndex = 22;
            this.input_Baths.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // input_Bedrooms
            // 
            this.input_Bedrooms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_Bedrooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Bedrooms.Location = new System.Drawing.Point(6, 145);
            this.input_Bedrooms.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.input_Bedrooms.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.input_Bedrooms.Name = "input_Bedrooms";
            this.input_Bedrooms.Size = new System.Drawing.Size(38, 22);
            this.input_Bedrooms.TabIndex = 21;
            this.input_Bedrooms.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // input_SqrFt
            // 
            this.input_SqrFt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.input_SqrFt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_SqrFt.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.input_SqrFt.Location = new System.Drawing.Point(6, 93);
            this.input_SqrFt.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.input_SqrFt.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.input_SqrFt.Name = "input_SqrFt";
            this.input_SqrFt.Size = new System.Drawing.Size(69, 22);
            this.input_SqrFt.TabIndex = 20;
            this.input_SqrFt.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // button_addNewProperty
            // 
            this.button_addNewProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addNewProperty.ForeColor = System.Drawing.Color.Black;
            this.button_addNewProperty.Location = new System.Drawing.Point(142, 230);
            this.button_addNewProperty.Name = "button_addNewProperty";
            this.button_addNewProperty.Size = new System.Drawing.Size(75, 25);
            this.button_addNewProperty.TabIndex = 7;
            this.button_addNewProperty.Text = "Add";
            this.button_addNewProperty.UseVisualStyleBackColor = true;
            this.button_addNewProperty.Click += new System.EventHandler(this.button_addNewProperty_Click);
            // 
            // bool_Garage
            // 
            this.bool_Garage.AutoSize = true;
            this.bool_Garage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bool_Garage.Location = new System.Drawing.Point(6, 196);
            this.bool_Garage.Name = "bool_Garage";
            this.bool_Garage.Size = new System.Drawing.Size(80, 20);
            this.bool_Garage.TabIndex = 19;
            this.bool_Garage.Text = "Garage?";
            this.bool_Garage.UseVisualStyleBackColor = true;
            this.bool_Garage.CheckedChanged += new System.EventHandler(this.bool_Garage_CheckedChanged);
            // 
            // label_Floors
            // 
            this.label_Floors.AutoSize = true;
            this.label_Floors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Floors.Location = new System.Drawing.Point(153, 126);
            this.label_Floors.Name = "label_Floors";
            this.label_Floors.Size = new System.Drawing.Size(46, 16);
            this.label_Floors.TabIndex = 17;
            this.label_Floors.Text = "Floors";
            // 
            // label_Baths
            // 
            this.label_Baths.AutoSize = true;
            this.label_Baths.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Baths.Location = new System.Drawing.Point(83, 126);
            this.label_Baths.Name = "label_Baths";
            this.label_Baths.Size = new System.Drawing.Size(42, 16);
            this.label_Baths.TabIndex = 15;
            this.label_Baths.Text = "Baths";
            // 
            // label_Bedrooms
            // 
            this.label_Bedrooms.AutoSize = true;
            this.label_Bedrooms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Bedrooms.Location = new System.Drawing.Point(3, 126);
            this.label_Bedrooms.Name = "label_Bedrooms";
            this.label_Bedrooms.Size = new System.Drawing.Size(71, 16);
            this.label_Bedrooms.TabIndex = 13;
            this.label_Bedrooms.Text = "Bedrooms";
            // 
            // label_SqrFt
            // 
            this.label_SqrFt.AutoSize = true;
            this.label_SqrFt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SqrFt.Location = new System.Drawing.Point(3, 74);
            this.label_SqrFt.Name = "label_SqrFt";
            this.label_SqrFt.Size = new System.Drawing.Size(106, 16);
            this.label_SqrFt.TabIndex = 11;
            this.label_SqrFt.Text = "Square Footage";
            // 
            // label_AptNum
            // 
            this.label_AptNum.AutoSize = true;
            this.label_AptNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AptNum.Location = new System.Drawing.Point(165, 28);
            this.label_AptNum.Name = "label_AptNum";
            this.label_AptNum.Size = new System.Drawing.Size(41, 16);
            this.label_AptNum.TabIndex = 10;
            this.label_AptNum.Text = "Apt. #";
            // 
            // input_AptNum
            // 
            this.input_AptNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_AptNum.Location = new System.Drawing.Point(168, 47);
            this.input_AptNum.Name = "input_AptNum";
            this.input_AptNum.Size = new System.Drawing.Size(49, 22);
            this.input_AptNum.TabIndex = 9;
            this.input_AptNum.TextChanged += new System.EventHandler(this.input_AptNum_TextChanged);
            // 
            // label_Address
            // 
            this.label_Address.AutoSize = true;
            this.label_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Address.Location = new System.Drawing.Point(3, 28);
            this.label_Address.Name = "label_Address";
            this.label_Address.Size = new System.Drawing.Size(97, 16);
            this.label_Address.TabIndex = 8;
            this.label_Address.Text = "Street Address";
            // 
            // input_Address
            // 
            this.input_Address.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_Address.Location = new System.Drawing.Point(6, 47);
            this.input_Address.Name = "input_Address";
            this.input_Address.Size = new System.Drawing.Size(156, 22);
            this.input_Address.TabIndex = 7;
            // 
            // list_Person
            // 
            this.list_Person.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Person.FormattingEnabled = true;
            this.list_Person.ItemHeight = 16;
            this.list_Person.Location = new System.Drawing.Point(498, 66);
            this.list_Person.Name = "list_Person";
            this.list_Person.Size = new System.Drawing.Size(236, 468);
            this.list_Person.TabIndex = 7;
            this.list_Person.SelectedIndexChanged += new System.EventHandler(this.list_Person_SelectedIndexChanged_1);
            // 
            // list_Residence
            // 
            this.list_Residence.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Residence.FormattingEnabled = true;
            this.list_Residence.ItemHeight = 16;
            this.list_Residence.Location = new System.Drawing.Point(740, 66);
            this.list_Residence.Name = "list_Residence";
            this.list_Residence.Size = new System.Drawing.Size(261, 468);
            this.list_Residence.TabIndex = 8;
            this.list_Residence.SelectedIndexChanged += new System.EventHandler(this.list_Residence_SelectedIndexChanged);
            // 
            // label_PersonList
            // 
            this.label_PersonList.AutoSize = true;
            this.label_PersonList.ForeColor = System.Drawing.Color.White;
            this.label_PersonList.Location = new System.Drawing.Point(494, 39);
            this.label_PersonList.Name = "label_PersonList";
            this.label_PersonList.Size = new System.Drawing.Size(59, 20);
            this.label_PersonList.TabIndex = 9;
            this.label_PersonList.Text = "Person";
            // 
            // label_ResidenceList
            // 
            this.label_ResidenceList.AutoSize = true;
            this.label_ResidenceList.ForeColor = System.Drawing.Color.White;
            this.label_ResidenceList.Location = new System.Drawing.Point(735, 39);
            this.label_ResidenceList.Name = "label_ResidenceList";
            this.label_ResidenceList.Size = new System.Drawing.Size(209, 20);
            this.label_ResidenceList.TabIndex = 10;
            this.label_ResidenceList.Text = "Residence ( ⚡ == For Sale )";
            // 
            // button_toggleSale
            // 
            this.button_toggleSale.AutoSize = true;
            this.button_toggleSale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_toggleSale.Location = new System.Drawing.Point(356, 66);
            this.button_toggleSale.Name = "button_toggleSale";
            this.button_toggleSale.Size = new System.Drawing.Size(136, 28);
            this.button_toggleSale.TabIndex = 11;
            this.button_toggleSale.Text = "Toggle For-Sale";
            this.button_toggleSale.UseVisualStyleBackColor = true;
            this.button_toggleSale.Click += new System.EventHandler(this.button_toggleSale_Click);
            // 
            // button_buyProperty
            // 
            this.button_buyProperty.AutoSize = true;
            this.button_buyProperty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_buyProperty.Location = new System.Drawing.Point(356, 96);
            this.button_buyProperty.Name = "button_buyProperty";
            this.button_buyProperty.Size = new System.Drawing.Size(136, 28);
            this.button_buyProperty.TabIndex = 12;
            this.button_buyProperty.Text = "Buy Property";
            this.button_buyProperty.UseVisualStyleBackColor = true;
            this.button_buyProperty.Click += new System.EventHandler(this.button_buyProperty_Click);
            // 
            // button_AddResident
            // 
            this.button_AddResident.AutoSize = true;
            this.button_AddResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddResident.Location = new System.Drawing.Point(356, 127);
            this.button_AddResident.Name = "button_AddResident";
            this.button_AddResident.Size = new System.Drawing.Size(136, 28);
            this.button_AddResident.TabIndex = 13;
            this.button_AddResident.Text = "Add Resident";
            this.button_AddResident.UseVisualStyleBackColor = true;
            this.button_AddResident.Click += new System.EventHandler(this.button_AddResident_Click);
            // 
            // button_removeResident
            // 
            this.button_removeResident.AutoSize = true;
            this.button_removeResident.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeResident.Location = new System.Drawing.Point(356, 158);
            this.button_removeResident.Name = "button_removeResident";
            this.button_removeResident.Size = new System.Drawing.Size(136, 28);
            this.button_removeResident.TabIndex = 14;
            this.button_removeResident.Text = "Remove Resident";
            this.button_removeResident.UseVisualStyleBackColor = true;
            this.button_removeResident.Click += new System.EventHandler(this.button_removeResident_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1013, 727);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.dragWindow);
            this.Controls.Add(this.button_removeResident);
            this.Controls.Add(this.button_AddResident);
            this.Controls.Add(this.button_buyProperty);
            this.Controls.Add(this.button_toggleSale);
            this.Controls.Add(this.label_ResidenceList);
            this.Controls.Add(this.label_PersonList);
            this.Controls.Add(this.list_Residence);
            this.Controls.Add(this.list_Person);
            this.Controls.Add(this.group_addProperty);
            this.Controls.Add(this.group_addResident);
            this.Controls.Add(this.group_Communities);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rich_Output);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Math Team - Real Estate Management";
            this.dragWindow.ResumeLayout(false);
            this.dragWindow.PerformLayout();
            this.group_Communities.ResumeLayout(false);
            this.group_Communities.PerformLayout();
            this.group_addResident.ResumeLayout(false);
            this.group_addResident.PerformLayout();
            this.group_addProperty.ResumeLayout(false);
            this.group_addProperty.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.input_Floors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_Baths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_Bedrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.input_SqrFt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rich_Output;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel dragWindow;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.GroupBox group_Communities;
        private System.Windows.Forms.RadioButton comm_Sycamore;
        private System.Windows.Forms.RadioButton comm_DeKalb;
        private System.Windows.Forms.GroupBox group_addResident;
        private System.Windows.Forms.GroupBox group_addProperty;
        private System.Windows.Forms.DateTimePicker input_Birthday;
        private System.Windows.Forms.Label label_Birthday;
        private System.Windows.Forms.Label label_Occupation;
        private System.Windows.Forms.TextBox input_Occupation;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.TextBox input_Name;
        private System.Windows.Forms.Button button_AddNewResident;
        private System.Windows.Forms.ListBox list_Person;
        private System.Windows.Forms.ListBox list_Residence;
        private System.Windows.Forms.Label label_PersonList;
        private System.Windows.Forms.Label label_ResidenceList;
        private System.Windows.Forms.Button button_toggleSale;
        private System.Windows.Forms.Button button_buyProperty;
        private System.Windows.Forms.Button button_AddResident;
        private System.Windows.Forms.Label label_SqrFt;
        private System.Windows.Forms.Label label_AptNum;
        private System.Windows.Forms.TextBox input_AptNum;
        private System.Windows.Forms.Label label_Address;
        private System.Windows.Forms.TextBox input_Address;
        private System.Windows.Forms.Button button_removeResident;
        private System.Windows.Forms.Button button_addNewProperty;
        private System.Windows.Forms.CheckBox bool_Garage;
        private System.Windows.Forms.Label label_Floors;
        private System.Windows.Forms.Label label_Baths;
        private System.Windows.Forms.Label label_Bedrooms;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.NumericUpDown input_SqrFt;
        private System.Windows.Forms.NumericUpDown input_Bedrooms;
        private System.Windows.Forms.NumericUpDown input_Floors;
        private System.Windows.Forms.NumericUpDown input_Baths;
        private System.Windows.Forms.Label label_Residence;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox bool_attachedGarage;
    }
}

