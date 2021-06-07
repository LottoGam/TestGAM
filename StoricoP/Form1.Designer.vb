<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ArchivioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VediArchivioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstrazioniPariToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstrazioniDispariToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EsciToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnnambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OttambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EptambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EsambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PentambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuadrambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TriambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BiambiResiduiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 27)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 28)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Carica"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Teal
        Me.Label6.Location = New System.Drawing.Point(7, 525)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 150)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "GAM____Lotto Ritardi 0.10 per Windows 64 bit by Lorenzo Camprini"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(52, 27)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(60, 28)
        Me.Button2.TabIndex = 28
        Me.Button2.Text = "Aggiorna"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(0, 61)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(113, 24)
        Me.Button5.TabIndex = 34
        Me.Button5.Text = "Carica dati Random"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Font = New System.Drawing.Font("Courier New", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox1.HideSelection = False
        Me.RichTextBox1.Location = New System.Drawing.Point(118, 27)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RichTextBox1.Size = New System.Drawing.Size(742, 650)
        Me.RichTextBox1.TabIndex = 35
        Me.RichTextBox1.Text = ""
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ArchivioToolStripMenuItem, Me.ResiduiToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(862, 24)
        Me.MenuStrip1.TabIndex = 36
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ArchivioToolStripMenuItem
        '
        Me.ArchivioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VediArchivioToolStripMenuItem, Me.EstrazioniPariToolStripMenuItem, Me.EstrazioniDispariToolStripMenuItem, Me.EsciToolStripMenuItem})
        Me.ArchivioToolStripMenuItem.Name = "ArchivioToolStripMenuItem"
        Me.ArchivioToolStripMenuItem.Size = New System.Drawing.Size(63, 20)
        Me.ArchivioToolStripMenuItem.Text = "&Archivio"
        '
        'VediArchivioToolStripMenuItem
        '
        Me.VediArchivioToolStripMenuItem.Name = "VediArchivioToolStripMenuItem"
        Me.VediArchivioToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.VediArchivioToolStripMenuItem.Text = "Vedi &Archivio"
        '
        'EstrazioniPariToolStripMenuItem
        '
        Me.EstrazioniPariToolStripMenuItem.Name = "EstrazioniPariToolStripMenuItem"
        Me.EstrazioniPariToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EstrazioniPariToolStripMenuItem.Text = "Estrazioni &Pari"
        '
        'EstrazioniDispariToolStripMenuItem
        '
        Me.EstrazioniDispariToolStripMenuItem.Name = "EstrazioniDispariToolStripMenuItem"
        Me.EstrazioniDispariToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EstrazioniDispariToolStripMenuItem.Text = "Estrazioni &Dispari"
        '
        'EsciToolStripMenuItem
        '
        Me.EsciToolStripMenuItem.Name = "EsciToolStripMenuItem"
        Me.EsciToolStripMenuItem.Size = New System.Drawing.Size(163, 22)
        Me.EsciToolStripMenuItem.Text = "&Esci"
        '
        'ResiduiToolStripMenuItem
        '
        Me.ResiduiToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EnnambiResiduiToolStripMenuItem, Me.OttambiResiduiToolStripMenuItem, Me.EptambiResiduiToolStripMenuItem, Me.EsambiResiduiToolStripMenuItem, Me.PentambiResiduiToolStripMenuItem, Me.QuadrambiResiduiToolStripMenuItem, Me.TriambiResiduiToolStripMenuItem, Me.BiambiResiduiToolStripMenuItem})
        Me.ResiduiToolStripMenuItem.Name = "ResiduiToolStripMenuItem"
        Me.ResiduiToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.ResiduiToolStripMenuItem.Text = "&Residui"
        '
        'EnnambiResiduiToolStripMenuItem
        '
        Me.EnnambiResiduiToolStripMenuItem.Name = "EnnambiResiduiToolStripMenuItem"
        Me.EnnambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EnnambiResiduiToolStripMenuItem.Text = "&Ennambi residui"
        '
        'OttambiResiduiToolStripMenuItem
        '
        Me.OttambiResiduiToolStripMenuItem.Name = "OttambiResiduiToolStripMenuItem"
        Me.OttambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.OttambiResiduiToolStripMenuItem.Text = "&Ottambi residui"
        '
        'EptambiResiduiToolStripMenuItem
        '
        Me.EptambiResiduiToolStripMenuItem.Name = "EptambiResiduiToolStripMenuItem"
        Me.EptambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EptambiResiduiToolStripMenuItem.Text = "Epta&mbi residui"
        '
        'EsambiResiduiToolStripMenuItem
        '
        Me.EsambiResiduiToolStripMenuItem.Name = "EsambiResiduiToolStripMenuItem"
        Me.EsambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.EsambiResiduiToolStripMenuItem.Text = "E&sambi residui"
        '
        'PentambiResiduiToolStripMenuItem
        '
        Me.PentambiResiduiToolStripMenuItem.Name = "PentambiResiduiToolStripMenuItem"
        Me.PentambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.PentambiResiduiToolStripMenuItem.Text = "Pe&ntambi residui"
        '
        'QuadrambiResiduiToolStripMenuItem
        '
        Me.QuadrambiResiduiToolStripMenuItem.Name = "QuadrambiResiduiToolStripMenuItem"
        Me.QuadrambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.QuadrambiResiduiToolStripMenuItem.Text = "Q&uadriambi residui"
        '
        'TriambiResiduiToolStripMenuItem
        '
        Me.TriambiResiduiToolStripMenuItem.Name = "TriambiResiduiToolStripMenuItem"
        Me.TriambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.TriambiResiduiToolStripMenuItem.Text = "T&riambi residui"
        '
        'BiambiResiduiToolStripMenuItem
        '
        Me.BiambiResiduiToolStripMenuItem.Name = "BiambiResiduiToolStripMenuItem"
        Me.BiambiResiduiToolStripMenuItem.Size = New System.Drawing.Size(175, 22)
        Me.BiambiResiduiToolStripMenuItem.Text = "&Biambi residui"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(862, 683)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lotto Ritardi 0.10 per Windows 64 bit by Lorenzo Camprini email: lorenzo.camprini" &
    "@gmail.com"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button5 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ArchivioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VediArchivioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstrazioniPariToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EstrazioniDispariToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EnnambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OttambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EptambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EsambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PentambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuadrambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TriambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BiambiResiduiToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EsciToolStripMenuItem As ToolStripMenuItem
End Class
