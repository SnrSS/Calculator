using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Calculator
{

  /// ОПИСАНИЯ И КОНСТРУКТОРЫ
  ///-----------------------------------------------------

  // перечесление для выбора системы счисления	
  enum CountingSystems
  {
    Dec, Oct, Bin, Hex
  }
  // перечесление для выбора винарных операций	
  public enum Operations
  {
    Add, Sub, Mul, Div, Pow, Mod
  }
  public class frmMain : Form
  {
    // элементы управления интерфейса - их функциональность понятна из названия
    private TextBox txtDisplay;
    private Button btnComma;
    private Button btnPlusMinus;
    private Button btnKey0;
    private Button btnKey2;
    private Button btnKey3;
    private Button btnKey1;
    private Button btnKey5;
    private Button btnKey9;
    private Button btnKey8;
    private Button btnDiv;
    private Button btnKey7;
    private Button btnKey4;
    private Button btnKey6;
    private Button btnClearAll;
    private Button btnClearEnter;
    private Button btnBackSpace;
    private Button btnAdd;
    private Button btnSub;

    private Button btnMul;
    private Button btnPow;
    private Button btnFactorial;

    private Button btnLn;
    private Button btnExp;
    private Button btnPow2;
    private Button btnPow3;
    private Button btnCos;
    private Button btnSin;
    private Button btnMod;
    private Button btnOr;

    private Button btnXor;
    private Button btnNot;
    private Button btnAnd;
    private Button btnLg;
    private Button btnTg;

    // кнопки для работы с регистром памяити калькулятора - для них нет кода
    //  private Button btnMemoryRestore;
    //	private Button btnMemoryClear;
    //	private Button btnMemoryShift;
    //private Button btnMemoryAdd;

    //кнопка "равно"
    private Button btnEqual;

    // переключатель для выбора системы счисления
    private ComboBox cmbSystem;

    // поле ввода/вывода 
    private TextBox txtFullExpression;

    // стек для ввода цифр в поле ввода/вывода
    private Stack _digits;

    //переменная равна TRUE, если введено отрицательное число (нажата кнопка btnPlusMinus)
    private bool _negative;

    //какая система счисления
    private CountingSystems _currentSystem;

    //какая операция
    private Operations _currentOperation;

    //переменные для операндов (вычислений)
    private double X;
    private double Y;

    //конструктор формы 
    public frmMain()
    {
      //эта процедура всегда выполняется в конструкторе формы - создается форма и контролы
      InitializeComponent();
      //инициализация калькулятора
      InitCalculator();
    }

    //стартовые значения пользовательских переменных
    private void InitCalculator()
    { //операнды положительны
      _negative = false;
      //стек цифр операнда инициализирован 
      _digits = new Stack();
      //в поле ввода/вывода - ноль
      txtDisplay.Text = "0";
      //выбрана десятичная система счисления
      cmbSystem.SelectedIndex = 1;
    }
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>




    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    /// Процедура InitializeComponent всегда пишется автоматически 
    /// на основании действий, выполняемых во вкладке Form[Design]
    /// визуальными средствами. Код этой процедуры ни в коем случае не
    /// модифицируется вручную.

    private void InitializeComponent()
    {
      this.txtDisplay = new System.Windows.Forms.TextBox();
      this.btnEqual = new System.Windows.Forms.Button();
      this.btnAdd = new System.Windows.Forms.Button();
      this.btnComma = new System.Windows.Forms.Button();
      this.btnPlusMinus = new System.Windows.Forms.Button();
      this.btnKey0 = new System.Windows.Forms.Button();
      this.btnSub = new System.Windows.Forms.Button();
      this.btnKey2 = new System.Windows.Forms.Button();
      this.btnKey3 = new System.Windows.Forms.Button();
      this.btnKey1 = new System.Windows.Forms.Button();
      this.btnKey5 = new System.Windows.Forms.Button();
      this.btnPow = new System.Windows.Forms.Button();
      this.btnKey9 = new System.Windows.Forms.Button();
      this.btnKey8 = new System.Windows.Forms.Button();
      this.btnDiv = new System.Windows.Forms.Button();
      this.btnKey7 = new System.Windows.Forms.Button();
      this.btnKey4 = new System.Windows.Forms.Button();
      this.btnMul = new System.Windows.Forms.Button();
      this.btnKey6 = new System.Windows.Forms.Button();
      this.btnClearAll = new System.Windows.Forms.Button();
      this.btnClearEnter = new System.Windows.Forms.Button();
      this.btnBackSpace = new System.Windows.Forms.Button();
      this.btnFactorial = new System.Windows.Forms.Button();
      this.btnLg = new System.Windows.Forms.Button();
      this.btnLn = new System.Windows.Forms.Button();
      this.btnExp = new System.Windows.Forms.Button();
      this.btnPow2 = new System.Windows.Forms.Button();
      this.btnPow3 = new System.Windows.Forms.Button();
      this.btnTg = new System.Windows.Forms.Button();
      this.btnCos = new System.Windows.Forms.Button();
      this.btnSin = new System.Windows.Forms.Button();
      this.btnMod = new System.Windows.Forms.Button();
      this.btnOr = new System.Windows.Forms.Button();
      this.btnXor = new System.Windows.Forms.Button();
      this.btnNot = new System.Windows.Forms.Button();
      this.btnAnd = new System.Windows.Forms.Button();
      this.cmbSystem = new System.Windows.Forms.ComboBox();
      this.txtFullExpression = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // txtDisplay
      // 
      this.txtDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDisplay.BackColor = System.Drawing.SystemColors.Control;
      this.txtDisplay.Cursor = System.Windows.Forms.Cursors.Default;
      this.txtDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtDisplay.ForeColor = System.Drawing.Color.Black;
      this.txtDisplay.Location = new System.Drawing.Point(8, 8);
      this.txtDisplay.MaxLength = 32;
      this.txtDisplay.Name = "txtDisplay";
      this.txtDisplay.ReadOnly = true;
      this.txtDisplay.Size = new System.Drawing.Size(398, 20);
      this.txtDisplay.TabIndex = 0;
      this.txtDisplay.TabStop = false;
      this.txtDisplay.Text = "0";
      this.txtDisplay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      // 
      // btnEqual
      // 
      this.btnEqual.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEqual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
      this.btnEqual.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnEqual.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnEqual.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.btnEqual.ForeColor = System.Drawing.Color.DeepPink;
      this.btnEqual.Location = new System.Drawing.Point(332, 148);
      this.btnEqual.Name = "btnEqual";
      this.btnEqual.Size = new System.Drawing.Size(36, 23);
      this.btnEqual.TabIndex = 1;
      this.btnEqual.TabStop = false;
      this.btnEqual.Text = "=";
      this.btnEqual.UseVisualStyleBackColor = false;
      this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
      // 
      // btnAdd
      // 
      this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
      this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAdd.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.btnAdd.ForeColor = System.Drawing.Color.Red;
      this.btnAdd.Location = new System.Drawing.Point(292, 148);
      this.btnAdd.Name = "btnAdd";
      this.btnAdd.Size = new System.Drawing.Size(36, 23);
      this.btnAdd.TabIndex = 1;
      this.btnAdd.TabStop = false;
      this.btnAdd.Text = "+";
      this.btnAdd.UseVisualStyleBackColor = false;
      this.btnAdd.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnComma
      // 
      this.btnComma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnComma.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnComma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnComma.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnComma.ForeColor = System.Drawing.Color.Blue;
      this.btnComma.Location = new System.Drawing.Point(252, 148);
      this.btnComma.Name = "btnComma";
      this.btnComma.Size = new System.Drawing.Size(36, 23);
      this.btnComma.TabIndex = 1;
      this.btnComma.TabStop = false;
      this.btnComma.Text = ",";
      this.btnComma.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnPlusMinus
      // 
      this.btnPlusMinus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPlusMinus.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnPlusMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPlusMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.btnPlusMinus.ForeColor = System.Drawing.Color.Blue;
      this.btnPlusMinus.Location = new System.Drawing.Point(212, 148);
      this.btnPlusMinus.Name = "btnPlusMinus";
      this.btnPlusMinus.Size = new System.Drawing.Size(36, 23);
      this.btnPlusMinus.TabIndex = 1;
      this.btnPlusMinus.TabStop = false;
      this.btnPlusMinus.Text = "+/-";
      this.btnPlusMinus.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnKey0
      // 
      this.btnKey0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey0.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey0.ForeColor = System.Drawing.Color.Blue;
      this.btnKey0.Location = new System.Drawing.Point(172, 148);
      this.btnKey0.Name = "btnKey0";
      this.btnKey0.Size = new System.Drawing.Size(36, 23);
      this.btnKey0.TabIndex = 1;
      this.btnKey0.TabStop = false;
      this.btnKey0.Text = "0";
      this.btnKey0.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnSub
      // 
      this.btnSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnSub.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSub.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.btnSub.ForeColor = System.Drawing.Color.Green;
      this.btnSub.Location = new System.Drawing.Point(292, 120);
      this.btnSub.Name = "btnSub";
      this.btnSub.Size = new System.Drawing.Size(36, 23);
      this.btnSub.TabIndex = 1;
      this.btnSub.TabStop = false;
      this.btnSub.Text = "-";
      this.btnSub.UseVisualStyleBackColor = false;
      this.btnSub.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnKey2
      // 
      this.btnKey2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey2.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey2.ForeColor = System.Drawing.Color.Blue;
      this.btnKey2.Location = new System.Drawing.Point(212, 120);
      this.btnKey2.Name = "btnKey2";
      this.btnKey2.Size = new System.Drawing.Size(36, 23);
      this.btnKey2.TabIndex = 1;
      this.btnKey2.TabStop = false;
      this.btnKey2.Text = "2";
      this.btnKey2.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnKey3
      // 
      this.btnKey3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey3.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey3.ForeColor = System.Drawing.Color.Blue;
      this.btnKey3.Location = new System.Drawing.Point(252, 120);
      this.btnKey3.Name = "btnKey3";
      this.btnKey3.Size = new System.Drawing.Size(36, 23);
      this.btnKey3.TabIndex = 1;
      this.btnKey3.TabStop = false;
      this.btnKey3.Text = "3";
      this.btnKey3.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnKey1
      // 
      this.btnKey1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey1.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey1.ForeColor = System.Drawing.Color.Blue;
      this.btnKey1.Location = new System.Drawing.Point(172, 120);
      this.btnKey1.Name = "btnKey1";
      this.btnKey1.Size = new System.Drawing.Size(36, 23);
      this.btnKey1.TabIndex = 1;
      this.btnKey1.TabStop = false;
      this.btnKey1.Text = "1";
      this.btnKey1.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnKey5
      // 
      this.btnKey5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey5.BackColor = System.Drawing.SystemColors.Control;
      this.btnKey5.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey5.ForeColor = System.Drawing.Color.Blue;
      this.btnKey5.Location = new System.Drawing.Point(212, 92);
      this.btnKey5.Name = "btnKey5";
      this.btnKey5.Size = new System.Drawing.Size(36, 23);
      this.btnKey5.TabIndex = 1;
      this.btnKey5.TabStop = false;
      this.btnKey5.Text = "5";
      this.btnKey5.UseVisualStyleBackColor = false;
      this.btnKey5.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnPow
      // 
      this.btnPow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnPow.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnPow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPow.ForeColor = System.Drawing.Color.Green;
      this.btnPow.Location = new System.Drawing.Point(56, 120);
      this.btnPow.Name = "btnPow";
      this.btnPow.Size = new System.Drawing.Size(32, 23);
      this.btnPow.TabIndex = 1;
      this.btnPow.TabStop = false;
      this.btnPow.Text = "x^y";
      this.btnPow.UseVisualStyleBackColor = false;
      this.btnPow.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnKey9
      // 
      this.btnKey9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey9.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey9.ForeColor = System.Drawing.Color.Blue;
      this.btnKey9.Location = new System.Drawing.Point(252, 64);
      this.btnKey9.Name = "btnKey9";
      this.btnKey9.Size = new System.Drawing.Size(36, 23);
      this.btnKey9.TabIndex = 1;
      this.btnKey9.TabStop = false;
      this.btnKey9.Text = "9";
      this.btnKey9.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnKey8
      // 
      this.btnKey8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey8.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey8.ForeColor = System.Drawing.Color.Blue;
      this.btnKey8.Location = new System.Drawing.Point(212, 64);
      this.btnKey8.Name = "btnKey8";
      this.btnKey8.Size = new System.Drawing.Size(36, 23);
      this.btnKey8.TabIndex = 1;
      this.btnKey8.TabStop = false;
      this.btnKey8.Text = "8";
      this.btnKey8.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnDiv
      // 
      this.btnDiv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnDiv.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnDiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnDiv.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.btnDiv.ForeColor = System.Drawing.Color.Green;
      this.btnDiv.Location = new System.Drawing.Point(292, 64);
      this.btnDiv.Name = "btnDiv";
      this.btnDiv.Size = new System.Drawing.Size(36, 23);
      this.btnDiv.TabIndex = 1;
      this.btnDiv.TabStop = false;
      this.btnDiv.Text = "/";
      this.btnDiv.UseVisualStyleBackColor = false;
      this.btnDiv.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnKey7
      // 
      this.btnKey7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey7.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey7.ForeColor = System.Drawing.Color.RoyalBlue;
      this.btnKey7.Location = new System.Drawing.Point(172, 64);
      this.btnKey7.Name = "btnKey7";
      this.btnKey7.Size = new System.Drawing.Size(36, 23);
      this.btnKey7.TabIndex = 1;
      this.btnKey7.TabStop = false;
      this.btnKey7.Text = "7";
      this.btnKey7.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnKey4
      // 
      this.btnKey4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey4.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey4.ForeColor = System.Drawing.Color.Blue;
      this.btnKey4.Location = new System.Drawing.Point(172, 92);
      this.btnKey4.Name = "btnKey4";
      this.btnKey4.Size = new System.Drawing.Size(36, 23);
      this.btnKey4.TabIndex = 1;
      this.btnKey4.TabStop = false;
      this.btnKey4.Text = "4";
      this.btnKey4.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnMul
      // 
      this.btnMul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMul.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnMul.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnMul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnMul.Font = new System.Drawing.Font("Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
      this.btnMul.ForeColor = System.Drawing.Color.Green;
      this.btnMul.Location = new System.Drawing.Point(292, 92);
      this.btnMul.Name = "btnMul";
      this.btnMul.Size = new System.Drawing.Size(36, 23);
      this.btnMul.TabIndex = 1;
      this.btnMul.TabStop = false;
      this.btnMul.Text = "*";
      this.btnMul.UseVisualStyleBackColor = false;
      this.btnMul.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnKey6
      // 
      this.btnKey6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKey6.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnKey6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnKey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnKey6.ForeColor = System.Drawing.Color.Blue;
      this.btnKey6.Location = new System.Drawing.Point(252, 92);
      this.btnKey6.Name = "btnKey6";
      this.btnKey6.Size = new System.Drawing.Size(36, 23);
      this.btnKey6.TabIndex = 1;
      this.btnKey6.TabStop = false;
      this.btnKey6.Text = "6";
      this.btnKey6.Click += new System.EventHandler(this.NumericButtonPress);
      // 
      // btnClearAll
      // 
      this.btnClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClearAll.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClearAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnClearAll.ForeColor = System.Drawing.Color.Red;
      this.btnClearAll.Location = new System.Drawing.Point(332, 32);
      this.btnClearAll.Name = "btnClearAll";
      this.btnClearAll.Size = new System.Drawing.Size(76, 23);
      this.btnClearAll.TabIndex = 1;
      this.btnClearAll.TabStop = false;
      this.btnClearAll.Text = "C";
      this.btnClearAll.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnClearEnter
      // 
      this.btnClearEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClearEnter.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnClearEnter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnClearEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnClearEnter.ForeColor = System.Drawing.Color.Red;
      this.btnClearEnter.Location = new System.Drawing.Point(252, 32);
      this.btnClearEnter.Name = "btnClearEnter";
      this.btnClearEnter.Size = new System.Drawing.Size(76, 23);
      this.btnClearEnter.TabIndex = 1;
      this.btnClearEnter.TabStop = false;
      this.btnClearEnter.Text = "CE";
      this.btnClearEnter.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnBackSpace
      // 
      this.btnBackSpace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnBackSpace.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnBackSpace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnBackSpace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnBackSpace.ForeColor = System.Drawing.Color.Red;
      this.btnBackSpace.Location = new System.Drawing.Point(172, 32);
      this.btnBackSpace.Name = "btnBackSpace";
      this.btnBackSpace.Size = new System.Drawing.Size(76, 23);
      this.btnBackSpace.TabIndex = 1;
      this.btnBackSpace.TabStop = false;
      this.btnBackSpace.Text = "BackSpace";
      this.btnBackSpace.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnFactorial
      // 
      this.btnFactorial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFactorial.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnFactorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnFactorial.ForeColor = System.Drawing.Color.Magenta;
      this.btnFactorial.Location = new System.Drawing.Point(92, 148);
      this.btnFactorial.Name = "btnFactorial";
      this.btnFactorial.Size = new System.Drawing.Size(32, 23);
      this.btnFactorial.TabIndex = 1;
      this.btnFactorial.TabStop = false;
      this.btnFactorial.Text = "n!";
      this.btnFactorial.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnLg
      // 
      this.btnLg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLg.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnLg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnLg.ForeColor = System.Drawing.Color.Magenta;
      this.btnLg.Location = new System.Drawing.Point(92, 120);
      this.btnLg.Name = "btnLg";
      this.btnLg.Size = new System.Drawing.Size(32, 23);
      this.btnLg.TabIndex = 1;
      this.btnLg.TabStop = false;
      this.btnLg.Text = "lg";
      this.btnLg.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnLn
      // 
      this.btnLn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnLn.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnLn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnLn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnLn.ForeColor = System.Drawing.Color.Magenta;
      this.btnLn.Location = new System.Drawing.Point(92, 92);
      this.btnLn.Name = "btnLn";
      this.btnLn.Size = new System.Drawing.Size(32, 23);
      this.btnLn.TabIndex = 1;
      this.btnLn.TabStop = false;
      this.btnLn.Text = "ln";
      this.btnLn.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnExp
      // 
      this.btnExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnExp.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnExp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnExp.ForeColor = System.Drawing.Color.Magenta;
      this.btnExp.Location = new System.Drawing.Point(56, 92);
      this.btnExp.Name = "btnExp";
      this.btnExp.Size = new System.Drawing.Size(32, 23);
      this.btnExp.TabIndex = 1;
      this.btnExp.TabStop = false;
      this.btnExp.Text = "exp";
      this.btnExp.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnPow2
      // 
      this.btnPow2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPow2.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnPow2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPow2.ForeColor = System.Drawing.Color.Magenta;
      this.btnPow2.Location = new System.Drawing.Point(56, 176);
      this.btnPow2.Name = "btnPow2";
      this.btnPow2.Size = new System.Drawing.Size(32, 23);
      this.btnPow2.TabIndex = 1;
      this.btnPow2.TabStop = false;
      this.btnPow2.Text = "x^2";
      this.btnPow2.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnPow3
      // 
      this.btnPow3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnPow3.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnPow3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnPow3.ForeColor = System.Drawing.Color.Magenta;
      this.btnPow3.Location = new System.Drawing.Point(56, 148);
      this.btnPow3.Name = "btnPow3";
      this.btnPow3.Size = new System.Drawing.Size(32, 23);
      this.btnPow3.TabIndex = 1;
      this.btnPow3.TabStop = false;
      this.btnPow3.Text = "x^3";
      this.btnPow3.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnTg
      // 
      this.btnTg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnTg.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnTg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnTg.ForeColor = System.Drawing.Color.Magenta;
      this.btnTg.Location = new System.Drawing.Point(8, 148);
      this.btnTg.Name = "btnTg";
      this.btnTg.Size = new System.Drawing.Size(44, 23);
      this.btnTg.TabIndex = 1;
      this.btnTg.TabStop = false;
      this.btnTg.Text = "tg";
      this.btnTg.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnCos
      // 
      this.btnCos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCos.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnCos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCos.ForeColor = System.Drawing.Color.Magenta;
      this.btnCos.Location = new System.Drawing.Point(8, 120);
      this.btnCos.Name = "btnCos";
      this.btnCos.Size = new System.Drawing.Size(44, 23);
      this.btnCos.TabIndex = 1;
      this.btnCos.TabStop = false;
      this.btnCos.Text = "cos";
      this.btnCos.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnSin
      // 
      this.btnSin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSin.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnSin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnSin.ForeColor = System.Drawing.Color.Magenta;
      this.btnSin.Location = new System.Drawing.Point(8, 92);
      this.btnSin.Name = "btnSin";
      this.btnSin.Size = new System.Drawing.Size(44, 23);
      this.btnSin.TabIndex = 1;
      this.btnSin.TabStop = false;
      this.btnSin.Text = "sin";
      this.btnSin.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnMod
      // 
      this.btnMod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnMod.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnMod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnMod.ForeColor = System.Drawing.Color.Green;
      this.btnMod.Location = new System.Drawing.Point(332, 64);
      this.btnMod.Name = "btnMod";
      this.btnMod.Size = new System.Drawing.Size(36, 23);
      this.btnMod.TabIndex = 1;
      this.btnMod.TabStop = false;
      this.btnMod.Text = "Mod";
      this.btnMod.UseVisualStyleBackColor = false;
      this.btnMod.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnOr
      // 
      this.btnOr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnOr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnOr.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnOr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnOr.ForeColor = System.Drawing.Color.Green;
      this.btnOr.Location = new System.Drawing.Point(332, 92);
      this.btnOr.Name = "btnOr";
      this.btnOr.Size = new System.Drawing.Size(36, 23);
      this.btnOr.TabIndex = 1;
      this.btnOr.TabStop = false;
      this.btnOr.Text = "?";
      this.btnOr.UseVisualStyleBackColor = false;
      this.btnOr.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnXor
      // 
      this.btnXor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnXor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnXor.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnXor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnXor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnXor.ForeColor = System.Drawing.Color.Green;
      this.btnXor.Location = new System.Drawing.Point(372, 92);
      this.btnXor.Name = "btnXor";
      this.btnXor.Size = new System.Drawing.Size(36, 23);
      this.btnXor.TabIndex = 1;
      this.btnXor.TabStop = false;
      this.btnXor.Text = "Xor";
      this.btnXor.UseVisualStyleBackColor = false;
      this.btnXor.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // btnNot
      // 
      this.btnNot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnNot.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnNot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnNot.ForeColor = System.Drawing.Color.Violet;
      this.btnNot.Location = new System.Drawing.Point(372, 148);
      this.btnNot.Name = "btnNot";
      this.btnNot.Size = new System.Drawing.Size(36, 23);
      this.btnNot.TabIndex = 1;
      this.btnNot.TabStop = false;
      this.btnNot.Text = "?";
      this.btnNot.Click += new System.EventHandler(this.AdditionalButtonPress);
      // 
      // btnAnd
      // 
      this.btnAnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
      this.btnAnd.Cursor = System.Windows.Forms.Cursors.Default;
      this.btnAnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAnd.ForeColor = System.Drawing.Color.Green;
      this.btnAnd.Location = new System.Drawing.Point(372, 64);
      this.btnAnd.Name = "btnAnd";
      this.btnAnd.Size = new System.Drawing.Size(36, 23);
      this.btnAnd.TabIndex = 1;
      this.btnAnd.TabStop = false;
      this.btnAnd.Text = "?";
      this.btnAnd.UseVisualStyleBackColor = false;
      this.btnAnd.Click += new System.EventHandler(this.OperationButtonPress);
      // 
      // cmbSystem
      // 
      this.cmbSystem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.cmbSystem.DisplayMember = "Dec";
      this.cmbSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbSystem.Items.AddRange(new object[] {
            "Hex",
            "Dec",
            "Oct",
            "Bin"});
      this.cmbSystem.Location = new System.Drawing.Point(8, 32);
      this.cmbSystem.Name = "cmbSystem";
      this.cmbSystem.Size = new System.Drawing.Size(44, 21);
      this.cmbSystem.TabIndex = 4;
      this.cmbSystem.SelectedIndexChanged += new System.EventHandler(this.cmbSystem_SelectedIndexChanged);
      // 
      // txtFullExpression
      // 
      this.txtFullExpression.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.txtFullExpression.Cursor = System.Windows.Forms.Cursors.Default;
      this.txtFullExpression.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.txtFullExpression.Location = new System.Drawing.Point(0, 205);
      this.txtFullExpression.MaxLength = 32;
      this.txtFullExpression.Name = "txtFullExpression";
      this.txtFullExpression.ReadOnly = true;
      this.txtFullExpression.Size = new System.Drawing.Size(414, 20);
      this.txtFullExpression.TabIndex = 0;
      this.txtFullExpression.TabStop = false;
      this.txtFullExpression.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
      this.txtFullExpression.TextChanged += new System.EventHandler(this.txtFullExpression_TextChanged);
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(414, 225);
      this.Controls.Add(this.cmbSystem);
      this.Controls.Add(this.btnEqual);
      this.Controls.Add(this.txtDisplay);
      this.Controls.Add(this.btnAdd);
      this.Controls.Add(this.btnComma);
      this.Controls.Add(this.btnPlusMinus);
      this.Controls.Add(this.btnKey0);
      this.Controls.Add(this.btnSub);
      this.Controls.Add(this.btnKey2);
      this.Controls.Add(this.btnKey3);
      this.Controls.Add(this.btnKey1);
      this.Controls.Add(this.btnKey5);
      this.Controls.Add(this.btnPow);
      this.Controls.Add(this.btnKey9);
      this.Controls.Add(this.btnKey8);
      this.Controls.Add(this.btnDiv);
      this.Controls.Add(this.btnKey7);
      this.Controls.Add(this.btnKey4);
      this.Controls.Add(this.btnMul);
      this.Controls.Add(this.btnKey6);
      this.Controls.Add(this.btnClearAll);
      this.Controls.Add(this.btnClearEnter);
      this.Controls.Add(this.btnBackSpace);
      this.Controls.Add(this.btnFactorial);
      this.Controls.Add(this.btnLg);
      this.Controls.Add(this.btnLn);
      this.Controls.Add(this.btnExp);
      this.Controls.Add(this.btnPow2);
      this.Controls.Add(this.btnPow3);
      this.Controls.Add(this.btnTg);
      this.Controls.Add(this.btnCos);
      this.Controls.Add(this.btnSin);
      this.Controls.Add(this.btnMod);
      this.Controls.Add(this.btnOr);
      this.Controls.Add(this.btnXor);
      this.Controls.Add(this.btnNot);
      this.Controls.Add(this.btnAnd);
      this.Controls.Add(this.txtFullExpression);
      this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "frmMain";
      this.Text = "Scientific calculator";
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    //#endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.Run(new frmMain());
    }

    /// <summary>
    /// ФУНКЦИОНАЛЬНАЯ ЧАСТЬ ПРИЛОЖЕНИЯ - ПРОЦЕДУРЫ ОБРАБОТКИ СОБЫТИЙ,
    /// ПОРОЖДЕННЫХ ВЗАИМОДЕЙСТВИЕМ ПОЛЬЗОВАТЕЛЯ С ИНТЕРФЕЙСОМ 
    /// ---------------------------------------
    /// </summary>

    //Процедура для активизации или отключения числовых кнопок в соответствии с
    // выбранной системой счисления
    private void ChangeSystem(CountingSystems CountingSystem)
    {
      switch (CountingSystem)
      {
        case CountingSystems.Bin:
          btnKey2.Enabled = false; btnKey3.Enabled = false;
          btnKey4.Enabled = false; btnKey5.Enabled = false;
          btnKey6.Enabled = false; btnKey7.Enabled = false;
          btnKey8.Enabled = false; btnKey9.Enabled = false;

          btnComma.Enabled = false; btnPlusMinus.Enabled = false;
          FunctionsVisible_CountingSystems();
          break;
        case CountingSystems.Dec:
          btnKey2.Enabled = true; btnKey3.Enabled = true;
          btnKey4.Enabled = true; btnKey5.Enabled = true;
          btnKey6.Enabled = true; btnKey7.Enabled = true;
          btnKey8.Enabled = true; btnKey9.Enabled = true;

          btnComma.Enabled = true; btnPlusMinus.Enabled = true;
          ChangeFunctionsVisible(true);
          break;
        case CountingSystems.Hex:
          btnKey2.Enabled = true; btnKey3.Enabled = true;
          btnKey4.Enabled = true; btnKey5.Enabled = true;
          btnKey6.Enabled = true; btnKey7.Enabled = true;
          btnKey8.Enabled = true; btnKey9.Enabled = true;

          btnComma.Enabled = false; btnPlusMinus.Enabled = false;
          FunctionsVisible_CountingSystems();
          break;
        case CountingSystems.Oct:
          btnKey2.Enabled = true; btnKey3.Enabled = true;
          btnKey4.Enabled = true; btnKey5.Enabled = true;
          btnKey6.Enabled = true; btnKey7.Enabled = true;
          btnKey8.Enabled = true; btnKey9.Enabled = false;

          btnComma.Enabled = false; btnPlusMinus.Enabled = false;
          FunctionsVisible_CountingSystems();
          break;
      }
    }

    private void FunctionsVisible_CountingSystems()
    {
      btnExp.Enabled = false; btnSin.Enabled = false;
      btnCos.Enabled = false; btnTg.Enabled = false;
      btnFactorial.Enabled = false;
      btnLg.Enabled = false; btnLn.Enabled = false;

      btnPow2.Enabled = false; btnPow3.Enabled = false;
      btnPow.Enabled = false;

      cmbSystem.Enabled = true;
    }
    // процедура для отключения части функциональных кнопок 

    private void ChangeFunctionsVisible(bool visibility)
    {
      btnExp.Enabled = visibility; btnSin.Enabled = visibility;
      btnCos.Enabled = visibility; btnTg.Enabled = visibility;
      btnFactorial.Enabled = visibility;
      btnLg.Enabled = visibility; btnLn.Enabled = visibility;

      btnPow2.Enabled = visibility; btnPow3.Enabled = visibility;

      cmbSystem.Enabled = visibility;
    }

    private void EqualKey_Block()
    {
      btnEqual.Enabled = false;
    }

    //Обработка нажатия числовой кнопки
    private void NumericButtonPress(object sender, EventArgs e)
    { //разблокирование кнопки "равно"	

      btnEqual.Enabled = true;

      //какая числовая кнопка нажата
      if (sender == btnKey0)
      { NumberKeyPress("0"); }
      else if (sender == btnKey1)
      { NumberKeyPress("1"); }
      else if (sender == btnKey2)
      { NumberKeyPress("2"); }
      else if (sender == btnKey3)
      { NumberKeyPress("3"); }
      else if (sender == btnKey4)
      { NumberKeyPress("4"); }
      else if (sender == btnKey5)
      { NumberKeyPress("5"); }
      else if (sender == btnKey6)
      { NumberKeyPress("6"); }
      else if (sender == btnKey7)
      { NumberKeyPress("7"); }
      else if (sender == btnKey8)
      { NumberKeyPress("8"); }
      else if (sender == btnKey9)
      { NumberKeyPress("9"); }

      else if (sender == btnComma)
      { NumberKeyPress("."); }
    }
    //По нажатию числовой кнопки в стек заносится значение, соответствующее
    //этой кнопке
    private void NumberKeyPress(string Digit)
    {
      _digits.Push(Digit);
      displayNumber();
    }
    // Процедура для отображения результата вычислений, который находится в 
    // параметре процедуры number. В этой процедуре в зависимости от выбранной
    // системы счисления результат явно преобразуется к типу String. Для этого 
    // используется статический метод Convert.ToString. Второй его параметр 
    // - основание системы счисления. После этого результат присваивается
    // свойству Text поля ввода/вывода  txtDisplay, чем и выводится на экран.

    private void displayNumber(double number)
    {
      switch (_currentSystem)
      {
        case CountingSystems.Bin:
          txtDisplay.Text = Convert.ToString((long)number, 2);
          break;
        case CountingSystems.Dec:
          txtDisplay.Text = Convert.ToString(number);
          break;
        case CountingSystems.Hex:
          txtDisplay.Text = Convert.ToString((long)number, 16);
          break;
        case CountingSystems.Oct:
          txtDisplay.Text = Convert.ToString((long)number, 8);
          break;
      }
    }
    // Процедура для вывода на экран вводимого поразрядно операнда,
    // разряды которого находятся в стеке _digits.

    private void displayNumber()
    {
      txtDisplay.Text = "";
      // Проход по стеку разрядов (приведено три варианта кода) и формирование
      // строки вывода для поля ввода/вывода

      object[] s = _digits.ToArray();
      for (int i = s.Length - 1; i >= 0; i--)
      {
        txtDisplay.Text += s[i].ToString();
      }
      /* 
      
      //Вариант кода № 2
      IEnumerator Enumer = _digits.GetEnumerator();
            while (Enumer.MoveNext())
            {
              txtDisplay.Text = Enumer.Current.ToString()+txtDisplay.Text;
            }
      //Вариант кода № 3
            foreach(object i in _digits)
            {txtDisplay.Text = i.ToString()+txtDisplay.Text;
            }
      */
      if (txtDisplay.Text == "")
      {
        txtDisplay.Text = "0";
      }
      if (_negative == true)
      {
        txtDisplay.Text = "-" + txtDisplay.Text;
      }
    }
    //Очистить поле ввода/вывода (кнопка CE) 
    private void Clear()
    {
      _digits.Clear();
      _negative = false;
      displayNumber();
    }
    //Поменять знак значения значения в поле ввода/вывода (кнопка btnPlusMinus)
    private void ChangeSign()
    {
      _negative = !_negative;
      displayNumber();
    }
    // Удалить последний введенный символ (кнопка  BackSpace)
    private void RemoveLastDigit()
    {
      if (_digits.Count > 0)
      {
        _digits.Pop();
      }
      displayNumber();
    }
    // Какая из функциональных клавиш нажата - выполняется операция только 
    // со значением в поле ввода/вывода или очистка.

    private void AdditionalButtonPress(object sender, EventArgs e)
    {
      if (sender == btnClearEnter)
      {
        Clear();
      }
      else if (sender == btnClearAll)
      {
        InitCalculator();
      }
      else if (sender == btnPlusMinus)
      {
        ChangeSign();
      }
      else if (sender == btnBackSpace)
      {
        RemoveLastDigit();
      }

      else if (sender == btnFactorial)
      {
        FactorialDispleyedNumber();
      }

      else if (sender == btnLg)
      {
        LogDispleyedNumber();
      }
      else if (sender == btnLn)
      {
        LnDispleyedNumber();
      }
      else if (sender == btnPow3)
      {
        Pow3DispleyedNumber();
      }
      else if (sender == btnPow2)
      {
        Pow2DispleyedNumber();
      }
      else if (sender == btnSin)
      {
        SinDispleyedNumber();
      }
      else if (sender == btnCos)
      {
        CosDispleyedNumber();
      }
      else if (sender == btnTg)
      {
        TanDispleyedNumber();
      }
      else if (sender == btnNot)
      {
        NotDispleyedNumber();
      }

      else if (sender == btnExp)
      {
        ExpDispleyedNumber();
      }
    }
    // Операции для функциональных клавиш. Обратить внимание - для того, чтобы
    // в этих операциях строковое значение поля ввода/вывода корректно преобразовывалось
    // в число (переменная number), нужно чтобы десятичная точка была представлена запятой
    private void ExpDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Exp(number));
    }



    private void NotDispleyedNumber()
    {
      Int32 number = (int)Convert.ToDouble(txtDisplay.Text);
      displayNumber(~number);
    }

    private void TanDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Tan(number));
    }

    private void CosDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Cos(number));
    }

    private void SinDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Sin(number));
    }

    private void Pow2DispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Pow(number, 2));
    }

    private void Pow3DispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Pow(number, 3));
    }

    private void LnDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Log(number));
    }

    private void LogDispleyedNumber()
    {
      double number = Convert.ToDouble(txtDisplay.Text);
      displayNumber(Math.Log10(number));
    }





    private void FactorialDispleyedNumber()
    {
      // Обратить внимание - пример обработки исключения, связанного с невозможностью 
      // вычислить факториал нецелого числа
      Int64 number;
      try
      {
        number = Convert.ToInt64(txtDisplay.Text);
      }
      catch (FormatException)
      {
        MessageBox.Show("Факториал нецелого числа", "--", MessageBoxButtons.OK);
        Clear();
        return;
      }
      if (number < 20 && number > 0)
      {
        Int64 Result = 1;
        for (Int64 i = 1; i <= number; i++)
        {
          Result *= i;
        }
        displayNumber(Result);
      }
      else
      {
        MessageBox.Show("Можно вычислять факториалы положительных чисел меньших 20");
        Clear();
        return;
      }
    }
    // Взять числовое значение из поля ввода/вывода с учетом
    // системы счисления	- это будет операнд X для опрераций
    // сложения, вычитания, умножения и деления			

    private double PullNumber()
    {
      double number = 0;
      switch (_currentSystem)
      {
        case CountingSystems.Bin:
          number = (double)Convert.ToInt32(txtDisplay.Text, 2);
          break;
        case CountingSystems.Dec:
          number = Convert.ToDouble(txtDisplay.Text);
          break;
        case CountingSystems.Hex:
          number = (double)Convert.ToInt32(txtDisplay.Text, 16);
          break;
        case CountingSystems.Oct:
          number = (double)Convert.ToInt32(txtDisplay.Text, 8);
          break;
      }
      _negative = false;
      _digits.Clear();
      return number;
    }
    //Обработка кнопок (+, -, *, /)

    private void OperationButtonPress(object sender, EventArgs e)
    {
      // Из поля ввода/вывода взяли первый операнд - X 
      X = PullNumber();

      // Заблокировать функциональные кнопки
      ChangeFunctionsVisible(false);

      //указать операцию
      if (sender == btnAdd)
      {
        _currentOperation = Operations.Add;
      }
      else if (sender == btnSub)
      {
        _currentOperation = Operations.Sub;
      }
      else if (sender == btnMul)
      {
        _currentOperation = Operations.Mul;
      }
      else if (sender == btnDiv)
      {
        _currentOperation = Operations.Div;
      }
      else if (sender == btnPow)
      {
        _currentOperation = Operations.Pow;
        displayNumber(Math.Abs(X));
      }
      else if (sender == btnMod)
      {
        _currentOperation = Operations.Mod;
      }
      else
      {
        return;
      }

      // заблокировать кнопку равно (пока есть только первый операнд)
      // эта блокировка будет снята нажатием любой числовой кнопки -  то есть вводом 
      // второго операнда
      EqualKey_Block();
    }
    // Обработка нажатия кнопки "равно"
    private void btnEqual_Click(object sender, EventArgs e)
    {
      double result = 0;

      //Взять второй операнд - Y
      Y = PullNumber();

      //выполнить операцию
      switch (_currentOperation)
      {
        case Operations.Add:
          result = X + Y;
          break;
        case Operations.Div:
          result = X / Y;
          break;
        case Operations.Sub:
          result = X - Y;
          break;
        case Operations.Mul:
          result = X * Y;
          break;
        case Operations.Mod:
          result = (int)X % (int)Y;
          break;
        case Operations.Pow:
          result = Math.Pow(X, Y);
          break;
      }

      //вывести результат
      displayNumber(result);

      //разблокировать функциональные кнопки
      ChangeFunctionsVisible(true);
    }
    //Смена системы счисления - задается полем со списком cmbSystem
    private void cmbSystem_SelectedIndexChanged(object sender, EventArgs e)
    {
      Int64 number = 0;

      switch (_currentSystem)
      {
        //Преобразование из десятичной системы счисления - допустимо только 
        //целое положительное число        

        case CountingSystems.Dec:
          //Проверка поля ввода/вывода на неотрицательность
          if (Convert.ToDouble(txtDisplay.Text) < 0)
          {
            MessageBox.Show("Сброс отрицательного числа",
            "Преобразование системы счисления", MessageBoxButtons.OK);
            Clear(); number = 0;
          }
          else
          //Проверка того, что в поле ввода/вывода целое число
          {
            try
            {
              number = Convert.ToInt64(txtDisplay.Text);
            }
            catch (FormatException)
            {
              MessageBox.Show("Сброс нецелого числа",
             "Преобразование системы счисления", MessageBoxButtons.OK);
              Clear(); number = 0;
            }
          }
          break;
        case CountingSystems.Bin:
          number = Convert.ToInt64(txtDisplay.Text, 2);
          break;
        case CountingSystems.Hex:
          number = Convert.ToInt64(txtDisplay.Text, 16);
          break;
        case CountingSystems.Oct:
          number = Convert.ToInt64(txtDisplay.Text, 8);
          break;
      }
      switch (cmbSystem.SelectedIndex)
      {
        case 0:
          _currentSystem = CountingSystems.Hex;
          txtDisplay.Text = Convert.ToString((long)number, 16);
          ChangeSystem(CountingSystems.Hex);
          break;
        case 1:
          _currentSystem = CountingSystems.Dec;
          txtDisplay.Text = Convert.ToString(number);
          ChangeSystem(CountingSystems.Dec);
          break;
        case 2:
          _currentSystem = CountingSystems.Oct;
          txtDisplay.Text = Convert.ToString((long)number, 8);
          ChangeSystem(CountingSystems.Oct);
          break;
        case 3:
          _currentSystem = CountingSystems.Bin;
          txtDisplay.Text = Convert.ToString((long)number, 2);
          ChangeSystem(CountingSystems.Bin);
          break;
      }
    }

    // Работа с кнопками памяти - здесь нет кода 
    // private void MemoryButtonPress(object sender, EventArgs e)
    // {
    //  if (sender == btnMemoryAdd)
    //  {
    //       AddMemory();
    // }
    // else if (sender == btnMemoryShift)
    //  {
    //     ShiftMemory();
    // }
    //  else if (sender == btnMemoryRestore)
    // {
    //    RestoreMemory();
    // }
    // else if (sender == btnMemoryClear)
    //{
    //  ClearMemory();
    //  }
    // }
    //private void ClearMemory()
    // {	
    //}

    // private void RestoreMemory()
    // {	
    // }

    // private void ShiftMemory()
    // {
    // }

    //private void AddMemory()
    //{			
    // }

    private void frmMain_Load(object sender, System.EventArgs e)
    {

    }

    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }

    private void button1_Click(object sender, System.EventArgs e)
    {

    }

    private void txtFullExpression_TextChanged(object sender, EventArgs e)
    {

    }
  }
}
